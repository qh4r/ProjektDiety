using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class TrainingHistoryRecord : ITrainingHistoryRecord
    {
        #region Properties

        public DateTime Date { get; set; }
        public ITraining Training { get; set; }

        #endregion
    }
}
