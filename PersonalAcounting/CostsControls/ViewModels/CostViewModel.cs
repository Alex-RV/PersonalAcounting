using System;
using System.Collections.Generic;
using System.Text;
using Costs;

namespace CostsControls.ViewModels
{
    /// <summary>
    /// Расход
    /// </summary>
    public class CostViewModel : WPFHelper.ViewModelBase
    {
        #region fields
        Costs.ICosts _costs;

        #endregion fields


        #region contructor
        public CostViewModel(Costs.ICosts cost)
        {
            _costs = cost;
        }
        #endregion contructor

        public string Name
        {
            get { return _costs.Name; }
        }

        public double Amount
        {
            get { return _costs.Amount; }
        }

        public DateTime CreateDate
        {
            get { return _costs.CreateDate; }
        }

        #region metods
        /// <summary>
        /// Возвращает модель строки - счет
        /// </summary>
        /// <returns></returns>
        public ICosts GetModel()
        {
            return _costs;
        }
        #endregion metods

    }
}
