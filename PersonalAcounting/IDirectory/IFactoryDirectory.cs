using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public interface IFactoryDirectory
    {
        /// <summary>
        /// Возвращает справочники
        /// </summary>
        IEnumerable<IDirectory> GetDirectories();

        /// <summary>
        /// Создает новый элемент спровочника
        /// </summary>
        /// <returns></returns>
        IDirectoryItem CreateNewDirectoryItem();

    }
}
