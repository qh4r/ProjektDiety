using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;


namespace Diety.Helpers
{
    public interface IMealDataCalculator
    {
        #region Methods

        double CalculateFats(IRecipe recipe);
        double CalculateFats(IEnumerable<IRecipe> recipe);
        double CalculateProteins(IRecipe recipe);
        double CalculateProteins(IEnumerable<IRecipe> recipe);
        double CalculateCalories(IRecipe recipe);
        double CalculateCalories(IEnumerable<IRecipe> recipe);
        double CalculateCarbohydrates(IRecipe recipe);
        double CalculateCarbohydrates(IEnumerable<IRecipe> recipe);
        
        #endregion
    }
}
