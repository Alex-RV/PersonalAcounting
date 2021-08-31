using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public interface ICostsAccountShort
    {
        double sumMonthCosts { get; }
        double sumYearCosts { get; }
    }
}
