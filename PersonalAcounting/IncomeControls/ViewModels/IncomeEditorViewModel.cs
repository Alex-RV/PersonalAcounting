using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Income;
using Directory;

namespace IncomeControls.ViewModels
{
    public class IncomeEditorViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private IDirectory _list;
        private IIncome _income;
        private string _name;
        private double _amount;
        private DateTime _createdate;
        private IIncomeEditor _incomeEditor;
        private bool _isNew;
        private ObservableCollection<Directory.IDirectory> _directoryItems = new ObservableCollection<Directory.IDirectory>();
        #endregion fields

        #region constructor
        public IncomeEditorViewModel(IIncomeEditor incomeEditor)
        {
            _incomeEditor = incomeEditor;
        }
        #endregion constructor

        #region properties

        public ObservableCollection<Directory.IDirectory> DirectoryItems { get { return _directoryItems; } }

        /// <summary>
        /// Наполение списка
        /// </summary>
        private void FillItems()
        {
            foreach (IDirectory item in DirectoryItems)
            {
                _directoryItems.Add(item);
                //_directoryItems.Add(new IncomeEditorViewModel(item));
            }
        }

        /// <summary>
        /// Добавление или удаление
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Название дохода
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Сумма дохода
        /// </summary>
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }


        /// <summary>
        /// Дата получения дохода
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {
                if (_createdate != value)
                {
                    _createdate = value;
                    OnPropertyChanged(nameof(CreateDate));
                }
            }
        }



        WPFHelper.RelayCommand _acceptCommand;
        public WPFHelper.RelayCommand AcceptIncomeCommand
        {
            get
            {
                if (_acceptCommand == null)
                {
                    _acceptCommand = new WPFHelper.RelayCommand("", (p) => { Accept(); });
                }
                return _acceptCommand;
            }
        }


        #endregion properties

        #region methods
        /// <summary>
        /// Установка редактируемого дохода
        /// </summary>
        /// <param name="income"></param>
        public void SetEditingIncome(IIncome income)
        {
            _income = income;
            Name = _income.Name;
            Amount = _income.Amount;
            CreateDate = _income.CreateDate;
        }

        /// <summary>
        /// Возвращает редактируемый элемент
        /// </summary>
        /// <returns></returns>
        public IIncome GetEditingItem()
        {
            return _income;
        }

        /// <summary>
        /// Метод выполняющийся при нажатии на кнопку Применить
        /// </summary>
        private void Accept()
        {
            _incomeEditor.SetName(_income, _name);
            _incomeEditor.SetAmount(_income, _amount);
            _incomeEditor.SetCreateDate(_income, _createdate);
            OnEndEditing();
        }
        #endregion

        private void OnEndEditing()
        {
            if (EndEditing != null)
            {
                EndEditing(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Завершено редактирование
        /// </summary>
        public event EventHandler EndEditing;
    }
}
