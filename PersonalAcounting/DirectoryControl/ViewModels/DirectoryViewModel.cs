using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Directory;

namespace DirectoryControl.ViewModels
{
    /// <summary>
    /// Элементы справочника
    /// </summary>
    public class DirectoryViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        Directory.IDirectory _directory;
        private DirectoryItemViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _editItemCommand;
        private ObservableCollection<DirectoryItemViewModel> _items = new ObservableCollection<DirectoryItemViewModel>();
        private IDirectory item;

        public DirectoryViewModel(IDirectory item)
        {
            this.item = item;
        }
        #endregion fields


        #region contructor
        public DirectoryViewModel(Directory.IDirectory directory, IDirectoryItem directoryItem, IDirectoryType directoryType)
        {
            _directory = directory;
        }
        #endregion contructor

        #region properies
        public ObservableCollection<DirectoryItemViewModel> Items { get { return _items; } }
        public DirectoryItemViewModel SelectedItem
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

        public string Name
        {
            get { return _directory.Name; }
        }
        #endregion properies

        #region metods


        ///// <summary>
        ///// Возвращает модель строки - счет
        ///// </summary>
        ///// <returns></returns>
        //public IDirectory GetModel()
        //{
        //    return _directory;
        //}
        #endregion metods

    }
}
