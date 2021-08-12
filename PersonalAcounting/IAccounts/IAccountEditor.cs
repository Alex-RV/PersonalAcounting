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
        
        void SetName(IAccount account, string name)
    }
}
