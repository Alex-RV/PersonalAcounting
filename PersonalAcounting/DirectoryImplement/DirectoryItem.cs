using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class DirectoryItem : IDirectoryItem
    {

        #region field
        private string _name;
        private int _id;
        private IDirectoryType _type;
        #endregion field

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public IDirectoryType DirectoryType
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
