using System.Collections.Generic;

namespace ConsoleApplication4
{
    public static class ExtensionMethods
    {
        public delegate bool Test_Func(int item);
        public static void AddRange(this ICollection<int> o, IEnumerable<int> set)
        {
            foreach(int item in set)
            {
                o.Add(item);

            }
        }

        public static List<int> MyWhere(this IEnumerable<int> o, Test_Func test_func  )
        {
            List<int> tempo = new List<int>();
            foreach ( int item in o)
            {
                if (test_func(item)) tempo.Add(item);


            }

            return tempo;
        }


    }
}