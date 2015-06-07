using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class RecipeStorage: IRecipesStorage
    {
        #region Properties

        public IEnumerable<IRecipe> Recipes { get; set; }

        #endregion

    }
}
