using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2_tests
{
    class MathTests
    {
        public void Setup()
        {

        }
        public void TestAdd()
        {
            int a = 5, b = 10;
            int res = MyMath.add(a, b);
            Assert.AreEqual(res, 15);
        }
    }
}
