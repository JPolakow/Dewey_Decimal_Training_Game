//Jonathan Polakow
//ST10081881
//PROG7312 POE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTester.RedBackTree
{
   internal class DeweyModel
   {
      public DeweyModel(string number, string desctiption)
      {
         Number = number;
         Description = desctiption;

      }

      public string Number { get; set; }
      public string Description { get; set; }
   }
}
