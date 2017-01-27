using System;
using System.Collections.Generic;

namespace ConsoleApplication4
{
    public delegate void GenericListVisitor<T>(T value);
    public delegate bool test_func(int item);

    public interface IGenericChainedList<T> : ICollection<T>
        where T : IEquatable<T>
    {
        void Visit(GenericListVisitor<T> visitor);
        void Sort(IComparer<T> comparator);
        void affiche();
        void Reverse();
    }
}