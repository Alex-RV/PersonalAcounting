using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    /// <summary>
    /// редактор доходов
    /// </summary>
    public interface IIncomeEditor
    {
        /// <summary>
        /// добавление счета
        /// </summary>
        /// <param name="AddIncome"></param>
        void Add(IIncome AddIncome);

        /// <summary>
        /// удаление дохода
        /// </summary>
        void Remove(IIncome DeleteIncome);

        /// <summary>
        /// редактирование имени
        /// </summary>
        void SetName(IIncome income, string name);

        /// <summary>
        /// редактирование суммы дохода
        /// </summary>
        void SetAmount(IIncome income, double amount);

        /// <summary>
        /// добавление даты получения дохода
        /// </summary>
        void SetCreateDate(IIncome income, DateTime createdate);
    }
}
