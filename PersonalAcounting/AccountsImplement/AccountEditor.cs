using Income;
using System;
using Costs;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class AccountEditor : IAccountEditor
    {
        #region fields
        private AccountList _list;
        private IIncomeFabric _incomeFabric;
        private ICostsFabric _costsFabric;
        #endregion fields

        #region constructor
        public AccountEditor(AccountList list, IIncomeFabric incomeFabric, ICostsFabric costsFabric)
        {
            _list = list;
            _incomeFabric = incomeFabric;
            _costsFabric = costsFabric;
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
                if(name == null)
                {
                    name = "Не задано значение";
                    correntAccount.Name = name;
                }
                correntAccount.Name = name;
            }
        }


        public void SetOwner(IAccount account, string owner)
        {
            Account correntAccount = account as Account;
            if (correntAccount != null)
            {
                if (owner == null)
                {
                    owner = "Не задано значение";
                    correntAccount.Owner = owner;
                }
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


        public ICostsEditor GetCostsEditor(IAccount account)
        {
            return _costsFabric.GetCostsEditor(account.Costs);
        }

        public ICostsFabric GetCostsFabric()
        {
            return _costsFabric;
        }
    }
        #endregion metods
    
}