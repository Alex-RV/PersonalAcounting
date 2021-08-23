using System;
using System.Collections.Generic;

namespace DataLoader
{
    /// <summary>
    /// Загрузчик данных
    /// </summary>
    public interface ILoader
    {
        string PathToFile { get; set; }

        IEnumerable<Account.IAccount> LoadAccounts();

        void SaveAccounts(IEnumerable<Account.IAccount> accounts);
    }
}
