using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalAcounting
{
    /// <summary>
    /// Коллекция фабричных элементов
    /// </summary>
    internal class FabricsContainer
    {
        #region fields
        private Account.IAccountFabric _accountFabric;
        #endregion fields

        #region constructor
        public FabricsContainer()
        {
            _accountFabric = new Account.AccountFabric(new Income.IncomeFabric(), new Costs.CostsFabric());
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Счета
        /// </summary>
        public Account.IAccountFabric AccountFabric { get { return _accountFabric; } }
        #endregion properties
    }
}
