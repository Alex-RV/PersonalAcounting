using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Income;

namespace IncomeControls.ViewModels
{
    public class IncomesViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        private IIncomeList _list;
        private ObservableCollection<IncomeViewModel> _items = new ObservableCollection<IncomeViewModel>();
        private IncomeViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _addIncomeCommand;
        private bool _visibleEditorIncome = false;
        private IncomeEditorViewModel _editor;
        private IIncomeEditor _incomeEditor;
        private IIncomeFabric _incomeFabric;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _editorCommand;
        private Directory.IDirectory _incomeTypes;
        #endregion fields

        #region constructor
        public IncomesViewModel(IIncomeList list, IIncomeEditor incomeEditor, IIncomeFabric incomeFabric, Directory.IDirectory incomeTypes)
        {
            _list = list;
            _incomeEditor = incomeEditor;
            _incomeFabric = incomeFabric;
            _incomeTypes = incomeTypes;
            InitializeItems(list);
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

        /// <summary>
        /// Видимость редактора
        /// </summary>
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

        /// <summary>
        /// редактор метод
        /// </summary>
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

        /// <summary>
        /// Действие при нажатии на кнопку ДОБАВИТЬ доход
        /// </summary>
        public WPFHelper.RelayCommand AddIncomeCommand
        {
            get
            {
                if (_addIncomeCommand == null)
                {
                    _addIncomeCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleEditorIncome = true;
                        InitEditor();
                        Editor.SetEditingIncome(_incomeFabric.CreateNew());
                        Editor.IsNew = true;
                    });
                }
                return _addIncomeCommand;
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
                        _incomeEditor.Remove(SelectedItem.GetModel());
                        UpdateItems();
                        Editor.SetEditingIncome(_incomeFabric.CreateNew());
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
                        VisibleEditorIncome = true;
                        Editor.SetEditingIncome(SelectedItem.GetModel());
                        Editor.IsNew = false;
                        UpdateItems();
                    });
                }
                return _editorCommand;
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
            foreach (IIncome item in _list.Items)
            {
                _items.Add(new IncomeViewModel(item));
            }
        }

        private void InitEditor()
        {
            if (Editor == null)
            {
                Editor = new IncomeEditorViewModel(_incomeEditor);
                Editor.EndEditing += Editor_EndEditing;
                Editor.CancelEditor += OnCancelEditor;
                Editor.FillDirectioryItems(_incomeTypes.Items);
            }
        }
        #endregion metods

        #region event handlers

        private void Editor_EndEditing(object sender, EventArgs e)
        {

            IIncome edditingIncome = Editor.GetEditingItem();
            if (Editor.IsNew)
            {
                _incomeEditor.Add(edditingIncome);
            }
            UpdateItems();
            VisibleEditorIncome = false;
        }

        /// <summary>
        /// обработчик события нажатия на кнопку отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelEditor(object sender, EventArgs e)
        {
            VisibleEditorIncome = false;
        }

        #endregion event handlers

        #region events



        #endregion events

    }
}
