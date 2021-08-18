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
    }
}
