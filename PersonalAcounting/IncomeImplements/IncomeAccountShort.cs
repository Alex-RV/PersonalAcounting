using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace Income
{
    public class IncomeAccountShort : IIncomeAccountShort
    {

        #region fields
        private IIncomeList _item;
        #endregion fields

        #region contructors
        public IncomeAccountShort(IIncomeList item)
        {
            _item = item;
        }
        #endregion contructors

        #region properties
        public double sumMonthIncome { get { return MonthIncome(); } }
        public double sumYearIncome { get { return YearIncome(); } }
        #endregion  properties

        #region metods
        private double MonthIncome()
        {
            DateTime startInterval = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endInterval = startInterval.AddMonths(1);
            double sum = 0;

            foreach (Income item in _item.Items)
            {
                if (startInterval <= item.CreateDate && item.CreateDate <= endInterval)
                {
                    sum += item.Amount;
                }
            }
            return sum;
        }

        private double YearIncome()
        {
            DateTime startInterval = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endInterval = startInterval.AddYears(1);
            double sum = 0;

            foreach (Income item in _item.Items)
            {
                if (startInterval <= item.CreateDate && item.CreateDate <= endInterval)
                {
                    sum += item.Amount;
                }
            }
            return sum;
        }
        #endregion metods
    }
}
