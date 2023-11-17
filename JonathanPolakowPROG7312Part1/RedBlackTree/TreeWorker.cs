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
      /// <summary>
      /// method to return a random top level, the calling method uses a hashset to prevent duplicates
      /// </summary>
      /// <param name="deweyTree"></param>
      /// <returns></returns>
      public TreeNode<DeweyModel> GetRandomTopLevel(TreeNode<DeweyModel> deweyTree)
      {
         int randomindextogettoplevelsfrom = random.Next(1, deweyTree.Children.Count);
         return (getRandomParent(deweyTree, randomindextogettoplevelsfrom));
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to return two values, a second level and a third level
      /// takes in the selscted top level node and selects the values from it
      /// </summary>
      /// <param name="CorrectFirstLevel"></param>
      /// <param name="whichIsCorrect"></param>
      /// <returns></returns>
      public List<DeweyModel> SelectCorrectSecondAndThirdLevel(TreeNode<DeweyModel> CorrectFirstLevel, int whichIsCorrect)
      {
         List<DeweyModel> results = new List<DeweyModel>();
         DeweyModel correctThird;
         DeweyModel correctSecond;

         //select correct third level
         TreeNode<DeweyModel> whichTopLevelNodeIsCorrect = CorrectFirstLevel;
         int randomSecondIndex = random.Next(0, whichTopLevelNodeIsCorrect.Children.Count);
         TreeNode<DeweyModel> randomSecond = whichTopLevelNodeIsCorrect.Children.ElementAt(randomSecondIndex);
         correctSecond = randomSecond.Data;

         int randomThirdIndex = random.Next(0, randomSecond.Children.Count);
         TreeNode<DeweyModel> randomThird = randomSecond.Children.ElementAt(randomThirdIndex);
         correctThird = randomThird.Data;

         results.Add(correctSecond);
         results.Add(correctThird);
         return results;
      }

      //-------------------------------------------------------------------------------------------
      //method to get a random second level using the correct answer to generate values that are of the same first level
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
      //method to get a random third level using the correct answer to generate values that are of the same first and second level
      public TreeNode<DeweyModel> GetRandomThirdLevel(string correctAnswer, TreeNode<DeweyModel> topLevelNode)
      {
         string correctsecondlevelnumber = correctAnswer.Substring(1, 1);
         int correctsecondlevelnumberint = int.Parse(correctsecondlevelnumber);

         TreeNode<DeweyModel> randomthirdbasedoncorrect = (getRandomParent(topLevelNode, correctsecondlevelnumberint + 1));
         //thisl while is here as there are nodes in the tree with between 10 and 8 chilren, thus ther are cases where it tried to find a child at the 10th pos but it does not exisit
         while (randomthirdbasedoncorrect == null)
            randomthirdbasedoncorrect = (getRandomParent(topLevelNode, correctsecondlevelnumberint));

         int randomindex = random.Next(0, randomthirdbasedoncorrect.Children.Count);
         return (randomthirdbasedoncorrect.Children.ElementAt(randomindex));
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// this takes in a node and a number and gets a node
      /// this is the only part of the class i used ChatGPT for
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="parent"></param>
      /// <param name="n"></param>
      /// <returns></returns>
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