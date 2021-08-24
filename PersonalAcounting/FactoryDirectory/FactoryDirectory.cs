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
            _types.Add(new DirectoryType(Res.Resources.IncomeType));
            _types.Add(new DirectoryType(Res.Resources.CostsType));

             _directories = new List<Directory>();
            foreach (var item in _types)
            {
                _directories.Add(new Directory(item)
                {
                    Name = item.Name
                });
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
