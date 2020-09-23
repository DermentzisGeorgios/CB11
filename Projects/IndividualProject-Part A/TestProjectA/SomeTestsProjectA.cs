using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectA
{
    [TestClass]
    public class SomeTestsProjectA
    {
        private readonly IndividualProject.TestMethod _testMethod;

        public SomeTestsProjectA()
        {
            _testMethod = new IndividualProject.TestMethod();
        }

        [DataTestMethod]
        [DataRow("4")]
        [DataRow("Hello World!")]
        [DataRow(null)]
        public void TestCheckInput(string value)
        {
            var result = _testMethod.CheckInput(value);
            Assert.IsNotNull(result);
        }

        [DataTestMethod]
        [DataRow("15")]
        [DataRow("10.4f")]
        [DataRow("14.5")]
        public void TestCheckInt(string value)
        {
            var result = 0;
            result = _testMethod.ConvertToInt(value);
            Assert.IsInstanceOfType(result, typeof(int));
        }
    }
}
