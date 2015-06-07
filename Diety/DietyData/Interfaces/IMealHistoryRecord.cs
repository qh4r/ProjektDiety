using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietyData.Interfaces
{
    public interface IMealHistoryRecord
    {
        #region Properties

        public DateTime Date { get; set; }
        public IRecipe Recipe { get; set; }

        #endregion
    }
}
