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
	public class RecipeComponentsAccess : DataAccessBase, IRecipeComponentsAccess
	{		
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<IRecipeComponent> AddMealRecord(IRecipeComponent item)
		{
			var wrappedRecord = item as RecipeComponent;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					DietyDbContext.RecipeComponents.Add(newMealRecord as RecipeComponentDb);
					await DietyDbContext.SaveChangesAsync();
				}
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
		public async Task<IEnumerable<IRecipeComponent>> GetRecipeComponentsList(
			Func<RecipeComponentDb, bool> searchCondition = null,
			Func<RecipeComponentDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DietyDbContext)
			{
				IEnumerable<IRecipeComponentData> outputList;
				if (orderRule != null)
				{
					outputList =
						DietyDbContext.RecipeComponents.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						DietyDbContext.RecipeComponents.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}
				await Task.Yield();
				return outputList.Select(x => new RecipeComponent(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IRecipeComponent> GetRecipeComponent(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.RecipeComponents.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new RecipeComponent(record) : null;
			}
		}

		#endregion
	}
}
