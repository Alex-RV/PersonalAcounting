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
        private IDGenerator.IDGenerator _IDGenerator;
        #endregion fields

        #region contructor
        public FactoryDirectory()
        {
            _IDGenerator = new IDGenerator.IDGenerator();
            int idDirectoryType = 1;

            _types = new List<DirectoryType>();
            DirectoryType incomeType = new DirectoryType(Res.Resources.IncomeType);
            incomeType.ID = idDirectoryType++;
            _types.Add(incomeType);
            DirectoryType costsType = new DirectoryType(Res.Resources.CostsType);
            costsType.ID = idDirectoryType++;
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
        public IDirectoryItem CreateNewDirectoryItem(int? id = null)
        {
            var result = new DirectoryItem();
            if (id.HasValue)
            {
                result.ID = id.Value;
                _IDGenerator.SetLastID(result.ID);
            }
            else
            {
                result.ID = _IDGenerator.GetNewID();
            }
            return result;
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
