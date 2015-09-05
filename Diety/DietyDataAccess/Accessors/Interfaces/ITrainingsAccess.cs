using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;

namespace DietyDataAccess.Accessors.Interfaces
{
	public interface ITrainingsAccess
	{
		#region Public Properties

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		Task<ITraining> AddMealRecord(ITraining item);

		/// <summary>
		/// Gets the meal history records list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		Task<IEnumerable<ITraining>> GetTrainingsList(
			Func<TrainingDb, bool> searchCondition = null,
			Func<TrainingDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue);

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Task<ITraining> GetTraining(long id);

		#endregion

	}
}