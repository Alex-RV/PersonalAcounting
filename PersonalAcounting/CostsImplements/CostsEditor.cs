using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public class CostsEditor : Base.BaseEditor<ICosts>, ICostsEditor
    {
        #region constructor
        public CostsEditor(CostsList list): base(list)
        {
        }
        #endregion
        #region metods

        public override void SetAmount(ICosts correntBase, double amount)
        {
            throw new NotImplementedException();
        }

        public override void SetCreateDate(ICosts correntBase, DateTime createdate)
        {
            throw new NotImplementedException();
        }

        public override void SetName(ICosts correntBase, string name)
        {
            throw new NotImplementedException();
        }
        #endregion metods

    }
}
