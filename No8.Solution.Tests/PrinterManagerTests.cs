using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using No8.Solution;
using No8.Solution.Fabrics;
using No8.Solution.Printers;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterManagerTests
    {
        #region CreatePrinter method
        private PrinterManager manager = PrinterManager.GetInstance;
        private Factory factory = new Factory();

        [Test]
        public void CreatePrinter_NameIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => factory.CreatePrinter(null, "model"));

        [Test]
        public void CreatePrinter_ModelIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => factory.CreatePrinter("Canon", null));

        [Test]
        public void CreatePrinter_ModelIsEmpty_ArgumentNullException()
            => Assert.Throws<ArgumentException>(() => factory.CreatePrinter("Canon", "    "));

        [Test]
        public void CreatePrinter_NameIsEmpty_ArgumentNullException()
            => Assert.Throws<ArgumentException>(() => factory.CreatePrinter("    ", "model"));

        #endregion

        #region Add method

        [Test]
        public void Add_SuccessAdding()
        {
            manager.Add(factory.CreatePrinter("Canon", "new model"));

            Printer actualResult = manager.GetPrinters().Last();
            Printer expectedResult = factory.CreatePrinter("Canon", "new model");

            manager.Remove(factory.CreatePrinter("Canon", "new model"));

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NullPrinter_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => manager.Add(null));


        #endregion

        #region Remove method

        [Test]
        public void Remove_SuccessRemoving()
        {
            Printer printer = factory.CreatePrinter("Canon", "new model");

            manager.Add(printer);
            manager.Remove(printer);

            bool actualResult = manager.GetPrinters().Contains(printer);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_NullPrinter_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => manager.Remove(null));


        #endregion

        #region Get List

        [Test]
        public void GetList_SuccessListOfElements()
        {
            manager.Add(new CanonPrinter());
            manager.Add(new EpsonPrinter());

            List<Printer> expectedList = new List<Printer>
            {
                new CanonPrinter(),
                new EpsonPrinter()
            };

            IReadOnlyCollection<Printer> actualList = manager.GetPrinters();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        #endregion
    }
}
