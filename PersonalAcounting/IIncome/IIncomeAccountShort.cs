using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public interface IIncomeAccountShort
    {
        double sumMonthIncome { get; }
        double sumYearIncome { get; }
    }
}
