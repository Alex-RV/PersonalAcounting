using System;
using System.Collections.Generic;

namespace Directory
{
    /// <summary>
    /// справочник
    /// </summary>
    public class Directory : IDirectory
    {
        #region field
        private string _name;
        private int _id;
        private IDirectoryType _type;
        #endregion field

        public Directory(IDirectoryType directoryType)
        {
            _type = directoryType;
        }

        #region properties
        ///<summary>
        ///Название дохода
        ///</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        ///<summary>
        ///Сумма дохода
        ///</summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Тип дохода(категория)
        /// </summary>
        public IDirectoryType Type
        {
            get { return _type; }
        }

        public IEnumerable<IDirectoryItem> Items => throw new NotImplementedException();

        IDirectoryType IDirectory.Type => throw new NotImplementedException();
        #endregion properties
    }
}
