using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IIngrdient
    {
        #region Properties

        string Name { get; set; }
        double Fats { get; set; }
        double Carbohydrates { get; set; }
        double Proteins { get; set; }
        double Calories { get; set; }

        #endregion
    }
}
