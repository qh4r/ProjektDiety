using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface ITraining
    {
        #region Properties

        public SportTypes Sport { get; set; }
        public Timespan Duration { get; set; }
        public double CaloriesBurned { get; set; }

        #endregion
    }
}
