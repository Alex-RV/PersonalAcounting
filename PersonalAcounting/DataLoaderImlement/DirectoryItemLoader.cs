using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Directory;

namespace DataLoader
{
    internal class DirectoryItemLoader
    {
        private static IDirectoryType directoryType;

        public static void  Load(BinaryReader reader, IEnumerable<IDirectory> directories, IEditorDirectory editor)
        {

            try
            {
                IDirectory targerDirectory = null;
              
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Directory.DirectoryItem directoryItem = new Directory.DirectoryItem();
                    directoryItem.ID = reader.ReadInt32();
                    directoryItem.Name = reader.ReadString();

                    int typeID = reader.ReadInt32();

                    if (targerDirectory == null || targerDirectory.Type.ID != typeID)
                    {
                        foreach (IDirectory directory in directories)
                        {
                            if (directory.Type.ID == typeID)
                            {
                                targerDirectory = directory;
                                break;
                            }
                        }
                    }
                    editor.AddDirectoryItem(targerDirectory, directoryItem);
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void Save(BinaryWriter writer, IEnumerable<Directory.IDirectory> directories)
        {

            int allCount = 0;

            foreach (IDirectory dir in directories)
            {
                foreach (var item in dir.Items)
                {
                    allCount++;
                }
            }

            writer.Write(allCount);

            foreach (IDirectory dir in directories)
            {
                foreach (var item in dir.Items)
                {
                    writer.Write(item.ID);
                    writer.Write(item.Name);
                    writer.Write(item.DirectoryType.ID);
                }
            }

        }
    }
}
