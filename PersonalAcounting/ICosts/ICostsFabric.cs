using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public interface ICostsFabric
    {
        #region metods
        ICosts CreateNew();

        ICostsList CreateNewList();

        ICostsEditor GetCostsEditor(ICostsList list);
        #endregion
    }
}
