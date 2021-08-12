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
        #endregion field

        #region properties
        /// <summary>
        /// Название счета
        /// </summary>
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion properties
    }
}
