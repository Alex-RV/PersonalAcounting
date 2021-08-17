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
        #endregion fields

        #region constructor
        public AccountEditorViewModel(IAccount account)
        {
            _account = account;
            _name = _account.Name;
            _owner = _account.Owner;
        }
        #endregion constructor

        #region properties
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

        #endregion properties
    }
}
