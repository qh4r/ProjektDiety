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
		public TrainingDb TrainingData { get; set; }

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

		#endregion
	}
}
