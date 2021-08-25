using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Directory;
using DirectoryControl;

namespace DirectoryControl.ViewModels
{
    /// <summary>
    /// Элементы справочника
    /// </summary>
    public class DirectoryViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        Directory.IDirectory _directory;
        private IDirectoryType _directoryType;
        private IDirectoryItem _directoryItem;
        private DirectoryItemViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _editorCommand;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _addDirectoryCommand;
        private IEditorDirectory _directoryEditor;
        private DirectoryItemEditorViewModel _editor;
        private bool _visibleDirectoryItemEditor = false;
        private ObservableCollection<DirectoryItemViewModel> _items = new ObservableCollection<DirectoryItemViewModel>();
        private ObservableCollection<DirectoryItemViewModel> _type = new ObservableCollection<DirectoryItemViewModel>();
        private IDirectory item;


        #endregion fields


        #region contructor
        public DirectoryViewModel(IDirectory item, IEditorDirectory editor)
        {
            _directory = item;
            _directoryEditor = editor;
            //foreach (IDirectory item in directories)
            //{
            //    DirectoryViewModel newItem = new DirectoryViewModel(item);
            //    Items.Add(newItem);
            //}
        }

        public DirectoryViewModel(Directory.IDirectory directory, IDirectoryItem directoryItem, IDirectoryType directoryType, IEditorDirectory editor)
        {
            //_directoryEditor = editor;
            _directoryType = directoryType;
            _directoryItem = directoryItem;

        }
        #endregion contructor

        #region properies

        public ObservableCollection<DirectoryItemViewModel> ItemsSource { get { return _items; } }

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

        //public ObservableCollection<DirectoryItemViewModel> Type { get { return _type; } }

        /// <summary>
        /// Действие при нажатии на кнопку ДОБАВИТЬ
        /// </summary>
        public WPFHelper.RelayCommand AddDirectoryCommand
        { 
            get
            {
                if (_addDirectoryCommand == null)
                {
                    _addDirectoryCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleDirectoryItemEditor = true;

                        if (Editor == null)
                        {
                            Editor = new DirectoryItemEditorViewModel(_directoryEditor);
                        }


                        //Editor.SetEditingIncome(_incomeFabric.CreateNew());
                        Editor.IsNew = true;
                    });
                }
                return _addDirectoryCommand;

            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку УДАЛИТЬ строку дохода
        /// </summary>
        public WPFHelper.RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if (SelectedItem == null)
                        {
                            return;
                        }
                        //_incomeEditor.Remove(SelectedItem.GetModel());
                        //UpdateItems();
                        //Editor.SetEditingIncome(_incomeFabric.CreateNew());
                    });
                }
                return _deleteCommand;
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку ИЗМЕНИТЬ доход
        /// </summary>
        public WPFHelper.RelayCommand EditorCommand
        {
            get
            {
                if (_editorCommand == null)
                {
                    _editorCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if (SelectedItem == null)
                        {
                            //Editor.SetEditingDirectory(SelectedItem.GetModel());
                            return;
                        }
                        //Editor.SetEditingIncome(SelectedItem.GetModel());
                        //Editor.IsNew = false;
                        //UpdateItems();
                    });
                }
                return _editorCommand;
            }
        }

        /// <summary>
        /// Видимость Editor(поля для добавления категорий) 
        /// </summary>
        public bool VisibleDirectoryItemEditor
        {
            get { return _visibleDirectoryItemEditor; }
            set
            {
                if (_visibleDirectoryItemEditor != value)
                {
                    _visibleDirectoryItemEditor = value;
                    OnPropertyChanged(nameof(VisibleDirectoryItemEditor));
                }
            }
        }

        public DirectoryItemEditorViewModel Editor
        {
            get { return _editor; }
            set
            {
                if (_editor != value)
                {
                    _editor = value;
                    OnPropertyChanged(nameof(Editor));
                }
            }
        }


        public string Name
        {
            get 
            {
                return _directory.Name; 
            }
        }
        #endregion properies

        #region metods


        /// <summary>
        /// Возвращает модель строки - счет
        /// </summary>
        /// <returns></returns>
        public IDirectory GetModel()
        {
            return _directory;
        }
        #endregion metods

    }
}
