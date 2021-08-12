using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class AccountEditor : IAccountEditor
    {
        #region fields
        private AccountList _list;
        #endregion fields

        #region constructor
        public AccountEditor(AccountList list)
        {
            _list = list;
        }
        #endregion
        #region metods
        public void Add(IAccount addAcount)
        {
            Account addItem = addAcount as Account;
            if (addItem != null)
            {
                _list.Items.Add(addItem);
            }
        }

        public void SetName(IAccount account, string name)
        {
            Account correntAccount = account as Account;
            if (correntAccount != null)
            {
                correntAccount.Name = name;
            }
        }
        #endregion metods
    }
}
