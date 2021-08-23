using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Directory;

namespace DirectoryControl.ViewModels
{
    public class DirectoriesViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private ObservableCollection<DirectoryViewModel> _items;
        private DirectoryViewModel _selectedItem;

        private IDirectoryItem _directoryEditor;
        private IFactoryDirectory _directoryFabric;
        private WPFHelper.RelayCommand _editCommand;
        private bool _visibleEditor;
        #endregion fields


        #region constructor
        public DirectoriesViewModel(IEnumerable<IDirectory> directories, IDirectoryItem directoryEditor, IFactoryDirectory directoryFabric)
        {
            _directoryEditor = directoryEditor;
            _directoryFabric = directoryFabric;
            foreach (IDirectory item in directories)
            {
                DirectoryViewModel newItem = new DirectoryViewModel(item);
                Items.Add(newItem);
            }

        }
        #endregion constructor

        #region properies
        public ObservableCollection<DirectoryViewModel> Items { get { return _items; } }

        public DirectoryViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public WPFHelper.RelayCommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if(SelectedItem != null)
                        {
                            VisibleEditor = true;
                        }
                    });
                }
                return _editCommand;
            }
        }

        public bool VisibleEditor
        { 
            get { return _visibleEditor; }
            set
            {
                if (_visibleEditor != value)
                {
                    _visibleEditor = value;
                    OnPropertyChanged(nameof(VisibleEditor));
                }
            }
        }
        #endregion properies

    }
}
