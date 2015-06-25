using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    public class Ingredient : IIngrdient
    {
        #region Properties

        public string Name { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Calories { get; set; }

        #endregion
    }
}
