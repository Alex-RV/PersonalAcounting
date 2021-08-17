using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Account;

namespace AccountControl.ViewModels
{
    public class AccountsViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private IAccountList _list;
        private ObservableCollection<AccountViewModel> _items = new ObservableCollection<AccountViewModel>();
        private AccountViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _addCommand;
        private bool _visibleEditor = false;
        private AccountEditorViewModel _editor;
        #endregion fields

        #region constructor
        public AccountsViewModel(IAccountList list)
        {
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
                if(_selectedItem != value)
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

        public WPFHelper.RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        //IAccount account = null;
                        //AccountEditorViewModel accountEditor = new AccountEditorViewModel(account);
                        VisibleEditor = !VisibleEditor;
                        if (Editor == null)
                        {
                            Editor = new AccountEditorViewModel();
                        }

                    });
                }
                return _addCommand;
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

        #region metods
        /// <summary>
        /// Инициализация коллекции
        /// </summary>
        /// <param name="list"></param>
        private void InitializeItems(IAccountList list)
        {
            _list = list;

            foreach (IAccount item in _list.Items)
            {
                _items.Add(new AccountViewModel(item));
            }
        }
        #endregion metods

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
