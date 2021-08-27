using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader
{
    internal class AccountLoader
    {
        public static List<Account.Account> Load(BinaryReader reader, IEnumerable<Directory.IDirectory> directories)
        {
            List<Account.Account> result = new List<Account.Account>();

            try
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Account.Account account = new Account.Account();
                    account.Name = reader.ReadString();
                    account.Owner = reader.ReadString();
                    account.CreateDate = new DateTime(reader.ReadInt64());

                    Directory.IDirectory incomeTypes = null;

                    foreach (Directory.IDirectory dir in directories)
                    {
                        if (dir.Name == Directory.Properties.Resources.IncomeType)
                        {
                            incomeTypes = dir;
                        }
                    }

                    account.Incomes = IncomeLoader.Load(reader, incomeTypes.Items);
                    account.Costs = CostsLoader.Load(reader);

                    result.Add(account);
                }
            }
            catch (Exception ex)
            { 

            }

            return result;
        }

        public static void Save(BinaryWriter writer, IEnumerable<Account.IAccount> accounts)
        {
            int countt = 0;
            foreach (Account.Account item in accounts)
            {
                countt++;
            }
            writer.Write(countt);
            foreach (Account.Account item in accounts)
            {
                writer.Write(item.Name);
                writer.Write(item.Owner);
                writer.Write(item.CreateDate.Ticks);

                IncomeLoader.Save(writer, item.Incomes as Income.IncomeList);
                CostsLoader.Save(writer, item.Costs as Costs.CostsList);
            }
        }
    }
}