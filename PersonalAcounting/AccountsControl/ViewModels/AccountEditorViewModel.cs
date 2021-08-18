using System;
using System.Collections.Generic;
using System.Text;
using Account;

namespace AccountControl.ViewModels
{
    /// <summary>
    /// Редактор счета
    /// </summary>
    public class AccountEditorViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private IAccount _account;
        private string _name;
        private string _owner;
        private IAccountEditor _accountEditor;
        private bool _isNew;
        #endregion fields

        #region constructor
        public AccountEditorViewModel(IAccountEditor accountEditor)
        {
            _accountEditor = accountEditor;
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
        /// Название счета
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
        /// Имя владельца счета
        /// </summary>
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (_owner != value)
                {
                    _owner = value;
                    OnPropertyChanged(nameof(Owner));
                }
            }
        }



        WPFHelper.RelayCommand _acceptCommand;
        public WPFHelper.RelayCommand AcceptCommand
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
        /// Установка редактируемого счета
        /// </summary>
        /// <param name="account"></param>
        public void SetEditingAccount(IAccount account)
        {
            _account = account;
            Name = _account.Name;
            Owner = _account.Owner;
        }

        /// <summary>
        /// Возвращает редактируемый элемент
        /// </summary>
        /// <returns></returns>
        public IAccount GetEditingItem()
        {
            return _account;
        }

        /// <summary>
        /// Метод выполняющийся при нажатии на кнопку Применить
        /// </summary>
        private void Accept()
        {
            _accountEditor.SetName(_account, _name);
            _accountEditor.SetOwner(_account, _owner);
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