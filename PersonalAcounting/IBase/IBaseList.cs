using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public interface IBaseList<T> where T: IBase
    {
        IEnumerable<T> Items { get; }
    }
}
