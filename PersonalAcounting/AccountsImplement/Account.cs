using Income;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Account : IAccount
    {
        #region field
        private string _name;
        private string _owner;
        private DateTime _createDate;
        private IIncomeList _incomes;
        #endregion field

        #region constructor
        public Account()
        {
            _createDate = DateTime.Now;
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Название счета
        /// </summary>
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Владелец счета
        /// </summary>
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Дата создания счета
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
        }

        public IIncomeList Incomes
        { 
            get { return _incomes; }
            set { _incomes = value; }
        }

        #endregion properties
    }
}
