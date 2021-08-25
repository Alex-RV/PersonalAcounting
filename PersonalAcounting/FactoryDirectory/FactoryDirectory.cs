using System;
using System.Collections.Generic;
using Res = Directory.Properties;

namespace Directory
{
    public class FactoryDirectory : IFactoryDirectory
    {
        #region fields
        private List<DirectoryType> _types;
        private EditorDirectory _editor;
        private List<Directory> _directories;
        #endregion fields

        #region contructor
        public FactoryDirectory()
        {
            _types = new List<DirectoryType>();
            DirectoryType incomeType = new DirectoryType(Res.Resources.IncomeType);
            _types.Add(incomeType);
            DirectoryType costsType = new DirectoryType(Res.Resources.CostsType);
            _types.Add(costsType);

             _directories = new List<Directory>();
            foreach (DirectoryType directoryType in _types)
            {
                Directory newDirectory = new Directory(directoryType);
                newDirectory.Name = directoryType.Name;
                _directories.Add(newDirectory);
            }
        }

        #endregion contructor

        #region methods
        public IDirectoryItem CreateNewDirectoryItem()
        {
            return new DirectoryItem();
        }

        public IEnumerable<IDirectory> GetDirectories()
        {
            return _directories;
        }

        public IEditorDirectory GetEditorDirectory()
        {
            if (_editor == null)
            {
                _editor = new EditorDirectory();
            }
            return _editor;
        }
        #endregion methods
    }
}
