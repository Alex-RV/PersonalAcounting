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

        //TODO: добавить свойства 
        //Owner
        //CreateDate
    }
}
