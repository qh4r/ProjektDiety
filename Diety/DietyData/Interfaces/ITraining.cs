using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Entities;


namespace DietyData.Interfaces
{
    public interface ITraining
    {
        #region Properties

        SportTypes Sport { get; set; }
        TimeSpan Duration { get; set; }
        double CaloriesBurned { get; set; }

        #endregion
    }
}
