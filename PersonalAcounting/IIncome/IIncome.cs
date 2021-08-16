using System;
using System.Collections.Generic;
using System.Text;

namespace Income
{
    ///<summary>
    ///доходы
    ///</summary> 
    public interface IIncome
    { 
            ///<summary>
            ///наименование дохода
            ///</summary>
            string Name { get; }

            ///<summary>
            ///сумма дохода
            ///</summary>
            double Amount { get; }

            ///<summary>
            ///дата получения дохода
            ///</summary>
            DateTime CreateDate { get; }

            ///<summary>
            ///выбор валюты
            ///</summary>
            //CategoryID categoryID { get; }
            // тип данных для категорий(?)
            // можно использовать byte или char для выбора индеикатора id категории или как то еще

    }
}

