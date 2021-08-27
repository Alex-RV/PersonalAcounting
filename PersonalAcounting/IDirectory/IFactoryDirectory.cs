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

        IEditorDirectory GetEditorDirectory();

        /// <summary>
        /// Создает новый элемент спровочника
        /// </summary>
        /// <returns></returns>
        IDirectoryItem CreateNewDirectoryItem(int? id= null);

    }
}
