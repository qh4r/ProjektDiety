using System.Collections.Generic;
using DietyCommonTypes.Enums;

namespace DietyCommonTypes.Interfaces
{
    public interface IRecipe
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
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
        string Name{get; set; }

		/// <summary>
		/// Gets or sets the components list.
		/// </summary>
		/// <value>
		/// The components list.
		/// </value>
        IEnumerable<IRecipeComponent> ComponentsList {get; set; }

		/// <summary>
		/// Gets or sets the type of the meal.
		/// </summary>
		/// <value>
		/// The type of the meal.
		/// </value>
        MealTypes  MealType{get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
        string Description { get; set; }

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
        byte[] Image { get; set; }

        #endregion
    }
    
}
