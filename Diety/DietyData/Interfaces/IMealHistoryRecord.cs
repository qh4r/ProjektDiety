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

        DateTime Date { get; set; }
        IRecipe Recipe { get; set; }

        #endregion
    }
}
