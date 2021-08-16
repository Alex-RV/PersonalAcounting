using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public abstract class BaseList<T> where T:Base
    {
        #region field
        private List<T> _items = new List<T>();
        #endregion field

        #region properties
        public List<T> Items { get { return _items; } }
        //IEnumerable<IBase> IBaseList.Items { get { return Items; } }


        #endregion properties
    }
}
