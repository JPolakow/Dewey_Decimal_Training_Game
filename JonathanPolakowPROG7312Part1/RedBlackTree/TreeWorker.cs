//Jonathan Polakow
//ST10081881
//PROG7312 POE

using CodeTester.RedBackTree;
using CodeTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanPolakowPROG7312POE.RedBlackTree
{

   //this class is used to get the objects and treenodes required for use in the game
   //I managed to make the whole class with no input from ChatGPT or external sources which is why is rather complex
   internal class TreeWorker
   {
      private Random random = new Random();

      //-------------------------------------------------------------------------------------------
      //
      public TreeNode<DeweyModel> GetRandomTopLevel(TreeNode<DeweyModel> deweyTree)
      {
         int randomindextogettoplevelsfrom = random.Next(1, deweyTree.Children.Count);
         return (getRandomParent(deweyTree, randomindextogettoplevelsfrom));
      }

      //-------------------------------------------------------------------------------------------
      //
      public List<DeweyModel> SelectCorrectSecondAndThirdLevel(TreeNode<DeweyModel> CorrectFirstLevel, int whichIsCorrect)
      {
         List<DeweyModel> results = new List<DeweyModel>();
         DeweyModel correctThird;
         DeweyModel correctSecond;

         //select correct third level
         Console.WriteLine("----- select correct second and third level");

         TreeNode<DeweyModel> whichTopLevelNodeIsCorrect = CorrectFirstLevel;
         int randomSecondIndex = random.Next(0, whichTopLevelNodeIsCorrect.Children.Count);
         TreeNode<DeweyModel> randomSecond = whichTopLevelNodeIsCorrect.Children.ElementAt(randomSecondIndex);
         correctSecond = randomSecond.Data;

         int randomThirdIndex = random.Next(0, randomSecond.Children.Count);
         TreeNode<DeweyModel> randomThird = randomSecond.Children.ElementAt(randomThirdIndex);
         correctThird = randomThird.Data;

         Console.WriteLine($"Random Second: {correctSecond}");
         Console.WriteLine($"Random Third: {correctThird}");

         results.Add(correctSecond);
         results.Add(correctThird);
         return results;
      }

      //-------------------------------------------------------------------------------------------
      //
      public TreeNode<DeweyModel> GetRandomSecond(TreeNode<DeweyModel> deweyTree, string correctAnswer)
      {
         string correctfirstlevelnumber = correctAnswer.Substring(0, 1);
         int correctfirstlevelnumberint = int.Parse(correctfirstlevelnumber);

         TreeNode<DeweyModel> randomsecondbasedoncorrect = (getRandomParent(deweyTree, correctfirstlevelnumberint + 1));
         while (randomsecondbasedoncorrect == null)
            randomsecondbasedoncorrect = (getRandomParent(deweyTree, correctfirstlevelnumberint - 1));

         int randomindex = random.Next(0, randomsecondbasedoncorrect.Children.Count);
         return (randomsecondbasedoncorrect.Children.ElementAt(randomindex));

      }

      //-------------------------------------------------------------------------------------------
      //
      public TreeNode<DeweyModel> GetRandomThirdLevel(string correctAnswer, TreeNode<DeweyModel> topLevelNode)
      {
         string correctsecondlevelnumber = correctAnswer.Substring(1, 1);
         Console.WriteLine(correctsecondlevelnumber);
         int correctsecondlevelnumberint = int.Parse(correctsecondlevelnumber);

         TreeNode<DeweyModel> randomthirdbasedoncorrect = (getRandomParent(topLevelNode, correctsecondlevelnumberint + 1));
         //thisl while is here as there are nodes in the tree with between 10 and 8 chilren, thus ther are cases where it tried to find a child at the 10th pos but it does not exisit
         while (randomthirdbasedoncorrect == null)
            randomthirdbasedoncorrect = (getRandomParent(topLevelNode, correctsecondlevelnumberint));

         int randomindex = random.Next(0, randomthirdbasedoncorrect.Children.Count);
         return (randomthirdbasedoncorrect.Children.ElementAt(randomindex));
      }

      //-------------------------------------------------------------------------------------------
      //
      TreeNode<T> getRandomParent<T>(TreeNode<T> parent, int n)
      {
         if (n < 1 || n > parent.Children.Count)
         {
            return null; // Invalid index
         }

         return parent.Children.ElementAt(n - 1);
      }
   }
}