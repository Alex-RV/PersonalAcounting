using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    /// <summary>
    /// Тип справочника
    /// </summary>
    public interface IDirectoryType
    {
        int ID { get; }

        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }
    }
}
