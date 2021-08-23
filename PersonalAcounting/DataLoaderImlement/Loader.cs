using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader
{
    public class Loader : ILoader
    {
        public string PathToFile { get; set; }

        public IEnumerable<Account.IAccount> LoadAccounts()
        {
            List<Account.Account> accounts = new List<Account.Account>();

            using (BinaryReader reader = new BinaryReader(File.Open(PathToFile, FileMode.OpenOrCreate)))
            {
                accounts = AccountLoader.Load(reader);
            }

            return accounts;
        }

        public void SaveAccounts(IEnumerable<Account.IAccount> accounts)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToFile, FileMode.OpenOrCreate)))
            {
                AccountLoader.Save(writer, accounts as List<Account.Account>);
            }
        }
    }
}
