using System;
using Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForGenerics
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDateConvertSuccsess()
        {
            var dateNow = DateTime.Today.Date.ToString();
            MyGenericClass<string> genericClass = new MyGenericClass<string>("David");


            var result = genericClass.ConvertStringToDateTime<DateTime>(dateNow);
            Assert.IsNotNull(result);


        }
    }
}
