using System;
using System.Collections.Generic;
using System.Text;

namespace IncomeControls.ViewModels
{
    public class IncomeViewModel: WPFHelper.ViewModelBase
    {
        Income.IIncome _income;
        public IncomeViewModel(Income.IIncome income)
        {
            _income = income;
        }

        public string Name
        {
            get { return _income.Name; }
        }

        public double Amount
        {
            get { return _income.Amount; }
        }

        public DateTime CreateDate
        {
            get { return _income.CreateDate; }
        }
    
    }
}
