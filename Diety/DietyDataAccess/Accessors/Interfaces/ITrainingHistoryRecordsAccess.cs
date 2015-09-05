using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;

namespace DietyDataAccess.Accessors.Interfaces
{
	public interface ITrainingHistoryRecordsAccess
	{
		#region Public Properties

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		Task<ITrainingHistoryRecord> AddMealRecord(ITrainingHistoryRecord item);

		/// <summary>
		/// Gets the meal history records list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		Task<IEnumerable<ITrainingHistoryRecord>> GetTrainingHistoryRecordsList(
			Func<TrainingHistoryRecordDb, bool> searchCondition = null,
			Func<TrainingHistoryRecordDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue);

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Task<ITrainingHistoryRecord> GetTrainingHistoryRecord(long id);

		#endregion

	}
}