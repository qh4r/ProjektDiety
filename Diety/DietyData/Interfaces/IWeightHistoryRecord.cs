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

        DateTime Date{get; set;}
        double Weight{get; set;}

        #endregion
    }
}
