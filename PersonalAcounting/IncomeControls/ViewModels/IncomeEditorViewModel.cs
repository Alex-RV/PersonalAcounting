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
        private IIncome _income;
        private string _name;
        private string _comment;
        private double _amount;
        private DateTime _createdate;
        private IIncomeEditor _incomeEditor;
        WPFHelper.RelayCommand _acceptCommand;
        WPFHelper.RelayCommand _cancelCommand;
        private bool _isNew;
        private ObservableCollection<DirectoryItemViewModel> _directoryItems = new ObservableCollection<DirectoryItemViewModel>();
        private DirectoryItemViewModel _selectedItem;
        #endregion fields

        #region constructor
        public IncomeEditorViewModel(IIncomeEditor incomeEditor)
        {
            _incomeEditor = incomeEditor;
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Элементы справочника типы дохода
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> DirectoryItems { get { return _directoryItems; } }

        /// <summary>
        /// Выбранный тип дохода
        /// </summary>
        public DirectoryItemViewModel SelectedItem 
        { 
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
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
        /// Название дохода
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
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


        /// <summary>
        /// Действие при нажатии на кнопку применить
        /// </summary> 
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

        /// <summary>
        /// Действие при нажатии на кнопку Отмена
        /// </summary>
        public WPFHelper.RelayCommand CancelIncomeCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        OnCancelEditor();
                    });
                }
                return _cancelCommand;
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
            Comment = _income.Comment;
            Amount = _income.Amount;
            CreateDate = _income.CreateDate;

            foreach (DirectoryItemViewModel item in _directoryItems)
            {
                if (item.Model == income.Type)
                {
                    SelectedItem = item;
                }
            }
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
        /// Наполение списка
        /// </summary>
        public void FillDirectioryItems(IEnumerable<IDirectoryItem> items)
        {
            _directoryItems.Add(new DirectoryItemViewModel( null));
            foreach (IDirectoryItem item in items)
            {
                _directoryItems.Add(new DirectoryItemViewModel(item));
            }
        }

        /// <summary>
        /// Метод выполняющийся при нажатии на кнопку Применить
        /// </summary>
        private void Accept()
        {
            if (CheckCorrectValues() == false)
            {
                return;
            }
            _incomeEditor.SetName(_income, _name);
            _incomeEditor.SetComment(_income, _comment);
            _incomeEditor.SetAmount(_income, _amount);
            _incomeEditor.SetCreateDate(_income, _createdate);
            _incomeEditor.SetType(_income, _selectedItem.Model);
            OnEndEditing();
        }


        /// <summary>
        /// Проверка формы на кооретность ввода данных
        /// </summary>
        /// <returns></returns>
        private bool CheckCorrectValues()
        {
            if ((_name == null || _name == "") ||
               _selectedItem.Model == null)
            {
                System.Windows.MessageBox.Show(Properties.Resources.IncorectData, Properties.Resources.Error, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region events
        private void OnEndEditing()
        {
            if (EndEditing != null)
            {
                EndEditing(this, EventArgs.Empty);
            }
        }

        private void OnCancelEditor()
        {
            if (CancelEditor != null)
            {
                CancelEditor(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Завершено редактирование
        /// </summary>
        public event EventHandler EndEditing;

        /// <summary>
        /// Кнопка отмена
        /// </summary>
        public event EventHandler CancelEditor;
        #endregion events
    }
}
