using Microsoft.VisualStudio.TestPlatform.TestHost; 

using static HelloWorld.Program.MyMath;

namespace HelloWorldTests
{
    internal class MyMathTests
    {
        [SetUp]
        public void Setup()
        {
            // not much to setup here 
        }

        [Test]
        public void TestAdd()
        {
            int a = 1, b = 2; 
            int res = HelloWorld.Program.MyMath.add(a, b);
            Assert.AreEqual(res, 3);
        }

        [Test]
        public void TestAddEdgeCase()
        {
            Assert.AreEqual(int.MaxValue, HelloWorld.Program.MyMath.add(int.MaxValue, 0));
        }

        [Test]
        public void TestAddExcpetionCase()
        {
            //right click 3.2-helloworld, click properties, click build, click advanced, check for arithmetic overflow/underflow
            //without this checked, it would fail 
            //int + string would be another exceptional case, BUT hard to test cause compiler would not allow it -> if this is the case and cant write any exception case, then write it down as a comment
            Assert.Throws<System.OverflowException>(() => HelloWorld.Program.MyMath.add(int.MaxValue, 3)); // u expect an exception (controlled, wont crash app)
        }
    }
}