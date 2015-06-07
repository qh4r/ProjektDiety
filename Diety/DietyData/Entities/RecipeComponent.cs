using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class RecipeComponent: IRecipeComponent
    {
        #region Properties

        public IIngrdient Ingredient { get; set; }
        public UnitTypes Unit { get; set; }
        public double Amount { get; set; }

        #endregion
    }
}
