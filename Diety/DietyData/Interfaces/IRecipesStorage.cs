using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IRecipesStorage
    {
        #region Properties

		/// <summary>
		/// Gets or sets the recipes.
		/// </summary>
		/// <value>
		/// The recipes.
		/// </value>
        IEnumerable<IRecipe> Recipes { get; set; }

        #endregion
    }
}
