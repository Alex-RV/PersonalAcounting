using System;
using System.Collections.Generic;
using System.Text;

namespace Costs
{
    public class CostsEditor : Base.BaseEditor<ICosts>, ICostsEditor
    {
        public CostsEditor(CostsList list) : base(list)
        {

        }

        public override void SetAmount(ICosts correntBase, double amount)
        {
            Costs item = correntBase as Costs;
            if (item != null)
            {
                item.Amount = amount;
            }
        }

        public override void SetCreateDate(ICosts correntBase, DateTime createdate)
        {
            Costs correntIncome = correntBase as Costs;
            if (correntIncome != null)
            {
                correntIncome.CreateDate = createdate;
            }
        }

        public override void SetName(ICosts correntBase, string name)
        {
            Costs correntIncome = correntBase as Costs;
            if (correntIncome != null)
            {
                correntIncome.Name = name;
            }
        }

    }
}
