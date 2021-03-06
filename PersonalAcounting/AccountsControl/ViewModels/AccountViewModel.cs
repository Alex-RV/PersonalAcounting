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
        private WPFHelper.RelayCommand _costCommand;
        private bool _visibleIncomeView = false;
        private bool _visibleIncomeDirectoryAmountView = false;
        private bool _visibleCostView = false;
        private bool _visibleShortView = true;
        private IncomeControls.ViewModels.IncomesViewModel _income;
        private CostsControls.ViewModels.CostsViewModel _costs;
        private AccountControl.ViewModels.AccountViewModel _accountInfo;
        private IAccountEditor _accountEditor;
        private IEnumerable<Directory.IDirectory> _directories;
        private double _sum;
        #endregion fields

        #region contructor
        public AccountViewModel(IAccount account, IAccountEditor accountEditor, IEnumerable<Directory.IDirectory> directories)
        {
            _account = account;
            _accountEditor = accountEditor;
            _directories = directories;
            //Income.OpenIncomeDirectoryAmount += OnOpenIncomeDirectoryAmount;
        }
        #endregion contructor
        
        public double sumMonthIncome
        {
            get { return _account.Incomes.ShortInfo.sumMonthIncome; }
        }

        public double sumYearIncome
        {
            get { return _account.Incomes.ShortInfo.sumYearIncome; }
        }

        public double sumMonthCosts
        {
            get { return _account.Costs.ShortInfo.sumMonthCosts; }
        }

        public double sumYearCosts
        {
            get { return _account.Costs.ShortInfo.sumYearCosts; }
        }
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
                            Directory.IDirectory incomeTypes = null;  
                            foreach (var item in _directories)
                            {
                                if (item.Name == Directory.Properties.Resources.IncomeType)
                                {
                                    incomeTypes = item;
                                }
                            }
                            Income = new IncomeControls.ViewModels.IncomesViewModel(_account.Incomes, _accountEditor.GetIncomeEditor(_account), _accountEditor.GetIncomeFabric(), incomeTypes);
                        }
                        VisibleShortView = false;
                        VisibleIncomeView = true;
                        VisibleCostView = false;
                    });
                }

                return _incomeCommand;
            }
        }

        /// <summary>
        /// Команда входа во вкладку расходы
        /// </summary>
        public WPFHelper.RelayCommand CostsCommand
        {
            get
            {
                if (_costCommand == null)
                {
                    _costCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if (Costs == null)
                        {
                            Directory.IDirectory costsTypes = null;
                            foreach (var item in _directories)
                            {
                                if (item.Name == Directory.Properties.Resources.CostsType)
                                {
                                    costsTypes = item;
                                }
                            }
                            Costs = new CostsControls.ViewModels.CostsViewModel(_account.Costs, _accountEditor.GetCostsEditor(_account), _accountEditor.GetCostsFabric(), costsTypes);
                        }
                        VisibleShortView = false;
                        VisibleIncomeView = false;
                        VisibleCostView = true;
                    });
                }

                return _costCommand;
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
                        VisibleCostView = false;
                        Income.OpenIncomeDirectoryAmount += OnOpenIncomeDirectoryAmount;
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

        /// <summary>
        /// Видимость окна суммы по категориям доходов
        /// </summary>
        public bool VisibleIncomeDirectoryAmountView
        {
            get { return _visibleIncomeDirectoryAmountView; }
            set
            {
                if (_visibleIncomeDirectoryAmountView != value)
                {
                    _visibleIncomeDirectoryAmountView = value;
                    OnPropertyChanged(nameof(VisibleIncomeDirectoryAmountView));
                }
            }
        }

        /// <summary>
        /// Видимость окна расходов
        /// </summary>
        public bool VisibleCostView
        {
            get { return _visibleCostView; }
            set
            {
                if (_visibleCostView != value)
                {
                    _visibleCostView = value;
                    OnPropertyChanged(nameof(VisibleCostView));
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

        public CostsControls.ViewModels.CostsViewModel Costs
        {
            get { return _costs; }
            set
            {
                if (_costs != value)
                {
                    _costs = value;
                    OnPropertyChanged(nameof(Costs));
                }
            }
        }

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

        /// <summary>
        /// обработчик события нажатия на кнопку открытие суммы по категориям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenIncomeDirectoryAmount(object sender, EventArgs e)
        {
            VisibleIncomeView = true;
        }


        #endregion
    }
}
