using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    interface IRecipesStorage
    {
        #region Properties

        IEnumerable<IRecipe> Recipes { get; set; }

        #endregion
    }
}
