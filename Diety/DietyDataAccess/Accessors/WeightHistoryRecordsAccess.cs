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
			var newWeightRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newWeightRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					var weightDb = newWeightRecord as WeightHistoryRecordDb;					

					dietyContext.Entry(weightDb.Owner).State = EntityState.Unchanged;



					dietyContext.WeightHistoryRecords.Add(weightDb);
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
		public async Task<IEnumerable<IWeightHistoryRecord>> GetWeightHistoryRecordsList(
			Func<IWeightHistoryRecord, bool> searchCondition = null,
			Func<IWeightHistoryRecord, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DietyDbContext)
			{
				IEnumerable<IWeightHistoryRecord> outputList;
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
				var result = outputList.Select(x => new WeightHistoryRecord(x)).ToList();

				return result;
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IWeightHistoryRecord> GetWeightHistoryRecord(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.WeightHistoryRecords.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new WeightHistoryRecord(record) : null;
			}
		}

		#endregion
	}
}
