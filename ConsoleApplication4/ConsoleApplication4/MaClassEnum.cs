using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication4
{
    public class MaClassEnum<T> : IEnumerator<T> where T : IEquatable<T>
    {
        GenericChainedList<T> local = new GenericChainedList<T>();
        int position = -1;

        public MaClassEnum(GenericChainedList<T> list)
        {
            local = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < local.Count());
        }

        public void Reset()
        {
            position = -1;
        }
        void IDisposable.Dispose() { }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        //TODO : Please avoid property in O(n). It must be in O(1)
        public T Current
        {
            get
            {
                GenericChainedList<T> tempi = new GenericChainedList<T>();
                tempi = local.getfirst();

                if (position > 0)
                {
                    for (int i = 0; i < position; i++)
                    {
                        tempi = tempi.getnext();
                    }
                    return tempi.value;
                }
                else
                {
                    return local.getfirst().value;
                }
            }
        }

    }
}