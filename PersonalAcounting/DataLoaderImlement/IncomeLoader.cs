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

            try
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Income.Income income = new Income.Income();
                    income.Name = reader.ReadString();
                    income.Amount = reader.ReadDouble();
                    income.CreateDate = new DateTime(reader.ReadInt64());

                    //result.Add(income);
                    result.Items.Add(income);
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static void Save(BinaryWriter writer, Income.IncomeList list)
        {
            writer.Write(list.Items.Count);
            foreach (Income.Income item in list.Items)
            {
                writer.Write(item.Name);
                writer.Write(item.Amount);
                writer.Write(item.CreateDate.Ticks);

            }

        }
    }
}
