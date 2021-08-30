using Directory;
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
            Costs correntCost = correntBase as Costs;
            if (correntCost != null)
            {
                correntCost.CreateDate = createdate;
            }
        }

        public override void SetName(ICosts correntBase, string name)
        {
            Costs correntCost = correntBase as Costs;
            if (correntCost != null)
            {
                correntCost.Name = name;
            }
        }

        public override void SetComment(ICosts correntBase, string comment)
        {
            Costs correntCost = correntBase as Costs;
            if (correntCost != null)
            {
                correntCost.Comment = comment;
            }
        }

        public override void SetType(ICosts changeItem, IDirectoryItem type)
        {
            Costs correntCost = changeItem as Costs;
            if (correntCost != null)
            {
                correntCost.Type = type;
            }
        }
    }
}
