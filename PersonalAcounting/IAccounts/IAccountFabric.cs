using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    /// <summary>
    /// Фабрика для счетов
    /// </summary>
    public interface IAccountFabric
    {
        IAccount CreateNew();

        IAccountList GetAccountList();

        IAccountEditor GetEditor();
    }
}
