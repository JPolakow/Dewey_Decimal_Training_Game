//Jonathan Polakow
//ST10081881
//PROG7312 POE Part 2

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312POE
{
   public partial class IdentifyAreas : UserControl
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
      private List<Panel> AnswerShelves = new List<Panel>();
      /// <summary>
      /// list of all the bottom panels
      /// </summary>
      private List<Panel> QuestionShelves = new List<Panel>();
      /// <summary>
      /// list of all the panels that are not occupied by a book
      /// </summary>
      private List<Panel> RemainingShelves = new List<Panel>();
      /// <summary>
      /// dictionary contraining the Dewey Decimal numbers in order and the bnook the number was assigned to
      /// </summary>
      private Dictionary<string, string> SortedBooks = new Dictionary<string, string>();
      /// <summary>
      /// random object
      /// </summary>
      private Random rnd = new Random();
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
      private Timer tmrCountdown;
      /// <summary>
      /// instance of the worker class made for this game
      /// </summary>
      IdentifyAreasWorker worker = new IdentifyAreasWorker();
      /// <summary>
      /// instance of the worker class made for this game
      /// </summary>
      PlaySounds sounds = new PlaySounds();
      #endregion 

      public IdentifyAreas(int Timelimit)
      {
         this.timeLimit = Timelimit;
         this.countDown = timeLimit;
         InitializeComponent();
         StartGame();
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
                  panel.BackColor = worker.RandomBrightColor();
               }

               if (panel.Name.Contains("Answer"))
               {
                  this.AnswerShelves.Add(panel);
                  this.RemainingShelves.Add(panel);
                  panel.BackColor = worker.RandomBrightColor();
                  panel.Visible = false;
               }

               if (panel.Name.Contains("Question"))
               {
                  this.QuestionShelves.Add(panel);
                  this.RemainingShelves.Add(panel);
                  panel.BackColor = Color.FromArgb(160, 82, 45);
               }
            }

            this.Books = Books.OrderBy(panel => panel.Name).ToList();
            this.AnswerShelves = AnswerShelves.OrderBy(panel => panel.Name).ToList();
            this.QuestionShelves = QuestionShelves.OrderBy(panel => panel.Name).ToList();
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

            //add the black where the book just was back to the list of where panels can go
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
            foreach (Panel panel in RemainingShelves)
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

            FilterRemaining();
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
            Dictionary<string, string> shuffledDictionary = new Dictionary<string, string>();
            shuffledDictionary = worker.GenerateOrder();
            int answerCount = 0;

            for (int i = 0; i < shuffledDictionary.Count; i++)
            {
               if (!shuffledDictionary.ElementAt(i).Key.Contains("leave"))
               {
                  Label newAnswerLabel = new Label();
                  newAnswerLabel.Name = "BookNumber" + i;
                  newAnswerLabel.Text = shuffledDictionary.ElementAt(i).Key;
                  newAnswerLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                  newAnswerLabel.ForeColor = Color.Black;
                  newAnswerLabel.Top = Books[answerCount].Height / 2 - newAnswerLabel.Height;
                  newAnswerLabel.Height = newAnswerLabel.Height + 5;
                  newAnswerLabel.Left = 3;
                  newAnswerLabel.Enabled = false;
                  newAnswerLabel.UseMnemonic = false;
                  this.Books[answerCount].Controls.Add(newAnswerLabel);
                  this.Books[answerCount].Name = shuffledDictionary.ElementAt(i).Key;
                  this.Books[answerCount].Location = AnswerShelves[answerCount].Location;
                  answerCount++;
               }

               Label newLabel = new Label();
               newLabel.Name = "QuestionNumber" + i;
               newLabel.Text = shuffledDictionary.ElementAt(i).Value;
               newLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
               newLabel.ForeColor = Color.Black;
               newLabel.Top = QuestionShelves[i].Height / 2 - newLabel.Height;
               newLabel.Height = newLabel.Height + 5;
               newLabel.Enabled = false;
               newLabel.Left = QuestionShelves[i].Width / 2;
               newLabel.UseMnemonic = false;
               this.QuestionShelves[i].Controls.Add(newLabel);
            }

            this.SortedBooks = shuffledDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in SortedBooks)
            {
               Console.WriteLine(item.Key);
               Console.WriteLine(item.Value);
            }
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
      /// method to check if any top book shelf is occupied and then update the RemainingTopShelves list
      /// </summary>
      private void FilterRemaining()
      {
         try
         {
            List<Panel> NewRemainingShelves = new List<Panel>(AnswerShelves);
            NewRemainingShelves.AddRange(QuestionShelves);
            List<Panel> IterationList = new List<Panel>(NewRemainingShelves);

            foreach (Panel RPanel in IterationList)
            {
               foreach (Panel book in Books)
               {
                  //if the books and the shelves location line up remove it from the local list
                  if (book.Location == RPanel.Location)
                  {
                     NewRemainingShelves.Remove(NewRemainingShelves.SingleOrDefault(x => x.Name == RPanel.Name));
                  }
               }
            }

            //update the global list
            this.RemainingShelves = NewRemainingShelves;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to check if all books are placed, and if they are in the correct position
      /// </summary>
      /// <returns></returns>
      private bool CheckOrder()
      {
         try
         {
            int placedAnswers = this.QuestionShelves.Count(panel1 => this.Books.Any(panel2 => worker.AreLocationsEqual(panel1, panel2)));

            if (placedAnswers == 4)
            {
               List<string> BookOrder = new List<string>();
               bool Valid = true;
               int validCount = 0;

               //get the location of all placed books
               foreach (Panel panel in this.QuestionShelves)
               {
                  bool populated = false;
                  foreach (Panel book in this.Books)
                  {
                     if (book.Location == panel.Location)
                     {
                        BookOrder.Add(book.Name);
                        populated = true;
                     }
                  }
                  if (populated != true)
                  {
                     BookOrder.Add("null");
                  }
               }


               //check the users order of the books
               for (int i = 0; i < BookOrder.Count; i++)
               {
                  // Compare the dictionary key at the current position with the list element at the same position.
                  if (SortedBooks.ElementAt(i).Key != BookOrder[i])
                  {
                     Valid = false;
                  }
                  else
                  {
                     validCount++;
                  }
               }

               if (validCount == 4)
               {
                  pgbProgress.Value = validCount;
                  Success();
                  return true;
               }

               pgbProgress.Value = validCount;
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
            this.pgbProgress.Value = 4;
            this.tmrCountdown.Enabled = false;

            this._Awards.AddNewEntry(timeLimit, countDown);

            this.Invoke((Action)(() => sounds.PlaySuccess("Success")));

            MessageBox.Show("You Pass");

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
      /// reset button, 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnReset_Click(object sender, EventArgs e)
      {
         if (this.ParentForm is Form1 mainForm)
         {
            mainForm.OpenGame();
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
   }
}
//-----------------------------------------END OF FILE---------------------------------------------