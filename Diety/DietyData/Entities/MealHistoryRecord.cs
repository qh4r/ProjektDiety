using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
    public class MealHistoryRecord: IMealHistoryRecord
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
		/// Gets or sets the recipe.
		/// </summary>
		/// <value>
		/// The recipe.
		/// </value>
        public IRecipe Recipe { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is past.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is past; otherwise, <c>false</c>.
		/// </value>
        bool IsPast { get; set; }


        #endregion
    }
}
