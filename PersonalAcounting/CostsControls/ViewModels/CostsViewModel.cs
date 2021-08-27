using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Costs;

namespace CostsControls.ViewModels
{
    public class CostsViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private ICostsList _list;
        private ObservableCollection<CostViewModel> _items = new ObservableCollection<CostViewModel>();
        private CostViewModel _selectedItem = null;
        private WPFHelper.RelayCommand _addCostCommand;
        private bool _visibleEditorCost = false;
        private CostEditorViewModel _editor;
        private ICostsEditor _costEditor;
        private ICostsFabric _costFabric;
        private WPFHelper.RelayCommand _deleteCommand;
        private WPFHelper.RelayCommand _editorCommand;
        private Directory.IDirectory _costTypes;
        #endregion fields

        #region constructor
        public CostsViewModel(ICostsList list, ICostsEditor CostEditor, ICostsFabric CostFabric, Directory.IDirectory costTypes)
        {
            _list = list;
            _costEditor = CostEditor;
            _costFabric = CostFabric;
            _costTypes = costTypes;
            InitializeItems(list);
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Элементы
        /// </summary>
        public ObservableCollection<CostViewModel> Items { get { return _items; } }

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public CostViewModel SelectedItem
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
        public bool VisibleEditorCost
        {
            get { return _visibleEditorCost; }
            set
            {
                if (_visibleEditorCost != value)
                {
                    _visibleEditorCost = value;
                    OnPropertyChanged(nameof(VisibleEditorCost));
                }
            }
        }

        /// <summary>
        /// редактор метод
        /// </summary>
        public CostEditorViewModel Editor
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
        /// Действие при нажатии на кнопку ДОБАВИТЬ расход
        /// </summary>
        public WPFHelper.RelayCommand AddCostCommand
        {
            get
            {
                if (_addCostCommand == null)
                {
                    _addCostCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        VisibleEditorCost = true;
                        InitEditor();
                        Editor.SetEditingCost(_costFabric.CreateNew());
                        Editor.IsNew = true;
                    });
                }
                return _addCostCommand;
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку УДАЛИТЬ строку расхода
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
                        _costEditor.Remove(SelectedItem.GetModel());
                        UpdateItems();
                        Editor.SetEditingCost(_costFabric.CreateNew());
                    });
                }
                return _deleteCommand;
            }
        }


        /// <summary>
        /// Действие при нажатии на кнопку ИЗМЕНИТЬ расход
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
                        VisibleEditorCost = true;
                        Editor.SetEditingCost(SelectedItem.GetModel());
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
        private void InitializeItems(ICostsList list)
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
            foreach (ICosts item in _list.Items)
            {
                _items.Add(new CostViewModel(item));
            }
        }

        private void InitEditor()
        {
            if (Editor == null)
            {
                Editor = new CostEditorViewModel(_costEditor);
                Editor.EndEditing += Editor_EndEditing;
                Editor.FillDirectioryItems(_costTypes.Items);
            }
        }
        #endregion metods

        #region event handlers

        private void Editor_EndEditing(object sender, EventArgs e)
        {

            ICosts edditingCost = Editor.GetEditingItem();
            if (Editor.IsNew)
            {
                _costEditor.Add(edditingCost);
            }
            UpdateItems();
            VisibleEditorCost = false;
        }

        #endregion event handlers

        #region events



        #endregion events

    }
}
