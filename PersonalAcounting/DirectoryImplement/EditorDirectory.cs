using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class EditorDirectory : IEditorDirectory
    {


        
        public void AddDirectoryItem(IDirectory target, IDirectoryItem newItem)
        {
            DirectoryItem addItem = newItem as DirectoryItem;
            if (addItem != null)
            {
                (target as Directory).Items.Add(addItem);
            }

        }

        public void RemoveDirectoryItem(IDirectory source, IDirectoryItem removedItem)
        {
            DirectoryItem removedI = removedItem as DirectoryItem;
            if (removedI != null)
            {
                (source as Directory).Items.Add(removedI);
            }
        }

        public void SetNameDirectory(IDirectory directory, string name)
        {
            DirectoryItem correctDirectory = directory as DirectoryItem;
            if (correctDirectory != null)
            {
                correctDirectory.Name = name;
            }
        }

        public void SetNameDirectoryItem(IDirectoryItem item, string name)
        {
            DirectoryItem correctItem = item as DirectoryItem;
            if (correctItem != null)
            {
                correctItem.Name = name;
            }
        }
    }
}
