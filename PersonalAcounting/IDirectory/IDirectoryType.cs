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
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }
    }
}
