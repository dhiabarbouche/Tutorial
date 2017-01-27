using System;
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
            var list = new GenericChainedList<int>();
            var hundredFirstElement = Enumerable.Range(1, 100).ToArray();
            list.AddRange(hundredFirstElement);
            var evenNumbers = list.MyWhere(e => e % 2 == 0).ToList();
            Assert.IsNotNull(evenNumbers);
            Assert.AreEqual(hundredFirstElement.Length, list.Count());
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
    }
}
