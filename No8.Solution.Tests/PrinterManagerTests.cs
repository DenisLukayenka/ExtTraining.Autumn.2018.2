using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using No8.Solution;
using No8.Solution.Manager;
using No8.Solution.Printers;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterManagerTests
    {
        #region CreatePrinter method

        [Test]
        public void CreatePrinter_SuccessCreating()
        {
            Printer actualResult = PrinterManager.CreatePrinter("Canon", "new model");

            Printer expectedResult = new CommonPrinter("Canon", "new model");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CreatePrinter_NameIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => PrinterManager.CreatePrinter(null, "model"));

        [Test]
        public void CreatePrinter_ModelIsNull_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => PrinterManager.CreatePrinter("Canon", null));

        [Test]
        public void CreatePrinter_ModelIsEmpty_ArgumentNullException()
            => Assert.Throws<ArgumentException>(() => PrinterManager.CreatePrinter("Canon", "    "));

        [Test]
        public void CreatePrinter_NameIsEmpty_ArgumentNullException()
            => Assert.Throws<ArgumentException>(() => PrinterManager.CreatePrinter("    ", "model"));

        #endregion

        #region Add method

        [Test]
        public void Add_SuccessAdding()
        {
            PrinterManager.Add(PrinterManager.CreatePrinter("Canon", "new model"));

            Printer actualResult = PrinterManager.GetList().Last();
            Printer expectedResult = PrinterManager.CreatePrinter("Canon", "new model");

            PrinterManager.Remove(PrinterManager.CreatePrinter("Canon", "new model"));

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NullPrinter_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => PrinterManager.Add(null));


        #endregion

        #region Remove method

        [Test]
        public void Remove_SuccessRemoving()
        {
            Printer printer = PrinterManager.CreatePrinter("Canon", "new model");

            PrinterManager.Add(printer);
            PrinterManager.Remove(printer);

            bool actualResult = PrinterManager.GetList().Contains(printer);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_NullPrinter_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => PrinterManager.Remove(null));


        #endregion

        #region Get List

        [Test]
        public void GetList_SuccessListOfElements()
        {
            PrinterManager.Add(new CanonPrinter());
            PrinterManager.Add(new EpsonPrinter());

            List<Printer> expectedList = new List<Printer>
            {
                new CanonPrinter(),
                new EpsonPrinter()
            };

            List<Printer> actualList = PrinterManager.GetList();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        #endregion
    }
}
