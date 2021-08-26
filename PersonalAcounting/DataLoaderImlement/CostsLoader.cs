﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLoader
{
    internal class CostsLoader
    {
        public static Costs.CostsList Load(BinaryReader reader)
        {
            Costs.CostsList result = new Costs.CostsList();

            try
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Costs.Costs cost = new Costs.Costs();
                    cost.Name = reader.ReadString();
                    cost.Amount = reader.ReadDouble();
                    cost.CreateDate = new DateTime(reader.ReadInt64());

                    //result.Add(income);
                    result.Items.Add(cost);
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static void Save(BinaryWriter writer, Costs.CostsList list)
        {
            writer.Write(list.Items.Count);
            foreach (Costs.Costs item in list.Items)
            {
                writer.Write(item.Name);
                writer.Write(item.Amount);
                writer.Write(item.CreateDate.Ticks);

            }
        }
    }
}
