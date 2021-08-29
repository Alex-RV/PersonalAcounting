using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    /// <summary>
    /// редактор доходов или расходов
    /// </summary>
    public interface IBaseEditor<T> where T : IBase
    {
        /// <summary>
        /// добавление дохода или расхода
        /// </summary>
        /// <param name="AddBase"></param>
        void Add(T AddBase);

        /// <summary>
        /// удаление дохода или расхода
        /// </summary>
        void Remove(T DeleteBase);

        /// <summary>
        /// редактирование имени дохода или расхода
        /// </summary>
        void SetName(T changeItem, string name);

        /// <summary>
        /// редактирование комментария дохода или расхода
        /// </summary>
        void SetComment(T changeItem, string comment);

        /// <summary>
        /// редактирование суммы дохода
        /// </summary>
        void SetAmount(T changeItem, double amount);

        /// <summary>
        /// добавление даты получения дохода или расхода
        /// </summary>
        void SetCreateDate(T changeItem, DateTime createdate);

        /// <summary>
        /// Установить тип
        /// </summary>
        /// <param name="changeItem"></param>
        /// <param name="type"></param>
        void SetType(T changeItem, Directory.IDirectoryItem type);
    }
}
