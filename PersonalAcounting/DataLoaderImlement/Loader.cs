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
                LoadDictionary(reader);
                _accountFabric.SetAccountList(LoadAccounts(reader, _factoryDirectory.GetDirectories()));
            }
        }

        public IEnumerable<Account.IAccount> LoadAccounts(BinaryReader reader, IEnumerable<Directory.IDirectory> directories)
        {
            List<Account.Account> accounts = new List<Account.Account>();

            accounts = AccountLoader.Load(reader, directories);

            return accounts;
        }

        public IEnumerable<Directory.IDirectory> LoadDictionary(BinaryReader reader)
        {
            IEnumerable<Directory.IDirectory> dictionaries = _factoryDirectory.GetDirectories();

            DirectoryItemLoader.Load(reader, dictionaries, _factoryDirectory.GetEditorDirectory(), _factoryDirectory);

            return dictionaries;
        }

        public void Save()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToFile, FileMode.OpenOrCreate)))
            {
                DirectoryItemLoader.Save(writer, _factoryDirectory.GetDirectories());
                AccountLoader.Save(writer, _accountFabric.GetAccountList().Items);
                
            }
        }
    }
}
