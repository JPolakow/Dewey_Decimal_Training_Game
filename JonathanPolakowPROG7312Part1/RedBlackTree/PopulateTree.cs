//Jonathan Polakow
//ST10081881
//PROG7312 POE
 
using Microsoft.VisualBasic.FileIO;
using System;
using System.Linq;

namespace CodeTester.RedBackTree
{
   internal class PopulateTree
   {
      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// this method gets the csv from the bin/debug folder and then reads each line into the tree
      /// </summary>
      /// <returns></returns>
      public TreeNode<DeweyModel> PopulateFromCsv()
      {
         try
         {
            string filePath = @"resorces//dewey.csv";

            //generic top level node used to sotre all the dewey decimals
            //this acts as the first level of the tree
            TreeNode<DeweyModel> root = new TreeNode<DeweyModel>(new DeweyModel("", ""));

            //the using statment & TextFieldParser have built in funcionality to close/dispose the connection when its done
            //this also works in the cast fo an error and the catch is called, the disposal method of TextFieldParser is called and the connection is closed
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
               parser.SetDelimiters(";");
               parser.TextFieldType = FieldType.Delimited;

               TreeNode<DeweyModel> currentParent = root;

               while (!parser.EndOfData)
               {
                  string[] fields = parser.ReadFields();

                  if (fields.Length >= 3)
                  {
                     string number = fields[0];
                     string description = fields[1];
                     int level = int.Parse(fields[2]);

                     // Assign the parent based on the level and number
                     currentParent = AssignParent(number, root, level);

                     // Add the current node as a child of the found parent
                     if (currentParent != null)
                     {
                        TreeNode<DeweyModel> newNode = currentParent.AddChild(new DeweyModel(number, description));
                     }
                  }
               }
            }
            return root;
         }
         catch (Exception ex)
         {
            return new TreeNode<DeweyModel>(new DeweyModel("", ""));
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// this emthod is used to find the parent of any given dewey decimal
      /// </summary>
      /// <param name="number"></param>
      /// <param name="parent"></param>
      /// <param name="level"></param>
      /// <returns></returns>
      private TreeNode<DeweyModel> AssignParent(string number, TreeNode<DeweyModel> parent, int level)
      {
         TreeNode<DeweyModel> parentNode = parent.Children.LastOrDefault();

         //if its a top level, like 000 or 900, add it to the root, so 2nd level in the tree
         if (level == 1)
         {
            // Add to the root
            return parent;
         }

         //if its a second level, like 010 or 920, add it to the correct first level node
         if (level == 2)
         {
            // Add to the first level starting with the same number
            TreeNode<DeweyModel> existingNode = parent.Children.FirstOrDefault
               (child => child.Data.Number.Substring(0, 1) == number.Substring(0, 1) && child.Level == level - 1);

            if (existingNode != null)
               if (existingNode != null)
               {
                  return existingNode;
               }
               else
               {
                  return parent.AddChild(new DeweyModel(number, $"desc of {number}"));
               }
         }

         //if its a 3rd level, such as 021 or 834, add it to the correct seconbd level
         if (level == 3)
         {
            // Add to the third level starting with the same two numbers
            foreach (var child in parent.Children)
            {
               if (child.Data.Number.Substring(0, 1) == number.Substring(0, 1))
               {
                  TreeNode<DeweyModel> existingNode = child.Children
                      .FirstOrDefault(subChild => subChild.Data.Number.Substring(0, 2) == number.Substring(0, 2) && subChild.Level == level - 1);

                  if (existingNode != null)
                  {
                     return existingNode;
                  }
               }
            }

            // If no existing node is found, add a new child to the parent
            return parent.AddChild(new DeweyModel(number, $"desc of {number}"));
         }

         return null;
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------
