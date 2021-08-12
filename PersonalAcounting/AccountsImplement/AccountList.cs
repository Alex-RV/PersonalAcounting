using System;
using System.Collections.Generic;

namespace Account
{
    public class AccountList: IAccountList
    {
        #region field
        private List<Account> _items = new List<Account>();
        #endregion field

        #region properties
        public List<Account> Items {  get { return _items; } }
        IEnumerable<IAccount> IAccountList.Items { get { return Items; } }

        #endregion properties
    }
}
