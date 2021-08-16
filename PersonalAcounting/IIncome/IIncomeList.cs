using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public interface IIncomeList
    {
        IEnumerable<IIncome> Items { get; }
    }
}
