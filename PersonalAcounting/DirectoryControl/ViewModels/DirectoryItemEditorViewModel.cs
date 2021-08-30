using System;
using System.Collections.Generic;
using System.Text;
using Directory;

namespace DirectoryControl.ViewModels
{
    public class DirectoryItemEditorViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private IDirectoryItem _directory;
        private string _name;
        private int _id;
        private IEditorDirectory _directoryEditor;
        private bool _isNew;
        private WPFHelper.RelayCommand _acceptDirectoryItemCommand;
        WPFHelper.RelayCommand _cancelCommand;
        #endregion fields

        #region constructor
        public DirectoryItemEditorViewModel(IEditorDirectory directoryEditor)
        {
            _directoryEditor = directoryEditor;
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Добавление или удаление
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }


        /// <summary>
        /// При нажатии на кнопку применить Directory
        /// </summary>
        public WPFHelper.RelayCommand AcceptDirectoryItemCommand
        {
            get
            {
                if (_acceptDirectoryItemCommand == null)
                {
                    _acceptDirectoryItemCommand = new WPFHelper.RelayCommand("", (p) => { Accept(); });
                }
                return _acceptDirectoryItemCommand;
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку Отмена
        /// </summary>
        public WPFHelper.RelayCommand CancelDirectoryCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new WPFHelper.RelayCommand("", (p) =>
                    {
                        OnCancelEditor();
                    });
                }
                return _cancelCommand;
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Установка редактируемой категории
        /// </summary>
        /// <param name="directory"></param>
        public void SetEditingDirectory(IDirectoryItem directory)
        {
            _directory = directory;
            Name = _directory.Name;
        }

        /// <summary>
        /// Возвращает редактируемую категорию
        /// </summary>
        /// <returns></returns>
        public IDirectoryItem GetEditingItem()
        {
            return _directory;
        }

        /// <summary>
        /// Метод выполняющийся при нажатии на кнопку Применить
        /// </summary>
        private void Accept()
        {
            _directoryEditor.SetNameDirectoryItem(_directory, _name);
            OnEndEditing();
        }
        #endregion

        private void OnEndEditing()
        {
            if (EndEditing != null)
            {
                EndEditing(this, EventArgs.Empty);
            }
        }

        private void OnCancelEditor()
        {
            if (CancelEditor != null)
            {
                CancelEditor(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Завершено редактирование
        /// </summary>
        public event EventHandler EndEditing;

        /// <summary>
        /// Кнопка отмена
        /// </summary>
        public event EventHandler CancelEditor;
    }
}
