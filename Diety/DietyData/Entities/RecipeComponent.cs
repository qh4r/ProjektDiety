using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
	public class RecipeComponent : IRecipeComponent
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
		/// Gets or sets the ingredient.
		/// </summary>
		/// <value>
		/// The ingredient.
		/// </value>
        public IIngredient Ingredient { get; set; }

		/// <summary>
		/// Gets or sets the unit.
		/// </summary>
		/// <value>
		/// The unit.
		/// </value>
        public UnitTypes Unit { get; set; }

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>
		/// The amount.
		/// </value>
        public double Amount { get; set; }

        #endregion
    }
}
