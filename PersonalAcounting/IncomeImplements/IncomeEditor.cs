using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    public class IncomeEditor : IIncomeEditor
    {
        #region fields
        private IncomeList _list;

        #endregion fields

        #region constructor
        public IncomeEditor(IncomeList list)
        {
            _list = list;
        }
        #endregion
        #region metods
        public void Add(IIncome addIncome)
        {
            Income addItem = addIncome as Income;
            if (addItem != null)
            {
                _list.Items.Add(addItem);
            }
        }

        public void SetName(IIncome income, string name)
        {
            Income correntIncome = income as Income;
            if (correntIncome != null)
            {
                correntIncome.Name = name;
            }
        }


        public void SetAmount(IIncome income, double amount)
        {
            Income correntIncome = income as Income;
            if (correntIncome != null)
            {
                correntIncome.Amount = amount;
            }
        }

        public void SetCreateDate(IIncome income, DateTime createdate)
        {
            Income correntIncome = income as Income;
            if (correntIncome != null)
            {
                correntIncome.CreateDate = createdate;
            }
        }
    }
}