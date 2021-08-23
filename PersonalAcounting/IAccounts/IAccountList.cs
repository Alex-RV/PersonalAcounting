using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public interface IAccountList
    {
        
        IEnumerable<IAccount> Items { get; } 
    }
}
