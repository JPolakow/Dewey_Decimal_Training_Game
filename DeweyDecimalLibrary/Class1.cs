//Jonathan Polakow
//ST10081881
//PROG7312 POE part 1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalLibrary
{

   //I tried to rename to a better class name but when i did it would not show up anymore in the other project
    public class Class1
    {
      /// <summary>
      /// random object
      /// </summary>
      private Random rnd = new Random();

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// a method in the library to generate a random Dewey decimal with a random authors initials
      /// </summary>
      /// <returns></returns>
      public string GenerateDeweyDecimal()
      {
         int wholeNumber = rnd.Next(0, 1000);
         int decimalPart = rnd.Next(0, 100);

         string randomLetters = "";

         //source: ChatGPT
         for (int i = 0; i < 3; i++)
         {
            //source: https://stackoverflow.com/questions/15249138/pick-random-char
            char randomLetter = (char)('a' + rnd.Next(0, 26));
            randomLetters += randomLetter;
         }

         //D3 means tha the number has to be 3 numbers ling, if its 5 it will be converted to 005
         string result = ($"{wholeNumber:D3}.{decimalPart:D2}\n{randomLetters.ToUpper()}");

         return result;
      }
    }
}
//-----------------------------------------END OF FILE---------------------------------------------