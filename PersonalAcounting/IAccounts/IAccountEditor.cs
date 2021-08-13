using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    /// <summary>
    /// редактор списка счетов
    /// </summary>
    public interface IAccountEditor
    {
        /// <summary>
        /// добавление счета
        /// </summary>
        /// <param name="AddAccount"></param>
        void Add(IAccount AddAccount);


        /// <summary>
        /// удаление аккаунта
        /// </summary>
        void Remove(IAccount DeleteAccount);

        /// <summary>
        /// редактирование имени
        /// </summary>
        void SetName(IAccount account, string name);

        /// <summary>
        /// редактирование владельца
        /// </summary>
        void SetOwner(IAccount account, string owner);

        /// <summary>
        /// добавление даты создания счета
        /// </summary>
        void SetCreateDate(IAccount account, DateTime createdate);
    }
}
