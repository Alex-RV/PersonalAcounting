using System;
using System.Collections.Generic;
using System.Text;
using Directory;

namespace DirectoryControl.ViewModels
{
    public class DirectoryItemViewModel: WPFHelper.ViewModelBase
    {
        #region fields 
        private IDirectoryItem _item;
        #endregion fields
        public DirectoryItemViewModel(IDirectoryItem item)
        {
            _item = item;
        }

        #region properties
        public string Name { get { return _item.Name; } }


        public IDirectoryItem GetModel()
        {
            return _item;
        }
        #endregion

    }



}
