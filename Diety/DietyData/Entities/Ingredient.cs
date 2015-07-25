using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    public class Ingredient : IIngrdient
    {
        #region Properties

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
