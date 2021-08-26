using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader
{
    public class Loader : ILoader
    {
        #region fields
        private Directory.IFactoryDirectory _factoryDirectory;
        private Account.AccountFabric _accountFabric;
        #endregion fields

        public Loader(Account.AccountFabric accountFabric, Directory.IFactoryDirectory factoryDirectory)
        {
            _factoryDirectory = factoryDirectory;
            _accountFabric = accountFabric;
        }

        public string PathToFile { get; set; }


        public void Load()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(PathToFile, FileMode.OpenOrCreate)))
            {
                _accountFabric.SetAccountList(LoadAccounts(reader));

                LoadDictionary(reader);
            }
        }

        public IEnumerable<Account.IAccount> LoadAccounts(BinaryReader reader)
        {
            List<Account.Account> accounts = new List<Account.Account>();

            accounts = AccountLoader.Load(reader);

            return accounts;
        }

        public IEnumerable<Directory.IDirectory> LoadDictionary(BinaryReader reader)
        {
            IEnumerable<Directory.IDirectory> dictionaries = _factoryDirectory.GetDirectories();

            DirectoryItemLoader.Load(reader, dictionaries, _factoryDirectory.GetEditorDirectory());

            return dictionaries;
        }

        public void Save()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToFile, FileMode.OpenOrCreate)))
            {
                AccountLoader.Save(writer, _accountFabric.GetAccountList().Items);
                DirectoryItemLoader.Save(writer, _factoryDirectory.GetDirectories());
            }
        }
    }
}
