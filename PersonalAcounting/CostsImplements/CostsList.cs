using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public class CostsList : Base.BaseList<ICosts>, ICostsList
    {
        #region fields
        private CostsAccountShort _short;
        #endregion fields

        #region contructors
        public CostsList() : base()
        {
            _short = new CostsAccountShort(this);
        }
        #endregion contructors

        #region properties
        public CostsAccountShort ShortInfo { get { return _short; } }
        ICostsAccountShort ICostsList.ShortInfo { get { return _short; } }
        #endregion properties
    }
}
