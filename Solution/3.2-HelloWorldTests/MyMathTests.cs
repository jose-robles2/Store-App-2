using Microsoft.VisualStudio.TestPlatform.TestHost; 

using static HelloWorld.Program.MyMath;

namespace HelloWorldTests
{
    public class MyMathTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            int a = 1, b = 2; 
            int res = HelloWorld.Program.MyMath.add(a, b);
            Assert.AreEqual(res, 3);
        }
    }
}