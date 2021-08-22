using System;
using System.Collections.Generic;
using System.Text;
using Costs;

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
        private bool _isNew;
        #endregion fields

        #region constructor
        public CostEditorViewModel(ICostsEditor costEditor)
        {
            _costEditor = costEditor;
        }
        #endregion constructor

        #region properties
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
        /// <param name="Cost"></param>
        public void SetEditingCost(ICosts Cost)
        {
            _cost = Cost;
            Name = _cost.Name;
            Amount = _cost.Amount;
            CreateDate = _cost.CreateDate;
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
        /// Метод выполняющийся при нажатии на кнопку Применить
        /// </summary>
        private void Accept()
        {
            _costEditor.SetName(_cost, _name);
            _costEditor.SetAmount(_cost, _amount);
            _costEditor.SetCreateDate(_cost, _createdate);
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
