using System;
using System.Collections.Generic;
using System.Text;
using Account;

namespace AccountControl.ViewModels
{
    /// <summary>
    /// Счет
    /// </summary>
    public class AccountViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private IAccount _account;
        private WPFHelper.RelayCommand _exitCommand;
        private WPFHelper.RelayCommand _incomeCommand;
        private WPFHelper.RelayCommand _accountInfoCommand;
        private WPFHelper.RelayCommand _costsCommand;
        private bool _visibleIncomeView = false;
        private bool _visibleShortView = true;
        private IncomeControls.ViewModels.IncomesViewModel _income;
        private AccountControl.ViewModels.AccountViewModel _accountInfo;
        private IAccountEditor _accountEditor;
        #endregion fields

        #region contructor
        public AccountViewModel(IAccount account, IAccountEditor accountEditor)
        {
            _account = account;
            _accountEditor = accountEditor;
        }
        #endregion contructor

        #region properties
        /// <summary>
        /// Название счета
        /// </summary>
        public string Name
        {
            get { return _account.Name; }
        }

        /// <summary>
        /// Владелец
        /// </summary>
        public string Owner
        {
            get { return _account.Owner; }
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate
        {
            get { return _account.CreateDate; }
        }

        /// <summary>
        /// Команда выхода из счета
        /// </summary>
        public WPFHelper.RelayCommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new WPFHelper.RelayCommand("", (p) => 
                    {
                        OnExit();
                    });
                }

                return _exitCommand;
            }
        }


        /// <summary>
        /// Команда входа во вкладку доходы
        /// </summary>
        public WPFHelper.RelayCommand IncomeCommand
        {
            get
            {
                if (_incomeCommand == null)
                {
                    _incomeCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if (Income == null)
                        {
                            Income = new IncomeControls.ViewModels.IncomesViewModel(_account.Incomes, _accountEditor.GetIncomeEditor(_account), _accountEditor.GetIncomeFabric());
                        }
                        VisibleShortView = false;
                        VisibleIncomeView = true;
                    });
                }

                return _incomeCommand;
            }
        }

        /// <summary>
        /// Команда входа во вкладку информация о счете
        /// </summary>
        public WPFHelper.RelayCommand AccountShortCommand
        {
            get
            {
                if (_accountInfoCommand == null)
                {
                    _accountInfoCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                       
                        VisibleShortView = true;
                        VisibleIncomeView = false;
                    });
                }

                return _accountInfoCommand;
            }
        }

        /// <summary>
        /// Видимость стартового окна
        /// </summary>
        public bool VisibleShortView
        {
            get { return _visibleShortView; }
            set
            {
                if (_visibleShortView != value)
                {
                    _visibleShortView = value;
                    OnPropertyChanged(nameof(VisibleShortView));
                }
            }
        }


        /// <summary>
        /// Видимость окна доходов
        /// </summary>
        public bool VisibleIncomeView
        {
            get { return _visibleIncomeView; }
            set
            {
                if (_visibleIncomeView != value)
                {
                    _visibleIncomeView = value;
                    OnPropertyChanged(nameof(VisibleIncomeView));
                }
            }
        }

        public IncomeControls.ViewModels.IncomesViewModel Income
        { 
            get { return _income; }
            set
            {
                if (_income != value)
                {
                    _income = value;
                    OnPropertyChanged(nameof(Income));
                }
            }
        }

        //public AccountControl.ViewModels.AccountViewModel Account
        //{
        //    get { return _accountInfo; }
        //    set
        //    {
        //        if (_accountInfo != value)
        //        {
        //            _accountInfo = value;
        //            OnPropertyChanged(nameof(Account));
        //        }
        //    }
        //}
        #endregion properties

        #region metods
        /// <summary>
        /// Возвращает модель строки - счет
        /// </summary>
        /// <returns></returns>
        public IAccount GetModel()
        {
            return _account;
        }
        #endregion metods

        #region events
        private void OnExit()
        {
            if (Exit != null)
            {
                Exit(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Выполнен выход из счета
        /// </summary>
        public event EventHandler Exit;


        /*private void OnIncome()
        {
            if (Income != null)
            {
                Income(this, EventArgs.Empty);
            }
        }*/


        /// <summary>
        /// Выполнен выход из счета
        /// </summary>
        //public event EventHandler Income;
        #endregion
    }
}
