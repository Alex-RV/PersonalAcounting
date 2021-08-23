using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    /// <summary>
    /// Справочник
    /// </summary>
    public interface IDirectory
    {
        ///<summary>
        /// Идентификатор справочника
        ///</summary>
        int ID { get; }

        ///<summary>
        /// Имя справочника
        ///</summary>
        string Name { get; }

        ///<summary>
        ///Тип справочника
        ///</summary>
        IDirectoryType Type { get; }

        /// <summary>
        /// Элементы
        /// </summary>
        IEnumerable<IDirectoryItem> Items { get; }
    }
}
