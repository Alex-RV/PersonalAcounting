using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class DirectoryItem : IDirectoryItem
    {
        public int ID => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IDirectoryType DirectoryType => throw new NotImplementedException();
    }
}
