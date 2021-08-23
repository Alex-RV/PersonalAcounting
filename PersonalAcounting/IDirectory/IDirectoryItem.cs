using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    /// <summary>
    /// Элемент справочника
    /// </summary>
    public interface IDirectoryItem
    {
        /// <summary>
        /// Идентификтор
        /// </summary>
        int ID { get;  }

        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Тип справочника
        /// </summary>
        IDirectoryType DirectoryType { get; }
    }
}
