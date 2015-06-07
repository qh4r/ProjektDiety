using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IRecipeComponent
    {
        #region Properties

        public IIngrdient Ingredient { get; set; }
        public UnitTypes Unit { get; set; }
        public double Amount { get; set; }

        #endregion
    }
}
