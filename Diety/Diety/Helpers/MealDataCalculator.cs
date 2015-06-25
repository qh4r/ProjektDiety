using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;


namespace Diety.Helpers
{
    class MealDataCalculator : IMealDataCalculator
    {
        public double CalculateFats(IRecipe recipe)
        {
            double fats;
            fats=0;

            foreach (IRecipeComponent element in recipe.ComponentsList)
            {
                fats += element.Amount * element.Ingredient.Fats;
            }
            return fats;
        }


        public double CalculateFats(IEnumerable<IRecipe> recipes)
        {

            double fats;
            fats = 0;

            foreach (IRecipe element in recipes )
            {
                fats += CalculateFats(element);
            }
            return fats;
        }


        public double CalculateProteins(IRecipe recipe)
        {
            double proteins;
            proteins = 0;

            foreach (IRecipeComponent element in recipe.ComponentsList)
            {
                proteins += element.Amount * element.Ingredient.Proteins;
            }
            return proteins;
        }

        public double CalculateProteins(IEnumerable<IRecipe> recipes)
        {

            double proteins;
            proteins = 0;

            foreach (IRecipe element in recipes)
            {
                proteins += CalculateProteins(element);
            }
            return proteins;
        }


        public double CalculateCalories(IRecipe recipe)
        {
            double calories;
            calories = 0;

            foreach (IRecipeComponent element in recipe.ComponentsList)
            {
                calories += element.Amount * element.Ingredient.Calories;
            }
            return calories;
        }

        public double CalculateCalories(IEnumerable<IRecipe> recipes)
        {
            double calories;
            calories = 0;

            foreach (IRecipe element in recipes)
            {
                calories += CalculateCalories(element);
            }
            return calories;
        }


        public double CalculateCarbohydrates(IRecipe recipe)
        {
            double carbohydrates;
            carbohydrates = 0;

            foreach (IRecipeComponent element in recipe.ComponentsList)
            {
                carbohydrates += element.Amount * element.Ingredient.Carbohydrates;
            }
            return carbohydrates;
        }

        public double CalculateCarbohydrates(IEnumerable<IRecipe> recipes)
        {
            double carbohydrates;
            carbohydrates = 0;

            foreach (IRecipe element in recipes)
            {
                carbohydrates += CalculateCarbohydrates(element);
            }
            return carbohydrates;
        }
    }
}
