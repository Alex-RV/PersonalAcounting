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
        private IFactoryDirectory _factoryDirectory;

        #endregion fields


        #region contructor
        public DirectoryViewModel(IDirectory item, IEditorDirectory editor, IFactoryDirectory factoryDirectory)
        {
            _directory = item;
            _directoryEditor = editor;
            _factoryDirectory = factoryDirectory;
            UpdateItems();
        }
        #endregion contructor

        #region properies
        /// <summary>
        /// Добавление коллекции
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> ItemsSource { get { return _items; } }

        /// <summary>
        /// Выбранный справочник
        /// </summary>
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
                            Editor.EndEditing += Editor_EndEditing;
                        }

                        IDirectoryItem newDirectoryItem = _factoryDirectory.CreateNewDirectoryItem();
                        Editor.SetEditingDirectory(newDirectoryItem);
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
                        _directoryEditor.RemoveDirectoryItem(_directory, SelectedItem.GetModel());
                        IDirectoryItem newDirectoryItem = _factoryDirectory.CreateNewDirectoryItem();
                        Editor.SetEditingDirectory(newDirectoryItem);
                        UpdateItems();
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
                            return;
                        }
                        VisibleDirectoryItemEditor = true;
                        Editor.SetEditingDirectory(SelectedItem.GetModel());
                        Editor.IsNew = false;
                        UpdateItems();
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

        /// <summary>
        /// Обнровление отображаемой коллекции
        /// </summary>
        private void UpdateItems()
        {
            ItemsSource.Clear();

            foreach (IDirectoryItem directioryItem in _directory.Items)
            {
                DirectoryItemViewModel newItem = new DirectoryItemViewModel(directioryItem);
                ItemsSource.Add(newItem);
            }
        }

        #region event handlers

        private void Editor_EndEditing(object sender, EventArgs e)
        {
            IDirectoryItem newItem = Editor.GetEditingItem();
            if (Editor.IsNew)
            {
                _directoryEditor.AddDirectoryItem(_directory, newItem);
            }
            UpdateItems();
            VisibleDirectoryItemEditor = false;
        }

        #endregion event handlers

        #region metods

        /// <summary>
        /// Наполение списка
        /// </summary>
        private void FillItems()
        {
            foreach (IDirectory item in ItemsSource)
            {
                //_items.Add(new DirectoryItemViewModel(item));
            }
        }


        #endregion metods

    }
}
