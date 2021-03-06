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
        private Directory.IFactoryDirectory _directoryFabric;
        #endregion fields
        DataLoader.ILoader _loader;
        #region constructor
        public FabricsContainer()
        {
            _accountFabric = new Account.AccountFabric(new Income.IncomeFabric(), new Costs.CostsFabric());
            _directoryFabric = new Directory.FactoryDirectory();
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Счета
        /// </summary>
        public Account.IAccountFabric AccountFabric { get { return _accountFabric; } }

        public Directory.IFactoryDirectory DirectoryFabric { get { return _directoryFabric; } }
        #endregion properties

        public void SetLoader(DataLoader.ILoader loader)
        {
            _loader = loader;
        }

        public void Save()
        {
            _loader.Save();
        }
    }
}
