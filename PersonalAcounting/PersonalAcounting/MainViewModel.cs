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
        private bool _visibleAccounts = false;
        private bool _visibleAccount = false;
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

        /// <summary>
        /// Видимость списка счетов
        /// </summary>
        public bool VisibleAccounts
        {
            get { return _visibleAccounts; }
            set
            {
                if (_visibleAccounts != value)
                {
                    _visibleAccounts = value;
                    OnPropertyChanged(nameof(VisibleAccounts));
                }
            }
        }
        
        /// <summary>
        /// Видимость счета
        /// </summary>
        public bool VisibleAccount
        {
            get { return _visibleAccount; }
            set
            {
                if (_visibleAccount != value)
                {
                    _visibleAccount = value;
                    OnPropertyChanged(nameof(VisibleAccount));
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
            VisibleAccounts = true;
            Accounts.ChangedActivAcount += Accounts_ChangedActivAcount;
        }

        #endregion metods

        #region event handlers
        private void Accounts_ChangedActivAcount(object sender, EventArgs e)
        {
            VisibleAccounts = false;
            VisibleAccount = true;
            Accounts.SelectedItem.Exit += Account_Exit;
        }

        private void Account_Exit(object sender, EventArgs e)
        {
            VisibleAccount = false;
            VisibleAccounts = true;
            Accounts.SelectedItem.Exit -= Account_Exit;
        }
        #endregion event handlers
    }
}
