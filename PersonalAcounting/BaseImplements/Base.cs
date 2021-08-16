﻿using System;

namespace Base
{
    /// <summary>
    /// Основны
    /// </summary>
    public abstract class Base : IBase
    {
        #region field
        private string _name;
        private double _amount;
        private DateTime _createdate;
        #endregion field

        #region properties
        ///<summary>
        ///Название дохода или расхода
        ///</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        ///<summary>
        ///Сумма дохода или расхода
        ///</summary>
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        ///<summary>
        ///Дата получения дохода или расхода
        ///</summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        #endregion properties
    }
}

