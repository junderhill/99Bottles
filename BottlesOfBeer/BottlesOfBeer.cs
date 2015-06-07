using System;
using System.Text;
namespace BottlesOfBeer
{
    public class BottlesOfBeer
    {
        public string GetVerse(int verseNo)
        {
            StringBuilder outputBuilder = new StringBuilder();
            int beerQty = 100 - verseNo;
          
            outputBuilder.Append(String.Format("{0} {1} of beer on the wall, {2} {1} of beer.\n", ParseBeerQty(beerQty), QuantifyBottle(beerQty).ToLower(), ParseBeerQty(beerQty).ToLower()));
            if(beerQty == 0){
              outputBuilder.Append(String.Format("Go to the store and buy some more, 99 bottles of beer on the wall."));              
            }else{
              outputBuilder.Append(String.Format("Take one down and pass it around, {0} {1} of beer on the wall.", ParseBeerQty(beerQty-1).ToLower(), QuantifyBottle(beerQty-1).ToLower()));
            }
            return outputBuilder.ToString();
        }

        private string QuantifyBottle(int qty){
          if(qty != 1)
          {
            return "Bottles";
          }
          else
          {
            return "Bottle";
          }
        }

        private string ParseBeerQty(int qty){
          if(qty > 0){
            return qty.ToString();
          }
          else
          {
            return "No more";
          }
        }
    }
}
