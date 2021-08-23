using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public class CostsFabric : ICostsFabric
    {
        #region metods
        public ICosts CreateNew()
        {
            return new Costs();
        }

        public ICostsList CreateNewList()
        {
            return new CostsList();
        }
        //ВАЖНО ЧТО-ТО СДЕЛАТЬ
        public ICostsEditor GetCostsEditor(ICostsList list)
        {
            return new CostsEditor(list as CostsList);
        }
        #endregion
    }
}

