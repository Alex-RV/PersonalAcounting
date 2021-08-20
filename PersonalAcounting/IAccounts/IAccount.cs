using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    /// <summary>
    /// счет
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// название счета
        /// </summary>
        string Name { get; }


        /// <summary>
        /// название владельца счета
        /// </summary>
        string Owner { get; }


        /// <summary>
        /// дата время создания счета
        /// </summary>
        DateTime CreateDate { get; }

        /// <summary>
        /// Доходы
        /// </summary>
        Income.IIncomeList Incomes { get; }

    }
}
