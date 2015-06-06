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

        [TestMethod]
        public void TestThatGetVerse1ReturnsCorrectVerse(){
          //arrange
          var sut = new BottlesOfBeer();
          //act
          var result = sut.GetVerse(1);
          //assert
          string expected = @"99 bottles of beer on the wall, 99 bottles of beer.\nTake one down and pass it around, 98 bottles of beer on the wall.";
          Assert.AreEqual(expected, result);
        }
    }
}
