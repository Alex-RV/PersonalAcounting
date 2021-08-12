using System;
using System.Collections.Generic;
using System.Data;
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
        /// дата или время создания счета
        /// </summary>
        double CreateDate { get; }
        //возожно нужно использовать DataTime или String


        //TODO: добавить свойства 
        //Owner
        //CreateDate
    }
}
