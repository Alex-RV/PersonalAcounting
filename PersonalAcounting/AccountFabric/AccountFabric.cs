using System;

namespace Account
{
    public class AccountFabric : IAccountFabric
    {
        #region fields
        private Income.IIncomeFabric _incomeFabric;
        private AccountList _list;
        #endregion fields

        #region constructor
        public AccountFabric(Income.IIncomeFabric incomeFabric)
        {
            _incomeFabric = incomeFabric;
        }
        #endregion

        #region metods
        public IAccount CreateNew()
        {
            Account result = new Account();
            result.Incomes = _incomeFabric.CreateNewList();
            return result;
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
            return new AccountEditor(GetAccountList() as AccountList, _incomeFabric);
        }
        #endregion metods

    }
}
