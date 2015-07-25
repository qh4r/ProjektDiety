using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IUserProfile
    {
        #region Properties

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
        string UserName{get; set;}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
        double Height{get; set;}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
        double Weight{get; set;}

		/// <summary>
		/// Gets or sets the bmi.
		/// </summary>
		/// <value>
		/// The bmi.
		/// </value>
        double Bmi{get; set;}

		/// <summary>
		/// Gets or sets the planned meals.
		/// </summary>
		/// <value>
		/// The planned meals.
		/// </value>
        IEnumerable<IMealHistoryRecord> PlannedMeals{get; set;}\

        /// <summary>
        /// Gets or sets the weight history.
        /// </summary>
        /// <value>
        /// The weight history.
        /// </value>
        IEnumerable<IWeightHistoryRecord> WeightHistory{get; set;}

        /// <summary>
        /// Gets or sets the trainings history.
        /// </summary>
        /// <value>
        /// The trainings history.
        /// </value>
        IEnumerable<ITrainingHistoryRecord> TrainingsHistory{get; set;}

        /// <summary>
        /// Gets or sets the meals history.
        /// </summary>
        /// <value>
        /// The meals history.
        /// </value>
        IEnumerable<IMealHistoryRecord> MealsHistory { get; set; }

        #endregion
    }
}
