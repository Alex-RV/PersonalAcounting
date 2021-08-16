using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    /// <summary>
    /// Доходы
    /// </summary>
    public class Income : IIncome
    {
        #region field
        private string _name;
        private double _amount;
        private DateTime _createdate;
        #endregion field

        #region properties
        ///<summary>
        ///Название дохода
        ///</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        ///<summary>
        ///Сумма дохода
        ///</summary>
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        ///<summary>
        ///Дата получения дохода
        ///</summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        #endregion properties
    }

    /*public interface IIncome
    {
        ///<summary>
        ///наименование дохода
        ///</summary>
        string Name { get; }

        ///<summary>
        ///сумма дохода
        ///</summary>
        double Amount { get; }

        ///<summary>
        ///дата получения дохода
        ///</summary>
        DateTime CreateDate { get; }
    }*/
}
