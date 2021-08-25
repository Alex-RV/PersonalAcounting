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
        private ObservableCollection<DirectoryViewModel> _items = new ObservableCollection<DirectoryViewModel>();
        private DirectoryViewModel _selectedItem;

        private IEditorDirectory _directoryEditor;
        private IFactoryDirectory _directoryFabric;
        private WPFHelper.RelayCommand _directoryCommand;
        private bool _visibleDirectory = false;
        #endregion fields


        #region constructor
        public DirectoriesViewModel(IEnumerable<IDirectory> directories, IEditorDirectory directoryEditor, IFactoryDirectory directoryFabric)
        {
            _directoryEditor = directoryEditor;
            _directoryFabric = directoryFabric;
            foreach (IDirectory item in directories)
            {
                DirectoryViewModel newItem = new DirectoryViewModel(item,directoryEditor);
                Items.Add(newItem);
            }

        }
        #endregion constructor

        #region properies

        public ObservableCollection<DirectoryViewModel> Items { get { return _items; } }


        /// <summary>
        /// Выбранный элемент
        /// </summary>
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

        /// <summary>
        /// нажатие на кнопку изменить
        /// </summary>
        public WPFHelper.RelayCommand ChangeDirectoryItems
        {
            get
            {
                if (_directoryCommand == null)
                {
                    _directoryCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if(SelectedItem != null)
                        {
                            VisibleDirectory = true;
                        }
                    });
                }
                return _directoryCommand;
            }
        }

        /// <summary>
        /// Видимость окна эллементов справочника
        /// </summary>
        public bool VisibleDirectory
        { 
            get { return _visibleDirectory; }
            set
            {
                if (_visibleDirectory != value)
                {
                    _visibleDirectory = value;
                    OnPropertyChanged(nameof(VisibleDirectory));
                }
            }
        }
        #endregion properies


    }
}
