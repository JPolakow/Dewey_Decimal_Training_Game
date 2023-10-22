using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312POE
{
   internal class IdentifyAreasWorker
   {
      //list of the dewey decimals and their corresponding categorty
      private Dictionary<string, string> DeweyToCategoryReference = new Dictionary<string, string>
        {
            { "000", "Generalities" },
            { "100", "Philosophy" },
            { "200", "Religion" },
            { "300", "Social Sciences" },
            { "400", "Language" },
            { "500", "Natural Sciences and Mathematics" },
            { "600", "Technology" },
            { "700", "Arts and Recreation" },
            { "800", "Literature" },
            { "900", "History and Geography" }
        };

      private Random rnd = new Random();

      //-------------------------------------------------------------------------------------------
      //
      public Dictionary<string, string> GenerateOrder()
      {
         try
         {
            ListShuffle shuffle = new ListShuffle();
            bool whichOne = rnd.Next(2) == 0;

            //create a new dictionary based on the reference
            Dictionary<string, string> shuffledDictionary = new Dictionary<string, string>();
            Dictionary<string, string> questionsWithAnswers = new Dictionary<string, string>();
            Dictionary<string, string> questionsWithoutAnswers = new Dictionary<string, string>();

            //swaps the dewey with the type if the random bool is true
            if (whichOne)
               shuffledDictionary = DeweyToCategoryReference.ToDictionary(pair => pair.Value, pair => pair.Key);
            else
               shuffledDictionary = DeweyToCategoryReference.ToDictionary(pair => pair.Key, pair => pair.Value);

            //randomise the order
            shuffledDictionary = shuffle.RandomizeDictionary(shuffledDictionary);
            //remove the last 3
            shuffledDictionary = shuffledDictionary.Take(7).ToDictionary(pair => pair.Key, pair => pair.Value);
            //take the first 3
            questionsWithAnswers = shuffledDictionary.Take(4).ToDictionary(pair => pair.Key, pair => pair.Value);
            //take the last 4 and add a string to the key inorder to easly identify
            questionsWithoutAnswers = shuffledDictionary.Skip(4).Take(3).ToDictionary(pair => "leave" + pair.Key, pair => pair.Value);

            shuffledDictionary.Clear();

            //merge the two dictionaryies into one
            foreach (var item in questionsWithoutAnswers)
            {
               shuffledDictionary.Add(item.Key, item.Value);
            }
            foreach (var item in questionsWithAnswers)
            {
               shuffledDictionary.Add(item.Key, item.Value);
            }

            //randomise the order
            shuffledDictionary = shuffle.RandomizeDictionary(shuffledDictionary);

            return shuffledDictionary;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
            return null;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// Helper function to compare locations
      /// </summary>
      /// <param name="panel1"></param>
      /// <param name="panel2"></param>
      /// <returns></returns>
      public bool AreLocationsEqual(Panel panel1, Panel panel2)
      {
         return panel1.Location == panel2.Location;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to generate a random color with a bias towards a brighter color
      /// </summary>
      /// <returns></returns>
      public Color RandomBrightColor()
      {
         Color randomColor = Color.FromArgb(rnd.Next(100, 200), rnd.Next(100, 200), rnd.Next(100, 200));
         return randomColor;
      }
   }
}
