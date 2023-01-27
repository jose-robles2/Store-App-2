using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HelloWorld.Date;


namespace HelloWorldTests
{
    internal class DateTests
    {
        [Test]
        public void IsLeapTestYearFalse()
        {
            Assert.AreEqual(false, Date.IsLeap(2023));
        }
        [Test]
        public void IsLeapTestYearTrue()
        {
            Assert.AreEqual(true, Date.IsLeap(2024));
        }
        [Test]
        public void IsLeapCenturyYearTrue()
        {
            Assert.AreEqual(true, Date.IsLeap(2000));
        }
        [Test]
        public void IsLeapCenturyYearFalse()
        {
            Assert.AreEqual(false, Date.IsLeap(2001));
        }
    }
}
