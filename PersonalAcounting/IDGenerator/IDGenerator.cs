using System;

namespace IDGenerator
{
    public class IDGenerator
    {
        private int _lastID = 0;

        public int GetNewID()
        {
            return ++_lastID;
        }

        public void SetLastID(int id)
        {
            if (_lastID < id)
            {
                _lastID = id;
            }
        }
    }
}
