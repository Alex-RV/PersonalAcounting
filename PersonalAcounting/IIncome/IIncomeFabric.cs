using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public interface IIncomeFabric
    {
        #region metods
        IIncome CreateNew();

        IIncomeList CreateNewList();

        IIncomeEditor GetIncomeEditor(IIncomeList list);
        #endregion
    }
}
