using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Entities;

namespace DietyData.Interfaces
{
    public interface IRecipeComponent
    {
        #region Properties

        IIngrdient Ingredient { get; set; }
        UnitTypes Unit { get; set; }
        double Amount { get; set; }

        #endregion
    }
}
