using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace Income
{
    public class IncomeDirectoryAmount
    {
        #region fields
        private IIncomeList _item;
        #endregion fields

        #region contructors
        public IncomeDirectoryAmount(IIncomeList item)
        {
            _item = item;
        }
        #endregion contructors

        #region properties

        #endregion properties

        #region metods
        private double DirectoryAmount()
        {
            return double.MaxValue;
        }
        #endregion metods

    }
}
