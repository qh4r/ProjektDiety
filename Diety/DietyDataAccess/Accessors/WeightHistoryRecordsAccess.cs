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
	public class WeightHistoryRecordsAccess : DataAccessBase, IWeightHistoryRecordsAccess
	{		
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<IWeightHistoryRecord> AddMealRecord(IWeightHistoryRecord item)
		{
			var wrappedRecord = item as WeightHistoryRecord;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DataAccessBase.DietyDbContext)
				{
					dietyContext.WeightHistoryRecords.Add(newMealRecord as WeightHistoryRecordDb);
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
		public async Task<IEnumerable<IWeightHistoryRecord>> GetWeightHistoryRecordsList(
			Func<WeightHistoryRecordDb, bool> searchCondition = null,
			Func<WeightHistoryRecordDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DataAccessBase.DietyDbContext)
			{
				IEnumerable<IWeightHistoryRecordData> outputList;
				if (orderRule != null)
				{
					outputList =
						dietyContext.WeightHistoryRecords.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						dietyContext.WeightHistoryRecords.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}
				await Task.Yield();
				return outputList.Select(x => new WeightHistoryRecord(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IWeightHistoryRecord> GetWeightHistoryRecord(long id)
		{
			using (var dietyContext = DataAccessBase.DietyDbContext)
			{
				var record = await dietyContext.WeightHistoryRecords.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new WeightHistoryRecord(record) : null;
			}
		}

		#endregion
	}
}
