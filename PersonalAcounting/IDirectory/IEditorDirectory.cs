using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public interface IEditorDirectory
    {
        void AddDirectoryItem(IDirectory target, IDirectoryItem newItem);

        void RemoveDirectoryItem(IDirectory source, IDirectoryItem removedItem);

        //void SetNameDirectory(IDirectory directory, string name);

        void SetNameDirectoryItem(IDirectoryItem item, string name);
    }
}
