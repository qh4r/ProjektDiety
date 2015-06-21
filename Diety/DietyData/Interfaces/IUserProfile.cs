using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IUserProfile
    {
        #region Properties

        string UserName{get; set;}
        double Height{get; set;}
        double Weight{get; set;}
        double Bmi{get; set;}
        IEnumerable<IMealHistoryRecord>  PlannedMeals{get; set;}
        IEnumerable<IWeightHistoryRecord> WeightHistory{get; set;}
        IEnumerable<ITrainingHistoryRecord> TrainingsHistory{get; set;}
        IEnumerable<IMealHistoryRecord> MealsHistory { get; set; }

        #endregion
    }
}
