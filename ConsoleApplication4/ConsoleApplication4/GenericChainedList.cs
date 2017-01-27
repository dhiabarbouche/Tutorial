using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication4
{
    public class GenericChainedList<T> : IGenericChainedList<T> where T : IEquatable<T>
    {
        public T value { get; set; }
        private GenericChainedList<T> next;
        private  GenericChainedList<T> first;
        private  GenericChainedList<T> last;
        public  int longueur;
        public void Addo(T item)
        {
            if (longueur == 0)
            {
                
                this.value = item;
                first = this;
                last = this;
                longueur += 1;
            }
            else
            {
                GenericChainedList<T> tempo = new GenericChainedList<T>();
                tempo.value = item;
                longueur += 1;
                last.next = tempo;
                last = last.next;

            }


        }
        public GenericChainedList<T> getfirst()
        {
            return first;

        }
        public GenericChainedList<T> getlast()
        {
            return last;

        }

        public GenericChainedList<T> getnext()
        {
            return next;

        }


        void IGenericChainedList<T>.affiche()
        {
            if (longueur > 0)
            {
                GenericChainedList<T> tempi = new GenericChainedList<T>();
                tempi = first;
                for (int i = 0; i < longueur; i++)
                {
                    Console.WriteLine(tempi.value);
                    tempi = tempi.next;

                }
            }
            else Console.WriteLine("liste vide :)");

        }

        bool Removo(T item)
        {
            int trouve = 0;
            int index_long = 0;
            GenericChainedList<T> chaine_index = first;
            while ((index_long < longueur) & (trouve == 0))
            {
                if (longueur == 0)
                {
                    Console.WriteLine("chaine vide");
                    trouve = 1;


                }
                else if (longueur == 1)
                {
                    if (first.value.Equals(item))
                    {
                        first = new GenericChainedList<T>();
                        last = new GenericChainedList<T>();

                        longueur -= 1;
                        return true;
                    }
                    else { Console.WriteLine("Item non trouvé dans la liste "); return false; }


                }
                else if (index_long == longueur - 1)
                {
                    if (chaine_index.next.value.Equals(item))
                    {
                        last = chaine_index;
                        trouve = 1;
                        longueur -= 1;
                        return true;
                    }
                    else
                    {


                        return false;

                    }

                }
                else if (first.value.Equals(item))
                {
                    first = first.next;
                    longueur -= 1;
                    trouve = 1;
                    return true;
                }
                else if (chaine_index.next.value.Equals(item))
                {
                    trouve = 1;
                    longueur -= 1;
                    chaine_index.next = chaine_index.next.next;
                    return true;

                }

                index_long += 1;
                chaine_index = chaine_index.next;
            }


            return false;
        }

        void IGenericChainedList<T>.Visit(GenericListVisitor<T> visitor)
        {
            foreach (T item in this)
            { visitor(item); }

        }

        void IGenericChainedList<T>.Sort(IComparer<T> comparator)
        {
            if (longueur == 0)
            {
                Console.WriteLine("liste vide");
            }
            else
            {
                GenericChainedList<T> tempi1 = new GenericChainedList<T>();
                GenericChainedList<T> tempi2 = new GenericChainedList<T>();

                tempi1 = first;
                T tempo;
                for (int i = 0; i < longueur - 1; i++)
                {
                    tempi2 = tempi1.next;
                    for (int j = i + 1; j < longueur; j++)
                    {

                        if ((comparator.Compare(tempi1.value, tempi2.value) > 0))
                        {
                            tempo = tempi1.value;
                            tempi1.value = tempi2.value;
                            tempi2.value = tempo;
                        }
                        tempi2 = tempi2.next;
                    }
                    tempi1 = tempi1.next;
                }
            }

        }

        void IGenericChainedList<T>.Reverse()
        {
            if (longueur == 0)
            {
                Console.WriteLine("liste vide");

            }
            else
            {
                GenericChainedList<T> tempi1 = new GenericChainedList<T>();
                GenericChainedList<T> tempi2 = new GenericChainedList<T>();

                tempi1 = first;
                T tempo;
                for (int i = 0; i < longueur - 1; i++)
                {
                    tempi2 = tempi1.next;
                    for (int j = i + 1; j < longueur; j++)
                    {


                        tempo = tempi1.value;
                        tempi1.value = tempi2.value;
                        tempi2.value = tempo;

                        tempi2 = tempi2.next;
                    }
                    tempi1 = tempi1.next;
                }
            }

        }

        void ICollection<T>.Add(T item)
        {
            this.Addo(item);

        }
        void ICollection<T>.Clear()
        {
            if (longueur > 0)
            {
                T item = first.value;
                int index_long = 0;
                int longueur_initiale = longueur;
                while (index_long < longueur_initiale)
                {
                    this.Removo(item);
                    item = first.value;

                    index_long += 1;
                }
            }
        }
        void ICollection<T>.CopyTo(T[] array, int index)
        {
            if ((array.Length - index) < longueur)
            {
                Console.WriteLine("longueur de tableau non suffisante pour contenir la liste");

            }
            else
            {

                GenericChainedList<T> tempi = new GenericChainedList<T>();
                tempi = first;


                for (int i = 0; i < longueur; i++)
                {
                    array[index + i] = tempi.value;


                    tempi = tempi.next;


                }
            }
        }
        bool ICollection<T>.Remove(T item)
        {
            return this.Removo(item);

        }
        int ICollection<T>.Count
        {
            get { return longueur; }

        }
        bool ICollection<T>.Contains(T item)
        {
            if (longueur == 0)
            {
                return false;
            }
            else
            {
                GenericChainedList<T> tempi = new GenericChainedList<T>();
                tempi = first;


                for (int i = 0; i < longueur; i++)
                {
                    if (tempi.value.Equals(item))
                    {
                        return true;

                    }
                    tempi = tempi.next;

                }
                return false;
            }
        }
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }

        }

        public IEnumerator<T> GetEnumerator()
        {
            MaClassEnum<T> tempo = new MaClassEnum<T>(this);

            return tempo;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

    }
}