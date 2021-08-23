using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader
{
    internal class IncomeLoader
    {
        public static Income.IIncomeList Load(BinaryReader reader)
        {
            Income.IncomeList result = new Income.IncomeList();


            return result;
        }

        public static void Save(BinaryWriter writer, Income.IncomeList list)
        {

        }
    }
}
