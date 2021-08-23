using System;
using System.Collections.Generic;
using System.Text;
using Income;

namespace IncomeControls.ViewModels
{
    /// <summary>
    /// Доход
    /// </summary>
    public class IncomeViewModel: WPFHelper.ViewModelBase
    {
        #region fields
        Income.IIncome _income;

        #endregion fields


        #region contructor
        public IncomeViewModel(Income.IIncome income)
        {
            _income = income;
        }
        #endregion contructor

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

        #region metods
        /// <summary>
        /// Возвращает модель строки - счет
        /// </summary>
        /// <returns></returns>
        public IIncome GetModel()
        {
            return _income;
        }
        #endregion metods

    }
}
