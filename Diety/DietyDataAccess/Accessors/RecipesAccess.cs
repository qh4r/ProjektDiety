﻿using System;
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
					//newMealRecord as RecipeDb
					//var newItem = new RecipeDb
					//{
					//	ComponentsList = newMealRecord.ComponentsList,
					//	Description = newMealRecord.Description,
					//	Name = newMealRecord.Name,
					//	Id = newMealRecord.Id,
					//	MealType = newMealRecord.MealType
					//};					
					dietyContext.Recipes.AddOrUpdate(newMealRecord as RecipeDb);
					await dietyContext.SaveChangesAsync();
				}
				await Task.Yield();
			}
			return item;
		}

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
				dietyContext.Configuration.LazyLoadingEnabled = false;
				dietyContext.Recipes.Include(x => x.ComponentsListData);
				IEnumerable<IRecipe> outputList;
				if (orderRule != null)
				{
					outputList =
						DietyDbContext.Recipes.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						DietyDbContext.Recipes.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}				
				var result = outputList.ToList();				
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
			var recipeDb = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : recipe;
			using (var dietyContext = DietyDbContext)
			{
				dietyContext.Recipes.Remove(recipeDb as RecipeDb);
				var x = await dietyContext.SaveChangesAsync();				
			}
		}

		#endregion
	}
}
