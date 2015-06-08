using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class WeightHistoryRecord: IWeightHistoryRecord
    {

        #region Properties

        public DateTime Date{get; set;}
        public double Weight{get; set;}

        #endregion
    }
}
