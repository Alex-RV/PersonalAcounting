using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public class DeleteDirItemEventArgs: EventArgs
    {
        public IDirectory Directory { get; set; }

        public IDirectoryItem Item { get; set; }

        public bool EnabledDelete { get; set; }
    }
}
