using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class Training : ITraining
    {
        #region Properties

        public SportTypes Sport { get; set; }
        public TimeSpan Duration { get; set; }
        double CaloriesBurned { get; set; }

        #endregion
    }
}
