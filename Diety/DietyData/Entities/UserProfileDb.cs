using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Policy;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("UserProfiles")]
	public class UserProfileDb : IUserProfileData
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
		[MaxLength(20)]
		[Index("UserUnique", IsClustered = false, IsUnique = true)]
		public string UserName { get; set; }

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
		/// Gets or sets the planned meals data.
		/// </summary>
		/// <value>
		/// The planned meals data.
		/// </value>
		[Column("MealRecords")]
		public virtual ICollection<MealHistoryRecordDb> MealRecordsData { get; set; }

		/// <summary>
		/// Gets or sets the planned meals.
		/// </summary>
		/// <value>
		/// The planned meals.
		/// </value>
		[NotMapped]
		public IEnumerable<IMealHistoryRecord> MealRecords
		{
			get { return MealRecordsData; }
			set { MealRecordsData = value as ICollection<MealHistoryRecordDb>; }
		}

		/// <summary>
		/// Gets or sets the weight history data.
		/// </summary>
		/// <value>
		/// The weight history data.
		/// </value>
		[Column("WeightHistory")]
		public virtual ICollection<WeightHistoryRecordDb> WeightHistoryData { get; set; }

		/// <summary>
		/// Gets or sets the weight history.
		/// </summary>
		/// <value>
		/// The weight history.
		/// </value>
		[NotMapped]
		public IEnumerable<IWeightHistoryRecord> WeightHistory
		{
			get { return WeightHistoryData; }
			set { WeightHistoryData = value as ICollection<WeightHistoryRecordDb>; }
		}

		/// <summary>
		/// Gets or sets the training history data.
		/// </summary>
		/// <value>
		/// The training history data.
		/// </value>
		[Column("TrainingsHistory")]
		public virtual ICollection<TrainingHistoryRecordDb> TrainingsHistoryData { get; set; }

		/// <summary>
		/// Gets or sets the trainings history.
		/// </summary>
		/// <value>
		/// The trainings history.
		/// </value>
		[NotMapped]
		public IEnumerable<ITrainingHistoryRecord> TrainingsHistory
		{
			get { return TrainingsHistoryData; }
			set { TrainingsHistoryData = value as ICollection<TrainingHistoryRecordDb>; }
		}

		/// <summary>
		/// Gets or sets the hashed password.
		/// </summary>
		/// <value>
		/// The hashed password.
		/// </value>
		public string HashedPassword { get; set; }


		///// <summary>
		///// Gets or sets the meals history data.
		///// </summary>
		///// <value>
		///// The meals history data.
		///// </value>
		//[Column("MealsHistory")]
		//public ICollection<MealHistoryRecordDb> MealsHistoryData { get; set; }

		///// <summary>
		///// Gets or sets the meals history.
		///// </summary>
		///// <value>
		///// The meals history.
		///// </value>
		//[NotMapped]
		//public IEnumerable<IMealHistoryRecord> MealsHistory {
		//	get
		//	{
		//		return MealsHistoryData;
		//	}
		//	set { MealsHistoryData = value as ICollection<MealHistoryRecordDb>; } }

		#endregion

	}
}
