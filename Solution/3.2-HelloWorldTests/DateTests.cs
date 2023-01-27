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
        public void IsLeapTest()
        {
            Assert.AreEqual(false, Date.IsLeap(2023));
        }
    }
}
