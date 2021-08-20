using Income;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class AccountEditor : IAccountEditor
    {
        #region fields
        private AccountList _list;
        private IIncomeFabric _incomeFabric;
        #endregion fields

        #region constructor
        public AccountEditor(AccountList list, IIncomeFabric incomeFabric)
        {
            _list = list;
            _incomeFabric = incomeFabric;
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


        public void SetOwner(IAccount account, string owner)
        {
            Account correntAccount = account as Account;
            if (correntAccount != null)
            {
                correntAccount.Owner = owner;
            }
        }

        public void SetCreateDate(IAccount account, DateTime createdate)
        {
            Account correntAccount = account as Account;
            if (correntAccount != null)
            {

            }
        }

        public void Remove(IAccount deleteItem)
        {
            Account deleteI = deleteItem as Account;
            if (deleteI != null)
            { 
                _list.Items.Remove(deleteI);
            }
        }

        public IIncomeEditor GetIncomeEditor(IAccount account)
        {
            return _incomeFabric.GetIncomeEditor(account.Incomes);
        }

        public IIncomeFabric GetIncomeFabric()
        {
            return _incomeFabric;
        }
    }
        #endregion metods
    
}