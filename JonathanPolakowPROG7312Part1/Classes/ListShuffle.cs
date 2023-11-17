//Jonathan Polakow
//ST10081881
//PROG7312 POE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanPolakowPROG7312POE
{
   public class ListShuffle
   {
      public Dictionary<TKey, TValue> RandomizeDictionary<TKey, TValue>(Dictionary<TKey, TValue> originalDictionary)
      {
         // Create a list of key-value pairs from the original dictionary
         List<KeyValuePair<TKey, TValue>> list = originalDictionary.ToList();

         // Shuffle the list
         Random rng = new Random();
         int n = list.Count;
         while (n > 1)
         {
            n--;
            int k = rng.Next(n + 1);
            var temp = list[k];
            list[k] = list[n];
            list[n] = temp;
         }

         // Create a new dictionary from the shuffled list
         Dictionary<TKey, TValue> randomizedDictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);

         return randomizedDictionary;
      }
   }
}
