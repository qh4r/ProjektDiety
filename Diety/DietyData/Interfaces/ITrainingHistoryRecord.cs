using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface ITrainingHistoryRecord
    {
        #region Properties

        DateTime Date{get; set;}
        ITraining Training { get; set; }

        #endregion
    }
}
