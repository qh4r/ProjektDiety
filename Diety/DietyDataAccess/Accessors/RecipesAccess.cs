using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using DietyDataTransportTypes.Interfaces;

namespace DietyDataAccess.Accessors
{
	public class RecipesAccess : DataAccessBase, IRecipesAccess
	{
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<IRecipe> AddRecipe(IRecipe item)
		{
			var wrappedRecord = item as Recipe;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;
			if (newMealRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					var recipeDb = newMealRecord as RecipeDb;
					foreach (var component in recipeDb.ComponentsList)
					{
						dietyContext.Entry(component.Ingredient).State = EntityState.Unchanged;
					}

					dietyContext.Recipes.Add(recipeDb);
					await dietyContext.SaveChangesAsync();
				}
				await Task.Yield();
			}
			return item;
		}

		/// <summary>
		/// Updates the recipe.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="previousComponentsList"></param>
		/// <returns></returns>
		public async Task<IRecipe> UpdateRecipe(IRecipe item, IEnumerable<IRecipeComponent> previousComponentsList)
		{
			var wrappedRecord = item as Recipe;
			var recipe = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;
			var recipeDb = recipe as RecipeDb;

			if (recipeDb != null)
			{
				var previousComponentsDbList =
					previousComponentsList.Select(
						x => (x as RecipeComponentDb) ?? (x as RecipeComponent).UnwrapDataObject() as RecipeComponentDb);

				using (var dietyContext = DietyDbContext)
				{					
					foreach (var previousComponent in previousComponentsDbList)
					{
						if (recipeDb.ComponentsList.All(x => x.Id != previousComponent.Id))
						{
							dietyContext.Entry(previousComponent.OwnerComponent).State = EntityState.Unchanged;

							dietyContext.Entry(previousComponent).State = EntityState.Added;
							dietyContext.Entry(previousComponent).State = EntityState.Deleted;
						}
					}
					dietyContext.SaveChanges();

					foreach (var recipeComponentDb in recipeDb.ComponentsListData)
					{
						recipeComponentDb.OwnerComponent = recipeDb;

						if (recipeComponentDb.Id == 0)
						{
							dietyContext.Entry(recipeComponentDb).State = EntityState.Added;
						}
						else
						{
							//dietyContext.Entry(recipeComponentDb).State = EntityState.Added;
							dietyContext.Entry(recipeComponentDb).State = EntityState.Modified;
						}
						dietyContext.Entry(recipeComponentDb.IngredientData).State = EntityState.Unchanged;
					}
					dietyContext.Recipes.AddOrUpdate(recipeDb);

					dietyContext.Entry(recipeDb).State = EntityState.Modified;

					dietyContext.SaveChanges();

					//dietyContext.Entry(recipeDb).State = EntityState.Added;
					//dietyContext.Entry(recipeDb).State = EntityState.Modified;

					//dietyContext.SaveChanges();
				}
			}
			return item;
		}

		//DEL ADD
		//if (recipe != null)
		//{
		//	var newRecipe = new RecipeDb
		//	{
		//		ComponentsList = recipeDb.ComponentsList,
		//		Description = recipeDb.Description,
		//		Image = recipeDb.Image,
		//		MealType = recipeDb.MealType,
		//		Name = recipeDb.Name
		//	};
		//	using (var dietyContext = DietyDbContext)
		//	{
		//		////dietyContext.Entry(recipeDb).State = EntityState.Detached;
		//		//var oldRecipe = dietyContext.Recipes.FirstOrDefault(x => x.Id == recipe.Id);
		//		//dietyContext.Recipes.Attach(oldRecipe);
		//		//foreach (var recipeComponent in oldRecipe.ComponentsList)
		//		//{
		//		//	dietyContext.Entry(recipeComponent).State = EntityState.Deleted;
		//		//}
		//		//await dietyContext.SaveChangesAsync();
		//		//dietyContext.Recipes.Remove(oldRecipe);
		//		////dietyContext.Entry(oldRecipe).State = EntityState.Deleted;

		//		recipeDb.ComponentsListData.RemoveAll(x => x.Id == 0);

		//		foreach (var recipeComponentDb in recipeDb.ComponentsListData)
		//		{
		//			dietyContext.Entry(recipeComponentDb).State = EntityState.Added;

