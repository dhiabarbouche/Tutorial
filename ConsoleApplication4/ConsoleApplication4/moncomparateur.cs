using System.Collections.Generic;

namespace ConsoleApplication4
{
    public class moncomparateur : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y) return 0;
            if (x > y) return 1;
            else return -1;
        }

    }
}