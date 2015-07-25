using System;

namespace DietyCommonTypes.Interfaces
{
    public interface IWeightHistoryRecord
    {
        #region Properties

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
        DateTime Date{get; set;}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
        double Weight{get; set;}

        #endregion
    }
}
