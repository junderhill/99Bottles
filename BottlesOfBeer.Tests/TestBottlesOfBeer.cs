using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BottlesOfBeer.Tests
{
    [TestClass]
    public class TestBottlesOfBeer
    {
        [TestMethod]
        public void TestThatGetVerseReturnsAnyVerse()
        {
            //arrange
            var sut = new BottlesOfBeer();
            var regex = new System.Text.RegularExpressions.Regex(@"^((\d)+|(No more))\sbottle(s)?\sof\sbeer\son\sthe\swall,\s((\d)+|(no more))\sbottle(s)?\sof\sbeer.\n(Take one down and pass it around|Go to the store and buy some more),\s((\d)+|(no more))\sbottle(s)?\sof\sbeer\son\sthe\swall\.");
            //act
            var result = sut.GetVerse(1);
            //assert
            Assert.IsTrue(regex.IsMatch(result));
        }
    }
}
