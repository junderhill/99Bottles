using System.Text.RegularExpressions;
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
            BottlesOfBeer.VERSES = 100;
            var regex =
                new Regex(
                    @"^((\d)+|(No more))\sbottle(s)?\sof\sbeer\son\sthe\swall,\s((\d)+|(no more))\sbottle(s)?\sof\sbeer.\n(Take one down and pass it around|Go to the store and buy some more),\s((\d)+|(no more))\sbottle(s)?\sof\sbeer\son\sthe\swall\.");
            //act
            var result = BottlesOfBeer.GetVerse(1);
            //assert
            Assert.IsTrue(regex.IsMatch(result));
        }

        [TestMethod]
        public void TestThatGetVerse1ReturnsCorrectVerse()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(1);
            //assert
            var expected =
                "99 bottles of beer on the wall, 99 bottles of beer.\nTake one down and pass it around, 98 bottles of beer on the wall.";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestThatGetVerse98Has1BottleLeftOnWall()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(98);
            //assert
            Assert.IsTrue(result.Contains("Take one down and pass it around, 1 bottle of beer on the wall."));
        }

        [TestMethod]
        public void TestThatGetVerse99HasNoBottlesLeftOnWall()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(99);
            //assert
            Assert.IsTrue(result.EndsWith("Take one down and pass it around, no more bottles of beer on the wall."));
        }

        [TestMethod]
        public void TestThatVerse100HasNoBottlesToBeginWith()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(100);

            //assert
            Assert.IsTrue(result.StartsWith("No more bottles of beer on the wall, no more bottles of beer."));
        }

        [TestMethod]
        public void TestThatVerse100SecondLineStatesGoToStore()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(100);
            //assert
            Assert.IsTrue(result.Contains("\nGo to the store and buy some more,"));
        }

        [TestMethod]
        public void TestThatVerse100EndsWith99BottlesOnWall()
        {
            //act
            BottlesOfBeer.VERSES = 100;
            var result = BottlesOfBeer.GetVerse(100);
            //assert
            Assert.IsTrue(result.EndsWith(", 99 bottles of beer on the wall."));
        }

        [TestMethod]
        public void TestThatInvalidVerseExceptionIsThrownForVerse0()
        {
            //act
            try
            {
            BottlesOfBeer.VERSES = 100;
                BottlesOfBeer.GetVerse(0);
                Assert.Fail("InvalidVerseException wasn't thrown");
            }
            catch (InvalidVerseException)
            {
            }
        }

        [TestMethod]
        public void TestThatInvalidVerseExceptionIsThrownForVerse101()
        {
            //act
            try
            {
            BottlesOfBeer.VERSES = 100;
                BottlesOfBeer.GetVerse(101);
                Assert.Fail("InvalidVerseException wasn't thrown");
            }
            catch (InvalidVerseException)
            {
            }
        }

        [TestMethod]
        public void TestThatNoVersesCanBeUpdatedAndStillReturnsCorrect()
        {
            //act
            BottlesOfBeer.VERSES = 50;
            var result = BottlesOfBeer.GetVerse(1);
            //assert
            Assert.IsTrue(result.StartsWith("49 bottles of beer"));
        }

        [TestMethod]
        public void TestThatExceptionIsThownIfGetVerseIsCalledWithGreaterThanVerses()
        {
            //act
            try
            {
                BottlesOfBeer.VERSES = 25;
                BottlesOfBeer.GetVerse(30);
                Assert.Fail("InvalidVerseException wasn't thrown");
            }
            catch (InvalidVerseException)
            {
            }
        }
    }
}
