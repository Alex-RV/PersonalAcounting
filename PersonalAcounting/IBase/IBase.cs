using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public interface IBase
    {
        ///<summary>
        ///наименование дохода или расхода 
        ///</summary>
        string Name { get; }

        ///<summary>
        ///сумма дохода или расхода
        ///</summary>
        double Amount { get; }

        ///<summary>
        ///дата дохода или расхода
        ///</summary>
        DateTime CreateDate { get; }

        /// <summary>
        /// Тип элемнеты
        /// </summary>
        Directory.IDirectoryItem Type { get; } 
    }
}
