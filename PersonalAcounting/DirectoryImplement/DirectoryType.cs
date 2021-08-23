using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class DirectoryType : IDirectoryType
    {
        private string _name;

        public DirectoryType(string name)
        {
            _name = name;
        }

        public string Name 
        {
            get { return _name; }
        }
    }
}
