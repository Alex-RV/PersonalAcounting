using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Income
{
    public class IncomeAccountShort
    {
        private ObservableCollection<IncomeList> _items = new ObservableCollection<IncomeList>();

        public IncomeAccountShort(IIncomeList item)
        {
            Item = item;
        }

        public ObservableCollection<IncomeList> Items { get { return _items; } }

        public IIncomeList Item { get; }

        public void MonthIncome()
        {
            foreach (IIncomeList item in Items)
            {
                

            }
        }
    }
}
