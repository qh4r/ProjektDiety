using System;

namespace DietyCommonTypes.Interfaces
{
    public interface ITrainingHistoryRecord
    {
        #region Properties

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		long Id { get; }

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
        DateTime Date{get; set;}

		/// <summary>
		/// Gets or sets the training.
		/// </summary>
		/// <value>
		/// The training.
		/// </value>
        ITraining Training { get; set; }

		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		long CreatorId { get; }
        #endregion
    }
}
