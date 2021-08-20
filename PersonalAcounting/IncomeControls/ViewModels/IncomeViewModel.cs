using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Income;

namespace IncomeControls.ViewModels
{
    public class IncomeViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private IIncomeList _list;
        private ObservableCollection<IncomeViewModel> _items = new ObservableCollection<IncomeViewModel>();
        private IncomeViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _addIncomeCommand;
        private bool _visibleEditorIncome = false;
        private IncomeEditorViewModel _editor;
        private IIncomeEditor _incomeEditor;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _editorCommand;
        #endregion fields

        #region constructor
        public IncomeViewModel(IIncomeList list, IIncomeEditor IncomeEditor)
        {
            _incomeEditor = IncomeEditor;
            //InitializeItems(list);
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Элементы
        /// </summary>
        public ObservableCollection<IncomeViewModel> Items { get { return _items; } }

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public IncomeViewModel SelectedItem
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

        public bool VisibleEditorIncome
        {
            get { return _visibleEditorIncome; }
            set
            {
                if (_visibleEditorIncome != value)
                {
                    _visibleEditorIncome = value;
                    OnPropertyChanged(nameof(VisibleEditorIncome));
                }
            }
        }

        public IncomeEditorViewModel Editor
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

        public WPFHelper.RelayCommand AddIncomeCommand
        {
            get
            {
                if (_addIncomeCommand == null)
                {
                    _addIncomeCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleEditorIncome = true;
                    });
                }

                return _addIncomeCommand;
            }
        }

        #endregion properties

        #region metods
        /// <summary>
        /// Инициализация коллекции
        /// </summary>
        /// <param name="list"></param>
        private void InitializeItems(IIncomeList list)
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
            //foreach (IIncome item in _list.Items)
            //{
            //    _items.Add(new IncomeViewModel(item)
            //    );
            //}
        }

        #endregion metods

        #region event handlers

        private void Editor_EndEditing(object sender, EventArgs e)
        {

            IIncome edditingAcount = Editor.GetEditingItem();
            if (Editor.IsNew)
            {
                _incomeEditor.Add(edditingAcount);
            }
            UpdateItems();
            VisibleEditorIncome = false;
        }

        #endregion event handlers

        #region events



        #endregion events

    }
}
