using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
    public class Ingredient : IIngredient
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
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the fats.
		/// </summary>
		/// <value>
		/// The fats.
		/// </value>
        public double Fats { get; set; }

		/// <summary>
		/// Gets or sets the carbohydrates.
		/// </summary>
		/// <value>
		/// The carbohydrates.
		/// </value>
        public double Carbohydrates { get; set; }

		/// <summary>
		/// Gets or sets the proteins.
		/// </summary>
		/// <value>
		/// The proteins.
		/// </value>
        public double Proteins { get; set; }

		/// <summary>
		/// Gets or sets the calories.
		/// </summary>
		/// <value>
		/// The calories.
		/// </value>
        public double Calories { get; set; }

        #endregion
    }
}
