using System;
using System.Collections.Generic;
using System.Text;
using Directory;

namespace DirectoryControl.ViewModels
{
    class DirectoryItemEditorViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        private IDirectoryItem _directory;
        private string _name;
        private int _id;
        private IEditorDirectory _directoryEditor;
        private bool _isNew;
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



        WPFHelper.RelayCommand _acceptCommand;
        public WPFHelper.RelayCommand AcceptDirectoryCommand
        {
            get
            {
                if (_acceptCommand == null)
                {
                    _acceptCommand = new WPFHelper.RelayCommand("", (p) => { Accept(); });
                }
                return _acceptCommand;
            }
        }


        #endregion properties

        #region methods
        /// <summary>
        /// Установка редактируемой категории
        /// </summary>
        /// <param name="Directory"></param>
        public void SetEditingDirectory(IDirectoryItem Directory)
        {
            _directory = Directory;
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
        /// <summary>
        /// Завершено редактирование
        /// </summary>
        public event EventHandler EndEditing;
    }
}
