using System;

namespace Account
{
    public class AccountFabric : IAccountFabric
    {
        #region fields
        private AccountList _list;
        #endregion fields

        #region metods
        public IAccount CreateNew()
        {
            return new Account();
        }

        public IAccountList GetAccountList()
        {
            if (_list == null)
            {
                _list = new AccountList();
            }
            return _list;
        }

        public IAccountEditor GetEditor()
        {
            return new AccountEditor(GetAccountList() as AccountList);
        }
        #endregion metods

    }
}
