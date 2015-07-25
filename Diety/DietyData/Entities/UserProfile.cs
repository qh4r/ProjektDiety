using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
    public class UserProfile: IUserProfile
    {
        #region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; } 

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
        public string UserName {get; set;}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
        public double Height { get; set; }

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
        public double Weight { get; set; }

		/// <summary>
		/// Gets or sets the bmi.
		/// </summary>
		/// <value>
		/// The bmi.
		/// </value>
        public double Bmi { get; set; }

		/// <summary>
		/// Gets or sets the planned meals.
		/// </summary>
		/// <value>
		/// The planned meals.
		/// </value>
		public ICollection<IMealHistoryRecord> PlannedMeals { get; set; }

		/// <summary>
		/// Gets or sets the weight history.
		/// </summary>
		/// <value>
		/// The weight history.
		/// </value>
		public ICollection<IWeightHistoryRecord> WeightHistory { get; set; }

		/// <summary>
		/// Gets or sets the trainings history.
		/// </summary>
		/// <value>
		/// The trainings history.
		/// </value>
		public ICollection<ITrainingHistoryRecord> TrainingsHistory { get; set; }

		/// <summary>
		/// Gets or sets the meals history.
		/// </summary>
		/// <value>
		/// The meals history.
		/// </value>
		public ICollection<IMealHistoryRecord> MealsHistory { get; set; }

        #endregion

    }
}
