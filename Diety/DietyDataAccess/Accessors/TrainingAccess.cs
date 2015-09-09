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
	public class TrainingsAccess : DataAccessBase, ITrainingsAccess
	{		
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<ITraining> AddMealRecord(ITraining item)
		{
			var wrappedRecord = item as Training;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					DietyDbContext.Trainings.Add(newMealRecord as TrainingDb);
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
		public async Task<IEnumerable<ITraining>> GetTrainingsList(
			Func<TrainingDb, bool> searchCondition = null,
			Func<TrainingDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DietyDbContext)
			{
				IEnumerable<ITrainingData> outputList;
				if (orderRule != null)
				{
					outputList =
						DietyDbContext.Trainings.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						DietyDbContext.Trainings.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}
				await Task.Yield();
				return outputList.Select(x => new Training(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<ITraining> GetTraining(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.Trainings.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new Training(record) : null;
			}
		}

		#endregion
	}
}
