using System;
using System.Collections.Generic;
using System.Text;

namespace CostsControls.ViewModels
{
    public class DirectoryItemCostViewModel : WPFHelper.ViewModelBase
    {
        private Directory.IDirectoryItem _directoryItem;

        public DirectoryItemCostViewModel(Directory.IDirectoryItem directoryItem)
        {
            _directoryItem = directoryItem;
        }

        public string Name
        {
            get
            {
                if (_directoryItem == null)
                {
                    return Properties.Resources.NotSelected;
                }
                return _directoryItem.Name;
            }
        }

        public Directory.IDirectoryItem Model { get { return _directoryItem; } }

        public override string ToString()
        {
            return Name;
        }

    }
}
