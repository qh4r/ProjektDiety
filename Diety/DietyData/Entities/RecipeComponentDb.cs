using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("RecipeComponents")]
	public class RecipeComponentDb : IRecipeComponentData
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
		/// Gets or sets the ingredient data.
		/// </summary>
		/// <value>
		/// The ingredient data.
		/// </value>
		[Column("Ingredient")]
		[InverseProperty("Recipes")]
		public virtual IngredientDb IngredientData { get; set; }

		/// <summary>
		/// Gets or sets the ingredient.
		/// </summary>
		/// <value>
		/// The ingredient.
		/// </value>
		[NotMapped]
		public IIngredient Ingredient
		{
			get { return IngredientData; }
			set { IngredientData = value as IngredientDb; }
		}

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

		/// <summary>
		/// Gets or sets the recipes.
		/// </summary>
		/// <value>
		/// The recipes.
		/// </value>
		//public virtual ICollection<RecipeDb> Recipes { get; set; }

		#endregion
	}
}
