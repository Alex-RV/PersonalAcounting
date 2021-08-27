using System;
using System.Collections.Generic;

namespace DataLoader
{
    /// <summary>
    /// Загрузчик данных
    /// </summary>
    public interface ILoader
    {
        string PathToFile { get; set; }

        void Load();

        void Save();
    }
}
