using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public class CostsAccountShort: ICostsAccountShort
    {
        #region fields
        private ICostsList _item;
        #endregion fields

        #region contructors
        public CostsAccountShort(ICostsList item)
        {
            _item = item;
        }
        #endregion contructors

        #region properties
        public double sumMonthCosts { get { return MonthIncome(); } }
        public double sumYearCosts { get { return YearIncome(); } }
        #endregion  properties

        #region metods
        private double MonthIncome()
        {
            DateTime startInterval = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endInterval = startInterval.AddMonths(1);
            double sum = 0;

            foreach (Costs item in _item.Items)
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

            foreach (Costs item in _item.Items)
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

