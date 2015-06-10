using System.Text;

namespace BottlesOfBeer
{
    public static class BottlesOfBeer
    {
        public static int VERSES;

        public static string GetVerse(int verseNo)
        {
            ValidateVerse(verseNo);
            var outputBuilder = new StringBuilder();
            var beerQty = VERSES - verseNo;

            outputBuilder.Append(string.Format("{0} {1} of beer on the wall, {2} {1} of beer.\n", ParseBeerQty(beerQty),
                QuantifyBottle(beerQty).ToLower(), ParseBeerQty(beerQty).ToLower()));
            if (beerQty == 0)
            {
                outputBuilder.Append("Go to the store and buy some more, 99 bottles of beer on the wall.");
            }
            else
            {
                outputBuilder.Append(string.Format("Take one down and pass it around, {0} {1} of beer on the wall.",
                    ParseBeerQty(beerQty - 1).ToLower(), QuantifyBottle(beerQty - 1).ToLower()));
            }
            return outputBuilder.ToString();
        }

        private static void ValidateVerse(int verseNo)
        {
            if (verseNo < 1 || verseNo > VERSES)
            {
                throw new InvalidVerseException();
            }
        }

        private static string QuantifyBottle(int qty)
        {
            if (qty != 1)
            {
                return "Bottles";
            }
            return "Bottle";
        }

        private static string ParseBeerQty(int qty)
        {
            if (qty > 0)
            {
                return qty.ToString();
            }
            return "No more";
        }
    }
}
