   using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Income
{
    public class IncomeAccountShort
    {
        private int _dateTime;
        private IIncomeList _item;
        private ObservableCollection<IncomeList> _items = new ObservableCollection<IncomeList>();
        private ObservableCollection<IIncomeList> _itemss = new ObservableCollection<IIncomeList>();
        private IEnumerable<IIncomeList> _incomeList;

        public IncomeAccountShort(IIncomeList item)
        {
            _item = item;
        }

        public ObservableCollection<IncomeList> Items { get { return _items; } }
        public ObservableCollection<IIncomeList> Itemss { get { return _itemss; } }
        public IEnumerable<IIncomeList> incomeLists { get { return _incomeList; } }

        //public IIncomeList Item { get; }

        public void MonthIncome()
        {
            _dateTime = DateTime.Now.Day;
            for (int i = 0; i < _dateTime; i++)
            {
                foreach (IIncomeList item in Items)
                {
                    if (item.Items == _items)
                    {

                    }
                    Console.Write(i);
                }
            }
           
        }
    }
}
