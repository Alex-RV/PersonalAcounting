using Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AccountControl.ViewModels
{
    public class AccountsViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private IAccountList _list;
        private ObservableCollection<AccountViewModel> _items = new ObservableCollection<AccountViewModel>();
        private AccountViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _addCommand;
        private bool _visibleEditor = false;
        private AccountEditorViewModel _editor;
        private IAccountEditor _accountEditor;
        private IAccountFabric _accountFabric;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _editorCommand;
        private WPFHelper.RelayCommand _openAccountCommand;
        private IEnumerable<Directory.IDirectory> _directories;
        private IncomeControls.ViewModels.IncomesViewModel _income;
        #endregion fields

        #region constructor
        public AccountsViewModel(IAccountList list, IAccountEditor accountEditor, IAccountFabric accountFabric, IEnumerable<Directory.IDirectory> directories)
        {
            _accountEditor = accountEditor;
            _accountFabric = accountFabric;
            _directories = directories;
            InitializeItems(list);
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Элементы
        /// </summary>
        public ObservableCollection<AccountViewModel> Items { get { return _items; } }

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public AccountViewModel SelectedItem
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
        /// Редактор
        /// </summary>
        public AccountEditorViewModel Editor
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

        /// <summary>
        /// Команда для кнопки Добавить
        /// </summary>
        public WPFHelper.RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleEditor = true;

                        InitEditor();

                        Editor.SetEditingAccount(_accountFabric.CreateNew());
                        Editor.IsNew = true;
                    });
                }
                return _addCommand;
            }
        }

        /// <summary>
        /// Команда для кнопки Удалить
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

                            if (VisibleEditor == true)
                            {
                                VisibleEditor = false;
                            }
                            return;
                        }
                        _accountEditor.Remove(SelectedItem.GetModel());
                        UpdateItems();
                        if (VisibleEditor == true)
                        {
                            VisibleEditor = false;
                        }
                        //Editor.SetEditingAccount(_accountFabric.CreateNew());
                    });
                }
                return _deleteCommand;
            }
        }

        /// <summary>
        /// Команда для кнопки Изменить
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

                        VisibleEditor = true;
                        Editor.SetEditingAccount(SelectedItem.GetModel());
                        Editor.IsNew = false;
                        UpdateItems();
                    });
                }
                return _editorCommand;
            }
        }

        /// <summary>
        /// Активация используемого счета
        /// </summary>
        public WPFHelper.RelayCommand OpenAccountCommand
        {
            get
            {
                if (_openAccountCommand == null)
                {
                    _openAccountCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        if (SelectedItem != null)
                        {
                            OnChangedButtonVisible();
                            OnChangedActivAcount();
                            
                        }
                    });
                }
                return _openAccountCommand;
            }
        }

        /// <summary>
        /// Видимость редактора
        /// </summary>
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
        #endregion properties

        public IncomeControls.ViewModels.IncomesViewModel Income
        {
            get { return _income; }
            set
            {
                if (_income != value)
                {
                    _income = value;

                    OnPropertyChanged(nameof(Income));
                }
            }
        }


        #region metods
        private void InitEditor()
        {
            if (Editor == null)
            {
                Editor = new AccountEditorViewModel(_accountEditor);
                Editor.CancelEditor += OnCancelEditor;
                Editor.EndEditing += Editor_EndEditing;
                //Income.OpenIncomeDirectoryAmount += OnOpenIncomeDirectoryAmount;
            }

        }

        /// <summary>
        /// Инициализация коллекции
        /// </summary>
        /// <param name="list"></param>
        private void InitializeItems(IAccountList list)
        {
            _list = list;

            FillItems();
        }

        /// <summary>
        /// Обновлнеие списка
        /// </summary>
        private void UpdateItems()
        {
            Items.Clear();
            FillItems();
        }

        /// <summary>
        /// Наполение списка
        /// </summary>
        private void FillItems()
        {
            foreach (IAccount item in _list.Items)
            {
                _items.Add(new AccountViewModel(item, _accountEditor, _directories));
            }
        }

        #endregion metods

        #region event handlers

        private void Editor_EndEditing(object sender, EventArgs e)
        {

            IAccount edditingAcount = Editor.GetEditingItem();
            if (Editor.IsNew)
            {
                _accountEditor.Add(edditingAcount);
            }
            UpdateItems();
            VisibleEditor = false;
        }

        /// <summary>
        /// обработчик события нажатия на кнопку отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelEditor(object sender, EventArgs e)
        {
            VisibleEditor = false;
        }

        #endregion event handlers

        #region events

        /// <summary>
        /// Событие отключение видимости кнопки
        /// </summary>
        public event EventHandler ChangedButtonVisible;

        private void OnChangedButtonVisible()
        {
            if (ChangedButtonVisible != null)
            {
                ChangedButtonVisible(this, EventArgs.Empty);
            }
        }

        public event EventHandler ChangedActivAcount;
        private void OnChangedActivAcount()
        {
            if (ChangedActivAcount != null)
            {
                ChangedActivAcount(this, EventArgs.Empty);
            }
        }

        ///// <summary>
        ///// обработчик события нажатия на кнопку открытие суммы по категориям
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void OnOpenIncomeDirectoryAmount(object sender, EventArgs e)
        //{
            
        //    //VisibleIncomeView = true;
        //}
        #endregion events

        #region IDisposble
        protected override void OnDispose()
        {
            base.OnDispose();
            _list = null;

            if (_items != null)
            {
                _items.Clear();
                _items = null;
            }
        }
        #endregion
    }
}
