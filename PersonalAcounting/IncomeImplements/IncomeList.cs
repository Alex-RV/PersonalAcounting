using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public class IncomeList : IIncomeList
    {
        #region field
        private List<Income> _items = new List<Income>();
        #endregion field

        #region properties
        public List<Income> Items { get { return _items; } }
        IEnumerable<IIncome> IIncomeList.Items { get { return Items; } }

        #endregion properties
    }
}
