using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public abstract class BaseList<T>: IBaseList<T>
        where T: IBase
    {
        #region field
        private List<T> _items = new List<T>();
        #endregion field

        #region properties
        public List<T> Items { get { return _items; } }

        IEnumerable<T> IBaseList<T>.Items { get { return Items; } }
        //IEnumerable<T> IBaseList<T>.Items { get { return Items; } }


        #endregion properties
    }
}
