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
        private WPFHelper.RelayCommand _addCommand;
        private bool _visibleEditorIncome = false;
        private IncomeEditorViewModel _editor;
        private IIncomeEditor _IncomeEditor;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _editorCommand;
        #endregion fields

        #region constructor
        public IncomeViewModel(IIncomeList list, IIncomeEditor IncomeEditor)
        {
            _IncomeEditor = IncomeEditor;
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

        #endregion properties

        #region events



        #endregion events

    }
}
