using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    interface IUserProfile
    {
        #region Properties

        public string UserName{get; set;}
        public double Height{get; set;}
        public double Weight{get; set;}
        public double Bmi{get; set;}
        public IEnumerable<IMealHistoryRecord>  PlannedMeals{get; set;}
        public IEnumerable<IWeightHistoryRecord> WeightHistory{get; set;}
        public IEnumerable<ITrainingHistoryRecord> TrainingsHistory{get; set;}
        public IEnumerable<IMealHistoryRecord> MealsHistory { get; set; }

        #endregion
    }
}
