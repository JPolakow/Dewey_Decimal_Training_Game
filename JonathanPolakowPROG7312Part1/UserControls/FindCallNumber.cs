//Jonathan Polakow
//ST10081881
//PROG7312 POE

using CodeTester;
using CodeTester.RedBackTree;
using JonathanPolakowPROG7312POE.RedBlackTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312POE.UserControls
{
   public partial class FindCallNumber : UserControl
   {
      #region vars

      /// <summary>
      /// awards model singleton
      /// </summary>
      private AwardsModelSingleton _Awards = AwardsModelSingleton.Instance;
      /// <summary>
      /// list of all book panels
      /// </summary>
      private List<Panel> Books = new List<Panel>();
      /// <summary>
      /// list of all the top panels
      /// </summary>
      private List<Panel> BottomShelves = new List<Panel>();
      /// <summary>
      /// list of all the bottom panels
      /// </summary>
      private List<Panel> TopShelves = new List<Panel>();
      /// <summary>
      /// int holding the timelimit for the user
      /// </summary>
      private int timeLimit;
      /// <summary>
      /// int that is used to coundown from the timelimit to zero, need both to send the timelimit to the awards model
      /// </summary>
      private int countDown;
      /// <summary>
      /// timer for the countdown
      /// </summary>
      private System.Windows.Forms.Timer tmrCountdown;
      /// <summary>
      /// instance of the worker class made for this game
      /// </summary>
      private PlaySounds sounds = new PlaySounds();
      /// <summary>
      /// instance of the populatetree class, used to get data from CSV and load into a tree
      /// </summary>
      private PopulateTree populate = new PopulateTree();
      /// <summary>
      /// instance of the worker class for this game
      /// </summary>
      private TreeWorker treeWorker = new TreeWorker();
      /// <summary>
      /// random number
      /// </summary>
      private Random random = new Random();
      /// <summary>
      /// root tree
      /// </summary>
      private TreeNode<DeweyModel> deweyTree;
      /// <summary>
      /// which entry is correct, used for generation and validation
      /// </summary>
      private int whichIsCorrect = -1;
      /// <summary>
      /// the current stage of the question the user is on
      /// </summary>
      private int stage = 0;

      //I have made the desission to generate all the nessesery data in the very beginning and then save it to be used as the user progresses
      //this makes it more streamlined, easier to develop and makes the game faster
      /// <summary>
      /// the correct first level dewey decimal, this is sotred as the tree branch as i need to get the values inside it
      /// </summary>
      private TreeNode<DeweyModel> CorrectFirstLevel;
      /// <summary>
      /// the correct second level dewey decimal
      /// </summary>
      private DeweyModel CorrectSecondLevel;
      /// <summary>
      /// the correct third level dewey decimal
      /// </summary>
      private DeweyModel CorrectThirdLevel;
      /// <summary>
      /// the three random top levels
      /// </summary>
      private List<TreeNode<DeweyModel>> threeTopLevelNodes = new List<TreeNode<DeweyModel>>();
      /// <summary>
      /// three random second levels
      /// </summary>
      private List<TreeNode<DeweyModel>> threeSecondLevels = new List<TreeNode<DeweyModel>>();
      /// <summary>
      /// three random third levels
      /// </summary>
      private List<TreeNode<DeweyModel>> threeThirdLevels = new List<TreeNode<DeweyModel>>();

      #endregion

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// constructor
      /// </summary>
      /// <param name="Timelimit"></param>
      public FindCallNumber(int Timelimit)
      {
         this.timeLimit = Timelimit;
         this.countDown = timeLimit;
         InitializeComponent();
         LoadData();
         StartGame();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to load the data form the populate class and then get the porgression data
      /// </summary>
      private void LoadData()
      {
         try
         {
            // Use the PopulateTree class to create a tree structure with Dewey decimals
            deweyTree = populate.PopulateFromCsv();

            Console.WriteLine("----- get the correct data");
            //generate a random number to specify which tree branch is valid
            whichIsCorrect = random.Next(0, 4);
            //get the number that has been identified as correct
            CorrectFirstLevel = treeWorker.GetRandomTopLevel(deweyTree);
            List<DeweyModel> results = treeWorker.SelectCorrectSecondAndThirdLevel(CorrectFirstLevel, whichIsCorrect);
            CorrectSecondLevel = results[0];
            CorrectThirdLevel = results[1];

            Console.WriteLine($"Correct First: {CorrectFirstLevel.Data.Number}");
            Console.WriteLine($"Correct Second: {CorrectSecondLevel.Number}");
            Console.WriteLine($"Correct Third: {CorrectThirdLevel.Number}");

            //get three randomly generated first level numbers 
            //using a hashset to prevent duplicate entries
            HashSet<string> uniqueTopLevelNumbers = new HashSet<string>();
            //add the correct one prevent duplicates
            uniqueTopLevelNumbers.Add(CorrectFirstLevel.Data.Number.ToString());
            Console.WriteLine("----- get three randomly generated first level numbers");
            for (int i = 0; i < 3; i++)
            {
               TreeNode<DeweyModel> newOne = treeWorker.GetRandomTopLevel(deweyTree);

               while (!uniqueTopLevelNumbers.Add(newOne.Data.Number.ToString()))
               {
                  newOne = treeWorker.GetRandomTopLevel(deweyTree);
               }

               threeTopLevelNodes.Add(newOne);
               Console.WriteLine(newOne.Data.Number);
            }


            //get 3 of the same second level based on correct third level 
            //using a hashset to prevent duplicate entries
            HashSet<string> uniqueSecondLevelNumbers = new HashSet<string>();
            //add the correct one prevent duplicates
            uniqueSecondLevelNumbers.Add(CorrectSecondLevel.Number.ToString());
            Console.WriteLine("----- get 3 of the same second level based on correct third level");
            for (int i = 0; i < 3; i++)
            {
               TreeNode<DeweyModel> newOne = treeWorker.GetRandomSecond(deweyTree, CorrectThirdLevel.Number);

               while (!uniqueSecondLevelNumbers.Add(newOne.Data.Number.ToString()))
               {
                  newOne = treeWorker.GetRandomSecond(deweyTree, CorrectThirdLevel.Number);
               }

               threeSecondLevels.Add(newOne);
               Console.WriteLine(newOne.Data.Number);
            }

            //threeSecondLevels = treeWorker.GetThreeSecondLevels(deweyTree, CorrectThirdLevel.Number);

            // get 3 of the same third level based on correct third level
            //using a hashset to prevent duplicate entries
            HashSet<string> uniqueThirdLevelNumbers = new HashSet<string>();
            //add the correct one prevent duplicates
            uniqueThirdLevelNumbers.Add(CorrectThirdLevel.Number.ToString());
            Console.WriteLine("----- get 3 of the same third level based on correct third level");
            for (int i = 0; i < 3; i++)
            {
               TreeNode<DeweyModel> newOne = treeWorker.GetRandomThirdLevel(CorrectThirdLevel.Number, CorrectFirstLevel);

               while (!uniqueThirdLevelNumbers.Add(newOne.Data.Number.ToString()))
               {
                  newOne = treeWorker.GetRandomThirdLevel(CorrectThirdLevel.Number, CorrectFirstLevel);
               }

               threeThirdLevels.Add(newOne);
               Console.WriteLine(newOne.Data.Number);
            }

            //threeThirdLevels = treeWorker.GetThreeThirdLevels(CorrectThirdLevel.Number, CorrectFirstLevel);
         }
         catch
         {
            //the idea of this catch is that it will try to reget the data, this catch has never been called thus far
            whichIsCorrect = random.Next(0, 4);
            LoadData();
         }

      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// initialiser method to set up the timer
      /// </summary>
      private void StartGame()
      {
         try
         {
            FilterPanelsIntoLists();
            PopulateBooks();

            this.tmrCountdown = new System.Windows.Forms.Timer();
            this.tmrCountdown.Tick += new EventHandler(tmrCountdown_Tick);
            this.tmrCountdown.Interval = 1000; // 1 second

            if (timeLimit > 0)
            {
               this.tmrCountdown.Start();
               lblCountdown.Text = timeLimit.ToString();
               lblCountdown.Visible = true;
            }

            foreach (Panel book in Books)
            {
               book.Enabled = true;
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
            BackToMenu();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to add all books into the correct lists
      /// </summary>
      private void FilterPanelsIntoLists()
      {
         try
         {
            //for every panel in the Control (in this case a userControl)
            //every System.Windows.Forms.Panel found
            //the in Controls.OfType is from ChatGPT
            foreach (Panel panel in Controls.OfType<Panel>())
            {
               if (panel.Name.Contains("Book"))
               {
                  this.Books.Add(panel);
                  ControlExtension.Draggable(panel, true);
                  panel.MouseDown += Panel_MouseDown;
                  panel.MouseUp += Panel_MouseUp;
                  panel.BackColor = RandomBrightColor();
                  panel.Visible = true;
               }

               if (panel.Name.Contains("Top"))
               {
                  this.TopShelves.Add(panel);
                  // this.RemainingShelves.Add(panel);
                  panel.BackColor = RandomBrightColor();
                  panel.Visible = true;
               }

               if (panel.Name.Contains("Bottom"))
               {
                  this.BottomShelves.Add(panel);
                  // this.RemainingShelves.Add(panel);
                  panel.BackColor = RandomBrightColor();
               }
            }

            this.Books = Books.OrderBy(panel => panel.Name).ToList();
            this.BottomShelves = BottomShelves.OrderBy(panel => panel.Name).ToList();
            this.TopShelves = TopShelves.OrderBy(panel => panel.Name).ToList();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
            BackToMenu();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// the timers tick method
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tmrCountdown_Tick(object sender, EventArgs e)
      {
         try
         {
            this.countDown--;

            if (this.countDown == 0)
            {
               this.tmrCountdown.Enabled = false;
               this.tmrCountdown.Stop();

               if (!CheckOrder())
               {
                  Fail();
               }
            }

            lblCountdown.Text = countDown.ToString();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// whenever the user presses down onto the panel
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Panel_MouseDown(object sender, MouseEventArgs e)
      {
         try
         {
            ControlExtension.Draggable((Panel)sender, true);

            /*//add the black where the book just was back to the list of where panels can go
            //this allows it to be placed back
            List<Panel> AllShelves = new List<Panel>(AnswerShelves);
            AllShelves.AddRange(QuestionShelves);
            Control book = sender as Control;
            foreach (Panel panel in AllShelves)
            {
               if (book.Location == panel.Location & !(RemainingShelves.Contains(panel)))
               {
                  this.RemainingShelves.Add(panel);
               }
            }*/
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// whenever the user releases the mouse whilst holding a button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Panel_MouseUp(object sender, MouseEventArgs e)
      {
         try
         {
            //which book was "dropped"
            Control book = sender as Control;

            //list of every panel and its distance to the "dropped" book
            Dictionary<Panel, double> PanelDistances = new Dictionary<Panel, double>();

            //Calculate every top selves distance to the book
            //Source for the calculation: ChatGPT
            List<Panel> AllShelves = new List<Panel>(BottomShelves);
            AllShelves.AddRange(TopShelves);

            foreach (Panel panel in AllShelves)
            {
               int deltaX = book.Location.X - panel.Location.X;
               int deltaY = book.Location.Y - panel.Location.Y;

               double totalDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
               PanelDistances.Add(panel, totalDistance);
            }

            //select the closest shelf
            Panel ClosestPanel = PanelDistances.First(pair => pair.Value == PanelDistances.Values.Min()).Key;
            book.Location = ClosestPanel.Location;

            this.Invoke((Action)(() =>
            {
               sounds.PlayBookPlace("BookPlace");
            }));

            //FilterRemaining();
            CheckOrder();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to generate a Dewey decimal list
      /// </summary>
      private void PopulateBooks()
      {
         try
         {
            List<string> tops = new List<string>();

            string bottomText = "";
            bottomText = CorrectThirdLevel.Description.ToString();

            //get the formatted sting to display on the top level
            tops = FormatForStage();

            //top shelves
            for (int i = 0; i < tops.Count; i++)
            {
               this.TopShelves[i].Controls.Clear();
               Label newAnswerLabel = new Label();
               newAnswerLabel.Name = "QuestionNumber" + i;
               newAnswerLabel.Text = tops[i].ToString();
               newAnswerLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
               newAnswerLabel.ForeColor = Color.Black;
               newAnswerLabel.Top = TopShelves[i].Height / 2 - newAnswerLabel.Height -30;
               newAnswerLabel.Height = newAnswerLabel.Height + 5;
               newAnswerLabel.Enabled = false;
               newAnswerLabel.Left = 5;
               newAnswerLabel.Width = TopShelves[i].Width - 10;
               newAnswerLabel.UseMnemonic = false;
               newAnswerLabel.AutoSize = false;
               newAnswerLabel.TextAlign = ContentAlignment.TopLeft;
               newAnswerLabel.Height = 100;
               this.TopShelves[i].Controls.Add(newAnswerLabel);
            }

            //bottom lable
            Book1.Location = BottomShelf1.Location;
            Label newLabel = new Label();
            newLabel.Name = "BookNumber1";
            //newLabel.Text = CorrectThirdLevel.Number.ToString() + "\n" + CorrectThirdLevel.Description;
            newLabel.Text = bottomText;
            newLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            newLabel.ForeColor = Color.Black;
            newLabel.Top = Book1.Height / 2 - newLabel.Height - 30;
            newLabel.Height = newLabel.Height + 5;
            newLabel.Enabled = false;
            newLabel.Left = 5;
            newLabel.Width = Book1.Width - 10;
            newLabel.UseMnemonic = false;
            newLabel.AutoSize = false;
            newLabel.TextAlign = ContentAlignment.TopLeft;
            newLabel.Height = 100;
            Book1.Controls.Add(newLabel);

         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
            MessageBox.Show("Oops, something went wrong, please try again");
            BackToMenu();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// format the string displayed in the panels
      /// extract/mask data from the correct answer then insert it at a random pos into the list
      /// </summary>
      /// <returns></returns>
      private List<string> FormatForStage()
      {
         List<string> result = new List<string>();
         string answer = "   \n";

         for (int i = 0; i < 3; i++)
         {
            string newOne = "";
            switch (stage)
            {
               case (0):
                  newOne = (threeTopLevelNodes[i].Data.Number.Substring(0, threeTopLevelNodes[i].Data.Number.Length - 2)
                     + "00") + "\n" + threeTopLevelNodes[i].Data.Description;
                  answer = CorrectFirstLevel.Data.Number.Substring(0, CorrectThirdLevel.Number.Length - 2)
                     + "00" + "\n" + CorrectFirstLevel.Data.Description;
                  break;
               case (1):
                  newOne = newOne + (threeSecondLevels[i].Data.Number.Substring(0, threeSecondLevels[i].Data.Number.Length - 1)
                     + "0") + "\n" + threeSecondLevels[i].Data.Description;
                  answer = CorrectSecondLevel.Number.Substring(0, CorrectThirdLevel.Number.Length - 1)
                     + "0" + "\n" + CorrectSecondLevel.Description;
                  break;
               case (2):
                  newOne = newOne + (threeThirdLevels[i].Data.Number);
                  newOne = newOne + "\n" + threeThirdLevels[i].Data.Description;
                  answer = CorrectThirdLevel.Number + "\n" + CorrectThirdLevel.Description;
                  break;
               default:
                  break;
            }
            result.Add(newOne);
         }

         //adding the correct formatted answer into the list at a random pos
         //then save this pos
         int pos = random.Next(0, 4);
         result.Insert(pos, answer);
         whichIsCorrect = pos;

         return result;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// check if the book has been placed at the correct postion
      /// </summary>
      /// <returns></returns>
      private bool CheckOrder()
      {
         try
         {
            int placedAnswers = this.TopShelves.Count(panel1 => this.Books.Any(panel2 => AreLocationsEqual(panel1, panel2)));

            if (placedAnswers == 1)
            {
               bool Valid = true;
               int bookPos = -1;
               int validCount = 0;

               for (int i = 0; i < TopShelves.Count; i++)
               {
                  if (Book1.Location == TopShelves[i].Location)
                  {
                     bookPos = i;
                  }
               }

               if (bookPos == whichIsCorrect)
               {
                  //next stage
                  stage++;
                  if (stage == 3)
                  {
                     pgbProgress.Value = 3;
                     Success();
                  }

                  PopulateBooks();
                  pgbProgress.Value = stage;
                  return true;
               }
               else
               {
                  //restart with new question
                  if (this.ParentForm is Form1 mainForm)
                  {
                     mainForm.OpenGame();
                  }
               }

            }

            return false;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
            MessageBox.Show("Oops, something went wrong, please try again");
            return false;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to execure then the users passes
      /// </summary>
      private void Success()
      {
         try
         {
            this.tmrCountdown.Enabled = false;

            this._Awards.AddNewEntry(timeLimit, countDown);

            this.Invoke((Action)(() => sounds.PlaySuccess("Success")));

            MessageBox.Show("You Pass");

            if (this.ParentForm is Form1 mainForm)
            {
               mainForm.OpenGame();
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to execute when the users fails
      /// </summary>
      private void Fail()
      {
         try
         {
            this.tmrCountdown.Enabled = false;

            this.Invoke((Action)(() => sounds.PlaySuccess("Fail")));

            MessageBox.Show("You Failed");

            foreach (Panel book in Books)
            {
               book.Enabled = false;
            }

            btnReset.Visible = true;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// calls the main form and disposes itself
      /// </summary>
      private void BackToMenu()
      {
         try
         {
            if (tmrCountdown != null)
            {
               this.tmrCountdown.Stop();
               this.tmrCountdown.Dispose();
            }
            if (this.ParentForm is Form1 mainForm)
            {
               mainForm.CloseUserControl();
            }

            this.Dispose();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// back button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnExit_Click(object sender, EventArgs e)
      {
         BackToMenu();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// reset button, 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnReset_Click(object sender, EventArgs e)
      {
         if (this.ParentForm is Form1 mainForm)
         {
            mainForm.OpenGame();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to generate a random color with a bias towards a brighter color
      /// </summary>
      /// <returns></returns>
      public Color RandomBrightColor()
      {
         Color randomColor = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
         return randomColor;
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
   }
}
//-----------------------------------------END OF FILE---------------------------------------------