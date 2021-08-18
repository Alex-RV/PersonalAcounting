﻿using System;
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
        //private DateTime _dateNow;
        #endregion field

        public Account()
        {
            _createDate = DateTime.Now;
        }

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

        #endregion properties
    }
}
