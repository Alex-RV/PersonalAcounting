using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class DirectoryType : IDirectoryType
    {
        private string _name;
        private int _id;

        public DirectoryType(string name)
        {
            _name = name;
        }

        public string Name 
        {
            get { return _name; }
        }


        public int ID 
        {
            get { return _id; } 
            set { _id = value; }
        }
    }
}
