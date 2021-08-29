using Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public class IncomeEditor : Base.BaseEditor<IIncome>, IIncomeEditor
    {
        public IncomeEditor(IncomeList list) : base(list)
        { 

        }

        public override void SetAmount(IIncome correntBase, double amount)
        {
            Income item = correntBase as Income;
            if (item != null)
            {
                item.Amount = amount;
            }
        }

        public override void SetCreateDate(IIncome correntBase, DateTime createdate)
        {
            Income correntIncome = correntBase as Income;
            if (correntIncome != null)
            {
                correntIncome.CreateDate = createdate;
            }
        }

        public override void SetName(IIncome correntBase, string name)
        {
            Income correntIncome = correntBase as Income;
            if (correntIncome != null)
            {
                correntIncome.Name = name;
            }
        }

        public override void SetComment(IIncome correntBase, string comment)
        {
            Income correntIncome = correntBase as Income;
            if (correntIncome != null)
            {
                correntIncome.Comment = comment;
            }
        }

        public override void SetType(IIncome changeItem, IDirectoryItem type)
        {
            Income correntIncome = changeItem as Income;
            if (correntIncome != null)
            {
                correntIncome.Type = type;
            }
        }
    }
}