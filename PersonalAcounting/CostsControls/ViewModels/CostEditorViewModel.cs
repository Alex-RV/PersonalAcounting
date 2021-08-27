using System;
using System.Collections.Generic;
using System.Text;
using Costs;
using System.Collections.ObjectModel;
using Directory;

namespace CostsControls.ViewModels
{
    public class CostEditorViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private ICosts _cost;
        private string _name;
        private double _amount;
        private DateTime _createdate;
        private ICostsEditor _costEditor;
        WPFHelper.RelayCommand _acceptCommand;
        private ObservableCollection<DirectoryItemCostViewModel> _directoryItems = new ObservableCollection<DirectoryItemCostViewModel>();
        private bool _isNew;
        private DirectoryItemCostViewModel _selectedItem;
        #endregion fields

        #region constructor
        public CostEditorViewModel(ICostsEditor costEditor)
        {
            _costEditor = costEditor;
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Элементы справочника типы расходов
        /// </summary>
        public ObservableCollection<DirectoryItemCostViewModel> DirectoryItems { get { return _directoryItems; } }

        /// <summary>
        /// Выбранный тип расхода
        /// </summary>
        public DirectoryItemCostViewModel SelectedItem
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
        
        public WPFHelper.RelayCommand AcceptCostCommand
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
        /// <param name="сost"></param>
        public void SetEditingCost(ICosts сost)
        {
            _cost = сost;
            Name = _cost.Name;
            Amount = _cost.Amount;
            CreateDate = _cost.CreateDate;

            foreach (DirectoryItemCostViewModel item in _directoryItems)
            {
                if (item.Model == сost.Type)
                {
                    SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// Возвращает редактируемый элемент
        /// </summary>
        /// <returns></returns>
        public ICosts GetEditingItem()
        {
            return _cost;
        }

        /// <summary>
        /// Наполение списка
        /// </summary>
        public void FillDirectioryItems(IEnumerable<IDirectoryItem> items)
        {
            _directoryItems.Add(new DirectoryItemCostViewModel(null));
            foreach (IDirectoryItem item in items)
            {
                _directoryItems.Add(new DirectoryItemCostViewModel(item));
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
            _costEditor.SetName(_cost, _name);
            _costEditor.SetAmount(_cost, _amount);
            _costEditor.SetCreateDate(_cost, _createdate);
            _costEditor.SetType(_cost, _selectedItem.Model);
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
