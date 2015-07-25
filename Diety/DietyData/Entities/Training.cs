using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
    public class Training : ITraining
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
		/// Gets or sets the sport.
		/// </summary>
		/// <value>
		/// The sport.
		/// </value>
        public SportTypes Sport { get; set; }

		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>
		/// The duration.
		/// </value>
        public TimeSpan Duration { get; set; }

		/// <summary>
		/// Gets or sets the calories burned.
		/// </summary>
		/// <value>
		/// The calories burned.
		/// </value>
        public double CaloriesBurned { get; set; }

        #endregion
    }
}
