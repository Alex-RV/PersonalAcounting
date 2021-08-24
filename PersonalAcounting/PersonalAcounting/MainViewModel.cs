using System;
using System.Collections.Generic;
using System.Text;
using AccountControl.ViewModels;
using Directory;

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
        private bool _visibleDirectory = false;
        private bool _visibleButtonOpenDirectory = true;
        private WPFHelper.RelayCommand _openDirectoryCommand;
        private DirectoryControl.ViewModels.DirectoriesViewModel _directory;
        #endregion fields
        DataLoader.Loader loader;
        #region constructor
        public MainViewModel()
        {
            loader = new DataLoader.Loader();
            loader.PathToFile = "C:\\Users\\alexs\\Documents\\test.ff";

            _fabricsContainer = new FabricsContainer(loader);

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
        /// Команда для кнопки настройки счета
        /// </summary>
        public WPFHelper.RelayCommand OpenDirectoryCommand
        {
            get
            {
                if (_openDirectoryCommand == null)
                {
                    _openDirectoryCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleAccounts = false;
                        VisibleAccount = false;
                        VisibleDirectory = true;
                        VisibleButtonOpenDirectory = false;
                    });
                }
                return _openDirectoryCommand;
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
        /// Справочники
        /// </summary>
        public DirectoryControl.ViewModels.DirectoriesViewModel Directory
        {
            get 
            {
                if (_directory == null)
                {
                    InitlizeDirectories();
                }
                return _directory; }
            set
            {
                if (_directory != value)
                {
                    VisibleButtonOpenDirectory = false;
                    _directory = value;
                    OnPropertyChanged(nameof(Directory));
                }
            }
        }

        /// <summary>
        /// Видимость директории
        /// </summary>
        public bool VisibleDirectory
        {
            get { return _visibleDirectory; }
            set
            {
                if (_visibleDirectory != value)
                {
                    _visibleDirectory = value;
                    OnPropertyChanged(nameof(VisibleDirectory));
                }
            }
        }

        /// <summary>
        /// Видимость кнопки для открытия директории
        /// </summary>
        public bool VisibleButtonOpenDirectory
        {
            get { return _visibleButtonOpenDirectory; }
            set
            {
                if (_visibleButtonOpenDirectory != value)
                {
                    _visibleButtonOpenDirectory = value;
                    OnPropertyChanged(nameof(VisibleButtonOpenDirectory));
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

        private void InitlizeDirectories()
        {
            Directory = new DirectoryControl.ViewModels.DirectoriesViewModel(_fabricsContainer.DirectoryFabric.GetDirectories(), _fabricsContainer.DirectoryFabric.GetEditorDirectory(), _fabricsContainer.DirectoryFabric);
        }


        public void Closing()
        {
            _fabricsContainer.Save();
            
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
