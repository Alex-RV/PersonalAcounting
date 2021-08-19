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
        #endregion fields

        #region contructor
        public AccountViewModel(IAccount account)
        {
            _account = account;
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
        #endregion
    }
}
