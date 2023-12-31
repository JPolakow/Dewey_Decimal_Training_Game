﻿//Jonathan Polakow
//ST10081881
//PROG7312 POE part 1

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312Part1
{
   public partial class BookShelf : UserControl
   {
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
      private List<Panel> TopShelves = new List<Panel>();
      /// <summary>
      /// list of all the bottom panels
      /// </summary>
      private List<Panel> BottomShelves = new List<Panel>();
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

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// constructor
      /// </summary>
      /// <param name="Timelimit"></param>
      public BookShelf(int Timelimit)
      {
         timeLimit = Timelimit;
         countDown = timeLimit;
         InitializeComponent();
         FilterPanelsIntoLists();
         PopulateBooks();
         StartGame();
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
                  Books.Add(panel);
                  ControlExtension.Draggable(panel, true);
                  panel.MouseDown += Panel_MouseDown;
                  panel.MouseUp += Panel_MouseUp;
                  panel.BackColor = RandomBrightColor();
               }

               if (panel.Name.Contains("Top"))
               {
                  TopShelves.Add(panel);
                  RemainingShelves.Add(panel);
                  panel.Visible = false;
               }

               if (panel.Name.Contains("Bottom"))
               {
                  BottomShelves.Add(panel);
                  RemainingShelves.Add(panel);
                  panel.Visible = false;
               }
            }

            Books = Books.OrderBy(panel => panel.Name).ToList();
            TopShelves = TopShelves.OrderBy(panel => panel.Name).ToList();
            BottomShelves = BottomShelves.OrderBy(panel => panel.Name).ToList();
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
      /// initialiser method to set up the timer
      /// </summary>
      private void StartGame()
      {
         try
         {
            tmrCountdown = new System.Windows.Forms.Timer();
            tmrCountdown.Tick += new EventHandler(tmrCountdown_Tick);
            tmrCountdown.Interval = 1000; // 1 second

            if (timeLimit > 0)
            {
               tmrCountdown.Start();
               lblCountdown.Text = timeLimit.ToString();
               lblCountdown.Visible = true;
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
      /// the timers tick method
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tmrCountdown_Tick(object sender, EventArgs e)
      {
         try
         {
            countDown--;

            if (countDown == 0)
            {
               tmrCountdown.Enabled = false;
               tmrCountdown.Stop();

               if (CheckOrder())
               {
               }
               else
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
            List<Panel> AllShelves = new List<Panel>(TopShelves);
            AllShelves.AddRange(BottomShelves);
            Control book = sender as Control;
            foreach (Panel panel in AllShelves)
            {
               if (book.Location == panel.Location & !(RemainingShelves.Contains(panel)))
               {
                  RemainingShelves.Add(panel);
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

            PlaySound("BookPlace");
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
            //list of the randomly generated Dewey Decimal numbers
            List<string> DeweyDecimalList = new List<string>();

            DeweyDecimalLibrary.Class1 generateDeweyDecimal = new DeweyDecimalLibrary.Class1();

            for (int i = 0; i < Books.Count; i++)
            {
               DeweyDecimalList.Add(generateDeweyDecimal.GenerateDeweyDecimal());
            }

            //put numebrs on book
            for (int i = 0; i < Books.Count; i++)
            {
               Label newLabel = new Label();
               newLabel.Name = "BookNumber" + i;
               newLabel.Text = DeweyDecimalList[i];
               newLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
               newLabel.ForeColor = Color.Black;
               newLabel.Top = Books[i].Height / 2 - newLabel.Height;
               newLabel.Height = newLabel.Height + 5;
               newLabel.Enabled = false;
               Books[i].Controls.Add(newLabel);

               SortedBooks.Add(Books[i].Name, DeweyDecimalList[i]);
            }

            //sort the list using a modified bubble sort
            SortedBooks = BubbleSort(SortedBooks);
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
      /// method to check if any top book shelf is occupied and then update the RemainingTopShelves list
      /// </summary>
      private void FilterRemaining()
      {
         try
         {
            List<Panel> NewRemainingShelves = new List<Panel>(TopShelves);
            NewRemainingShelves.AddRange(BottomShelves);
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
            RemainingShelves = NewRemainingShelves;
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
            List<string> BookOrder = new List<string>();
            bool Valid = true;
            int validCount = 0;

            //check if each top shelve has a book
            foreach (Panel RPanel in TopShelves)
            {
               bool placed = false;

               foreach (Panel book in Books)
               {
                  if (book.Location == RPanel.Location)
                  {
                     BookOrder.Add(book.Name);
                     placed = true;
                  }
               }

               //if the panel is empty the user has not finished placing the books
               if (placed == false)
               {
                  Valid = false;
                  BookOrder.Add(null);
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

            pgbProgress.Value = validCount;

            if (Valid)
            {
               Success();
               return true;
            }

            return false;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
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
            pgbProgress.Value = 10;
            tmrCountdown.Enabled = false;

            _Awards.AddNewEntry(timeLimit, countDown);

            PlaySound("Success");
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
            tmrCountdown.Enabled = false;
            PlaySound("Fail");
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
      /// method to generate a random color with a bias towards a brighter color
      /// </summary>
      /// <returns></returns>
      private Color RandomBrightColor()
      {
         Color randomColor = Color.FromArgb(rnd.Next(100, 200), rnd.Next(100, 200), rnd.Next(100, 200));
         return randomColor;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// async method to play a sound effect
      /// </summary>
      /// <param name="url"></param>
      private async void PlaySound(string url)
      {
         try
         {
            //needs to use await and invoke as WindowsMediaPlayer is not thread safe
            //caused issues that were solved by adding both.
            await Task.Run(() =>
            {
               this.Invoke((Action)(() =>
               {
                  WMPLib.WindowsMediaPlayer WMPPlaySound = new WMPLib.WindowsMediaPlayer();
                  WMPPlaySound.URL = url + ".mp3";
                  WMPPlaySound.controls.play();
               }));
            });
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            //I am aware that empty catches are not good practice, in this case they work the best
            //This method plays sound effects, thus it is called alot, if a thredding or other issue happens then this catch prevents a crash 
            //displaying a popup is overkill and will disrupt the user experiance, not playing a sound effect is a better outcome
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
         BackToMenu();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// calls the main form and disposes itself
      /// </summary>
      private void BackToMenu()
      {
         try
         {
            tmrCountdown.Stop();
            tmrCountdown.Dispose();

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
      /// Bubble sort to loop through a dictionary and sort
      /// this bubble has been tested and with all identical numbers it is able to sort the letters aswell
      /// </summary>
      /// <param name="dictionary"></param>
      /// <returns></returns>
      private static Dictionary<string, string> BubbleSort(Dictionary<string, string> dictionary)
      {
         try
         {
            //source: ChatGPT, and alot of manual fixing

            var sortedPairs = dictionary.ToList();

            for (int i = 0; i < sortedPairs.Count - 1; i++)
            {
               for (int j = 0; j < sortedPairs.Count - i - 1; j++)
               {
                  if (string.Compare(sortedPairs[j].Value, sortedPairs[j + 1].Value, StringComparison.Ordinal) > 0)
                  {
                     var temp = sortedPairs[j];
                     sortedPairs[j] = sortedPairs[j + 1];
                     sortedPairs[j + 1] = temp;
                  }
               }
            }

            var sortedDictionary = new Dictionary<string, string>();

            foreach (var pair in sortedPairs)
            {
               sortedDictionary.Add(pair.Key, pair.Value);
            }

            return sortedDictionary;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
            return dictionary;
         }
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------