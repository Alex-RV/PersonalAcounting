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

                        InitEditor();
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
                        if (OnDeleteDirItem(SelectedItem.GetModel()))
                        {
                            _directoryEditor.RemoveDirectoryItem(_directory, SelectedItem.GetModel());
                            UpdateItems();
                        }
                        else
                        {
                            System.Windows.MessageBox.Show(Properties.Resources.NotEnableRemove, Properties.Resources.Information, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                        }
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
                        InitEditor();
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

        /// <summary>
        /// обработчик события нажатия на кнопку отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelEditor(object sender, EventArgs e)
        {
            VisibleDirectoryItemEditor = false;
        }
        #endregion event handlers

        #region metods

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

        private void InitEditor()
        {
            if (Editor == null)
            {
                Editor = new DirectoryItemEditorViewModel(_directoryEditor);
                Editor.CancelEditor += OnCancelEditor;
                Editor.EndEditing += Editor_EndEditing;
            }

        }

        #endregion metods

        #region events
        public event EventHandler<DeleteDirItemEventArgs> DeleteDirItem;
        private bool OnDeleteDirItem(IDirectoryItem directoryItem)
        {
            if (DeleteDirItem != null)
            {
                DeleteDirItemEventArgs eventArg = new DeleteDirItemEventArgs();
                eventArg.Directory = _directory;
                eventArg.Item = directoryItem;
                eventArg.EnabledDelete = true;
                DeleteDirItem(this, eventArg);
                return eventArg.EnabledDelete;
            }

            return true;
        }
        #endregion

    }
}
