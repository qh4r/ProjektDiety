using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("TrainingHistoryRecords")]
	public class TrainingHistoryRecordDb : ITrainingHistoryRecordData
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
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the training data.
		/// </summary>
		/// <value>
		/// The training data.
		/// </value>
		[Column("Training")]
		public virtual TrainingDb TrainingData { get; set; }

		/// <summary>
		/// Gets or sets the training.
		/// </summary>
		/// <value>
		/// The training.
		/// </value>
		[NotMapped]
		public ITraining Training
		{
			get { return TrainingData; }
			set { TrainingData = value as TrainingDb; }
		}

		/// <summary>
		/// Gets or sets the user data.
		/// </summary>
		/// <value>
		/// The user data.
		/// </value>
		[InverseProperty("TrainingsHistoryData")]
		public virtual UserProfileDb UserData { get; set; }

		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		[NotMapped]
		public long CreatorId
		{
			get { return UserData.Id; }
		}

		#endregion
	}
}
