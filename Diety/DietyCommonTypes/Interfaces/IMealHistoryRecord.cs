using System;

namespace DietyCommonTypes.Interfaces
{
    public interface IMealHistoryRecord
    {
        #region Properties

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
        DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the recipe.
		/// </summary>
		/// <value>
		/// The recipe.
		/// </value>
        IRecipe Recipe { get; set; }

        #endregion
    }
}
