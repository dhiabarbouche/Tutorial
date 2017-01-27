using System.Collections.Generic;

namespace MyProjects
{
    public delegate void ListVisitor(int i);

    public interface IChainedList
    {
        int Count { get; }
        void Add(int item);
        void Remove(int item);
        void Accept(ListVisitor visitor);
        void Sort(IComparer<int> comparator);

        IChainedList Reverse();
    }
}