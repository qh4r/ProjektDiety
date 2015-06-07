using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    interface IWeightHistoryRecord
    {
        #region Properties

        public DateTime Date{get; set;}
        public double Weight{get; set;}

        #endregion
    }
}
