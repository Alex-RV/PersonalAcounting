using Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public abstract class BaseEditor<T>  : IBaseEditor<T>
        where T : IBase
    {
        #region fields
        private BaseList<T> _list;

        #endregion fields

        #region constructor
        public BaseEditor(BaseList<T> list)
        {
            _list = list;
        }
        #endregion
        #region metods
        public void Add(T addItem)
        {
            
            if (addItem != null)
            {
                _list.Items.Add(addItem);
            }
        }

        public abstract void SetName(T correntBase, string name);

        public abstract void SetComment(T correntBase, string comment);

        public abstract void SetAmount(T correntBase, double amount);

        public abstract void SetCreateDate(T correntBase, DateTime createdate);

        public void Remove(T delete)
        {
            if (delete != null)
            {
                _list.Items.Remove(delete);
            }
        }

        public abstract void SetType(T changeItem, IDirectoryItem type);
        #endregion
    }
}
