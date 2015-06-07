using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyData.Interfaces;

namespace DietyData.Entities
{
    class MealHistoryRecord: IMealHistoryRecord
    {
        #region Properties

        public DateTime Date { get; set; }
        IRecipe Recipe { get; set; }
        bool IsPast { get; set; }


        #endregion
    }
}
