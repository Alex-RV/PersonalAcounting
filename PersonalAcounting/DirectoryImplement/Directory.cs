using System;

namespace Directory
{
    /// <summary>
    /// справочник
    /// </summary>
    public class Directory : IDirectory
    {
        #region field
        private string _name;
        private int _id;
        private DirectoryType _type;
        #endregion field

        #region properties
        ///<summary>
        ///Название дохода
        ///</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        ///<summary>
        ///Сумма дохода
        ///</summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        ///<summary>
        ///Тип дохода(категория)
        ///</summary>
        public DirectoryType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion properties
    }
}
