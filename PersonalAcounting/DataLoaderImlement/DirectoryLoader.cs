using Directory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader
{
    internal class DirectoryLoader
    {
        //private static IDirectoryType directoryType;

        public static List<Directory.Directory> Load(BinaryReader reader)
        {
            List<Directory.Directory> result = new List<Directory.Directory>();

            try
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    //Directory.FactoryDirectory directory = new FactoryDirectory();
                    //Directory.Directory directory =new Directory.Directory(directoryType);
                    //directory.Name = reader.ReadString();

                    
                   // directory.Items = DirectoryLoader.Load(reader);

                    //result.Add(directory);
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }


    }
}