		//			dietyContext.Entry(recipeComponentDb).State = EntityState.Detached;
		//		}
		//		await dietyContext.SaveChangesAsync();
		//	}
		//	using (var dietyContext = DietyDbContext)
		//	{
		//		dietyContext.Entry(recipeDb).State = EntityState.Added;
		//		dietyContext.Entry(recipeDb).State = EntityState.Deleted;
		//DEL ADD

		//EDIT one
		//		//dietyContext.Recipes.Attach(recipeDb);
		//		//foreach (var recipeComponentDb in recipeDb.ComponentsListData)
		//		//{
		//		//	if (recipeComponentDb.Id == 0)
		//		//	{
		//		//		dietyContext.Entry(recipeComponentDb).State = EntityState.Detached;
		//		//	}
		//		//}
		//		//dietyContext.Recipes.Remove(recipeDb);
		//		await dietyContext.SaveChangesAsync();
		//	}

		//	using (var dietyContext = DietyDbContext)
		//	{
		//		foreach (var component in newRecipe.ComponentsList)
		//		{
		//			dietyContext.Entry(component.Ingredient).State = EntityState.Unchanged;
		//		}

		//		dietyContext.Recipes.Add(newRecipe);
		//		await dietyContext.SaveChangesAsync();
		//	}
		//using (var dietyContext = DietyDbContext)
		//{
		//	var unmodified = dietyContext.Recipes.FirstOrDefault(x => x.Id == newMealRecord.Id);
		//	var oldComponents = unmodified.ComponentsList.ToList();
		//	foreach (var oldComponent in oldComponents)
		//	{
		//		if (newMealRecord.ComponentsList.All(x => x.Id != oldComponent.Id))
		//		{
		//			dietyContext.Entry(oldComponent).State = EntityState.Deleted;
		//		}
		//	}
		//	await dietyContext.SaveChangesAsync();
		//}

		//using (var dietyContext = DietyDbContext)
		//{
		//	var recipeDb = newMealRecord as RecipeDb;

		//	foreach (var component in recipeDb.ComponentsList)
		//	{
		//		if (component.Id == 0)
		//		{
		//			dietyContext.Entry(component).State = EntityState.Added;
		//		}
		//		else
		//		{
		//			dietyContext.Entry(component).State = EntityState.Modified;
		//		}
		//		dietyContext.Entry(component.Ingredient).State = EntityState.Added;						
		//		dietyContext.Entry(component.Ingredient).State = EntityState.Unchanged;						
		//	}

		//	//dietyContext.Entry(recipeDb).State = EntityState.Added;
		//	dietyContext.Entry(recipeDb).State = EntityState.Modified;
		//	//dietyContext.Entry(recipeDb).Property(x => x.ComponentsListData).IsModified = true;
		//	await dietyContext.SaveChangesAsync();
		//}
		//await Task.Yield();
		//EDIT ONE

		/// <summary>
		/// Gets the meal history records list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		public async Task<IEnumerable<IRecipe>> GetRecipesList(
			Func<IRecipe, bool> searchCondition = null,
			Func<IRecipe, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DietyDbContext)
			{

				IEnumerable<IRecipe> outputList;
				if (orderRule != null)
				{
					outputList =
						dietyContext.Recipes.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						dietyContext.Recipes.Where(searchCondition ?? (x => true))
							.Skip(skipCount)
							.Take(takeCount);
				}
				var result = outputList.ToList();
				foreach (var r in result)
				{
					r.ComponentsList = r.ComponentsList.ToList();
					foreach (var recipeComponent in r.ComponentsList)
					{
						recipeComponent.Ingredient = recipeComponent.Ingredient;
					}
				}
				await Task.Yield();
				return result.Select(x => new Recipe(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IRecipe> GetRecipe(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await dietyContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new Recipe(record) : null;
			}
		}

		/// <summary>
		/// Removes the recipe.
		/// </summary>
		/// <param name="recipe">The recipe.</param>
		/// <returns></returns>
		public async Task RemoveRecipe(IRecipe recipe)
		{
			var wrappedRecord = recipe as Recipe;
			var recipeDb = (wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : recipe) as RecipeDb;
			using (var dietyContext = DietyDbContext)
			{
				dietyContext.Recipes.Attach(recipeDb);
				dietyContext.Recipes.Remove(recipeDb);
				var x = await dietyContext.SaveChangesAsync();
			}
		}

		#endregion
	}
}
