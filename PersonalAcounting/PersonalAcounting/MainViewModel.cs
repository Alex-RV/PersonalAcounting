using System;
using System.Collections.Generic;
using System.Text;
using AccountControl.ViewModels;

namespace PersonalAcounting
{
    /// <summary>
    /// Главное окно
    /// </summary>
    public class MainViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private FabricsContainer _fabricsContainer;
        private AccountsViewModel _accounts;
        #endregion fields

        #region constructor
        public MainViewModel()
        {
            _fabricsContainer = new FabricsContainer();

            InitializeAccouts();
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Счета
        /// </summary>
        public AccountsViewModel Accounts
        {
            get { return _accounts; }
            set
            {
                if (_accounts != value)
                {
                    _accounts = value;
                    OnPropertyChanged(nameof(Accounts));
                }
            }
        }
        #endregion properties

        #region metods
        /// <summary>
        /// Создание списка счетов
        /// </summary>
        private void InitializeAccouts()
        {
            Accounts = new AccountsViewModel(
                _fabricsContainer.AccountFabric.GetAccountList(),
                _fabricsContainer.AccountFabric.GetEditor(),
                _fabricsContainer.AccountFabric);
        }
        #endregion metods
    }
}
