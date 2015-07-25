using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
    public class TrainingHistoryRecord : ITrainingHistoryRecord
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
		/// Gets or sets the training.
		/// </summary>
		/// <value>
		/// The training.
		/// </value>
        public ITraining Training { get; set; }

        #endregion
    }
}
