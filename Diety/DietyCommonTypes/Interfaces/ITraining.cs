using System;
using DietyCommonTypes.Enums;

namespace DietyCommonTypes.Interfaces
{
    public interface ITraining
    {
        #region Properties

		/// <summary>
		/// Gets or sets the sport.
		/// </summary>
		/// <value>
		/// The sport.
		/// </value>
        SportTypes Sport { get; set; }

		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>
		/// The duration.
		/// </value>
        TimeSpan Duration { get; set; }

		/// <summary>
		/// Gets or sets the calories burned.
		/// </summary>
		/// <value>
		/// The calories burned.
		/// </value>
        double CaloriesBurned { get; set; }

        #endregion
    }
}
