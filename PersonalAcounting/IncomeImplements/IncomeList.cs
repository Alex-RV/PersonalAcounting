using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public class IncomeList : Base.BaseList<IIncome>, IIncomeList
    {
        #region fields
        private IncomeAccountShort _short;
        #endregion fields

        #region contructors
        public IncomeList() : base()
        {
            _short = new IncomeAccountShort(this);
        }
        #endregion contructors

        #region properties
        public IncomeAccountShort ShortInfo {  get { return _short; } }
        IIncomeAccountShort IIncomeList.ShortInfo { get { return _short; } }
        #endregion properties
    }
}
