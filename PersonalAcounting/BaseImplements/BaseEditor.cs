using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    class BaseEditor<T>  : IBaseEditor
        where T : Base, IBase
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

        public void SetName(T correntBase, string name)
        {
       
            if (correntBase != null)
            {
                correntBase.Name = name;
            }
        }


        public void SetAmount( T correntBase, double amount)
        {
            if (correntBase != null)
            {
                correntBase.Amount = amount;
            }
        }

        public void SetCreateDate(T correntBase, DateTime createdate)
        {
            if (correntBase != null)
            {
                correntBase.CreateDate = createdate;
            }
        }

        public void Remove(T deleteI)
        {
            if (deleteI != null)
            {
                _list.Items.Remove(deleteI);
            }
        }
        #endregion
    }
}
