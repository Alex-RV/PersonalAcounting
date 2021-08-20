using System;

namespace Income
{
    public class IncomeFabric: IIncomeFabric
    {
        #region metods
        public IIncome CreateNew()
        {
            return new Income();
        }

        public IIncomeList CreateNewList()
        {
            return new IncomeList();
        }

        public IIncomeEditor GetIncomeEditor(IIncomeList list)
        {
            return new IncomeEditor(list as IncomeList);
        }
        #endregion
    }
}
