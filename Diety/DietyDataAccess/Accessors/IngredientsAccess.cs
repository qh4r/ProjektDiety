using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using DietyDataTransportTypes.Interfaces;

namespace DietyDataAccess.Accessors
{
	public class IngredientsAccess : DataAccessBase, IIngredientsAccess
	{		
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The ingredient.</param>
		/// <returns></returns>
		public async Task<IIngredient> AddMealRecord(IIngredient item)
		{
			var wrappedRecord = item as Ingredient;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					DietyDbContext.Ingredients.Add(newMealRecord as IngredientDb);
					await DietyDbContext.SaveChangesAsync();
				}
			}
			return item;
		}

		/// <summary>
		/// Gets the ingredients list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		public async Task<IEnumerable<IIngredient>> GetIngredientsList(
			Func<IIngredient, bool> searchCondition = null,
			Func<IIngredient, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DietyDbContext)
			{
				IEnumerable<IIngredient> outputList;
				if (orderRule != null)
				{
					outputList =
						dietyContext.Ingredients.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						dietyContext.Ingredients.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}
				var result = outputList.ToList();
				await Task.Yield();
				return result.Select(x => new Ingredient(x));
			}
		}

		/// <summary>
		/// Gets the ingredient.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IIngredient> GetIngredient(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new Ingredient(record) : null;
			}
		}

		#endregion
	}
}
