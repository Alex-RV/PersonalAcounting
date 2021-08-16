using System;
using System.Collections.Generic;
using System.Text;

namespace Directory
{
    public interface IDirectory
    {
        ///<summary>
        ///Идентификатор категории
        ///</summary>
        int ID { get; }

        ///<summary>
        ///Имя категории
        ///</summary>
        string Name { get; }

        ///<summary>
        ///Тип категории
        ///</summary>
        DirectoryType Type { get; }
        
        // тип сделать как ENUM

    }
}
