﻿using System.Diagnostics.Eventing.Reader;
using DietyCommonTypes.Enums;

namespace DietyCommonTypes.Interfaces
{
    public interface IRecipeComponent
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
		/// Gets or sets the ingredient.
		/// </summary>
		/// <value>
		/// The ingredient.
		/// </value>
        IIngredient Ingredient { get; set; }

		/// <summary>
		/// Gets or sets the unit.
		/// </summary>
		/// <value>
		/// The unit.
		/// </value>
        UnitTypes Unit { get; set; }

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>
		/// The amount.
		/// </value>
        double Amount { get; set; }

        #endregion
    }
}
