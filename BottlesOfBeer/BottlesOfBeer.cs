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
          
            outputBuilder.Append(String.Format("{0} {1} of beer on the wall, {0} {1} of beer.\n", beerQty, QuantifyBottle(beerQty).ToLower()));
            if(beerQty == 0){
              
            }else{
              outputBuilder.Append(String.Format("Take one down and pass it around, {0} {1} of beer on the wall.", beerQty-1, QuantifyBottle(beerQty-1).ToLower()));
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
    }
}
