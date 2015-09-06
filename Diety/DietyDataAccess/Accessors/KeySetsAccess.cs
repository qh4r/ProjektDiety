using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using DietyDataTransportTypes.Interfaces;

namespace DietyDataAccess.Accessors
{
	public class KeySetsAccess : DataAccessBase, IKeySetsAccess
	{
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<IKeySet> AddMealRecord(IKeySet item)
		{
			var wrappedRecord = item as KeySet;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DataAccessBase.DietyDbContext)
				{
					dietyContext.KeySets.Add(newMealRecord as KeySetDb);
					await dietyContext.SaveChangesAsync();
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
		public async Task<IEnumerable<IKeySet>> GetKeySetsList(
			Func<KeySetDb, bool> searchCondition = null,
			Func<KeySetDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DataAccessBase.DietyDbContext)
			{
				IEnumerable<IKeySetData> outputList;
				if (orderRule != null)
				{
					outputList =
						dietyContext.KeySets.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						dietyContext.KeySets.Where(searchCondition ?? (x => true))
							.Skip(skipCount)
							.Take(takeCount);
				}
				await Task.Yield();
				return outputList.Select(x => new KeySet(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IKeySet> GetKeySet(long id)
		{
			using (var dietyContext = DataAccessBase.DietyDbContext)
			{
				var record = await dietyContext.KeySets.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new KeySet(record) : null;
			}
		}

		#endregion
	}
}
