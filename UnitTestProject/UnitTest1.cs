using System;
using Lesson03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cat = new Cat();
            Assert.AreEqual(cat.MakeSound(), "Miauuuuu!");
        }
    }
}
