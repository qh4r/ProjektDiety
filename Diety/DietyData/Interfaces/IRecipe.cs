using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Entities;

namespace DietyData.Interfaces
{
    public interface IRecipe
    {
        #region Properties

        string Name{get; set; }
        IEnumerable<IRecipeComponent> ComponentsList {get; set; }
        MealTypes  MealType{get; set; }
        string Description { get; set; }
        byte[] Image { get; set; }

        #endregion
    }
    
}
