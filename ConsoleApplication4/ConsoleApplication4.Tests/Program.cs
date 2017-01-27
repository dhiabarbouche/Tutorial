using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleApplication4.Tests
{
    class Foo
    {
        [Test]
        public void WhenIApplyAPredicateOnAListThenIDoNotModifyIt()
        {
            var list1 = new GenericChainedList<int>();
            var hundredFirstElement1 = Enumerable.Range(1, 100).ToArray();
            list1.AddRange(hundredFirstElement1);
            var evenNumbers1 = list1.MyWhere(e => e % 2 == 0).ToList();
            Assert.IsNotNull(evenNumbers1);
            int a = hundredFirstElement1.Length;
            int b = list1.Count();
            Assert.AreEqual(a,b);
        }

        [Test]
        public void WhenILookForEvenNumberThenIRetrieveHalfFromTheOriginal()
        {
            var list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100);
            list.AddRange(hundredFirstElement);
            var evenNumbers = list.MyWhere(e => e % 2 == 0).ToList();
            Assert.IsNotNull(evenNumbers);
            var expectedSize = 50;
            Assert.AreEqual(expectedSize, evenNumbers.Count);
            Assert.AreEqual(expectedSize * (expectedSize + 1), evenNumbers.Sum());
        }

        [Test]
        public void WhenILookForEvenNumberOnAFrameworkCollectionThenItWorks()
        {
            var hundredFirstElement = Enumerable.Range(1, 100);
            var evenNumbers = hundredFirstElement.MyWhere(e => e % 2 == 0).ToList();
            Assert.IsNotNull(evenNumbers);
        }



        [Test]
        public void WhenIInvertMyListTwiceIFindMyInitialList()
        {
            IGenericChainedList<int> list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100);
            list.AddRange(hundredFirstElement);
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            list.CopyTo(arr1, 0);
            list.Reverse();
            list.Reverse();
            list.CopyTo(arr2, 0);
            Assert.AreEqual(arr1, arr2);
        }
        [Test]
        public void WhenIAddARangeToMyChainedListImustFindAllElementsInIt()
        {
            IGenericChainedList<int> list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100);
            list.AddRange(hundredFirstElement);
            int[] arr2 = new int[100];
            list.CopyTo(arr2, 0);
            int[] arr1 = new int[100];
            arr1 = Enumerable.Range(1, 100).ToArray();
            Assert.AreEqual(arr1, arr2);
        }
        [Test]
        public void WhenIClearAChainedListItMustBecomeEmpty()
        {
            IGenericChainedList<int> list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100);
            list.AddRange(hundredFirstElement);
            list.Clear();
            Assert.AreEqual(list.Count(), 0);
        }

        [Test]
        public void WhenISortMylistInTheAscendingOrder()
        {
            IGenericChainedList<int> list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100).Reverse();
            list.AddRange(hundredFirstElement);
            moncomparateur comparateur = new moncomparateur();
            list.Sort(comparateur);
            int[] arr2 = new int[100];
            list.CopyTo(arr2, 0);
            int[] arr1 = new int[100];
            arr1 = Enumerable.Range(1, 100).ToArray();
            Assert.AreEqual(arr1, arr2);
        }

        [Test]
        public void Chevauchement()
        {
            IGenericChainedList<int> list1 = new GenericChainedList<int>();
            IGenericChainedList<int> list2 = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100);
            list1.AddRange(hundredFirstElement);
            var hundredFirstElement2 = Enumerable.Range(1, 50);
            list2.AddRange(hundredFirstElement2);
            int a = list1.Count();
            int b = list2.Count();
            Assert.AreNotEqual(a, b);
        }


    }
}
