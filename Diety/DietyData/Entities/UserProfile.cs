using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class UserProfile: IUserProfile
    {
        #region Properties

        public string UserName {get; set;}
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bmi { get; set; }
        IEnumerable<IMealHistoryRecord> PlannedMeals { get; set; }
        IEnumerable<IWeightHistoryRecord> WeightHistory { get; set; }
        IEnumerable<ITrainingHistoryRecord> TrainingsHistory { get; set; }
        IEnumerable<IMealHistoryRecord> MealsHistory { get; set; }

        #endregion

    }
}
