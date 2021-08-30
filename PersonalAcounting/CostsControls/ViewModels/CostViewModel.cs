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
        public CostViewModel(Costs.ICosts costs)
        {
            _costs = costs;
        }
        #endregion contructor

        public string Name
        {
            get { return _costs.Name; }
        }

        public string Comment
        {
            get { return _costs.Comment; }
        }

        public double Amount
        {
            get { return _costs.Amount; }
        }

        public DateTime CreateDate
        {
            get { return _costs.CreateDate; }
        }

        public string TypeName
        {
            get { return _costs.Type.Name; }
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
