using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class Recipe : IRecipe
    {
        #region Properties

        public string Name { get; set; }
        public IEnumerable<IRecipeComponent> ComponentsList { get; set; }
        public MealTypes MealType { get; set; }
        public string Description { get; set; }
        public byte[] Image {get; set;}

        #endregion
    }
}
