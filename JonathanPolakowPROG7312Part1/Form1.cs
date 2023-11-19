//Jonathan Polakow
//ST10081881
//PROG7312 POE

using JonathanPolakowPROG7312POE.UserControls;
using System;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312POE
{
   public partial class Form1 : Form
   {
      PlayMusic playMusic = new PlayMusic();
      private int selectedGame = 0;
      private int TimeLimit = 0;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// constructor
      /// </summary>
      public Form1()
      {
         InitializeComponent();
         pnlAwards.Visible = false;
         pnlChooseDifficulty.Visible = false;
         pnlMenu.Visible = true;
         pnlPlaceBooks.Visible = false;
         pnlFindCallNumbers.Visible = false;
         PlayMusic();

         selectDifficulty1 = new SelectDifficulty(this);
         selectDifficulty1.timeLimit += (sender, timeLimit) =>
         {
            this.TimeLimit = timeLimit;
            OpenGame();
         };
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to start playing the background music
      /// </summary>
      private async void PlayMusic()
      {
         playMusic.PlayMusicMethod();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// Method thats called when the UserControl is closed
      /// </summary>
      public void CloseUserControl()
      {
         try
         {
            pnlChooseDifficulty.Controls.Clear();
            pnlIdentifyAreas.Controls.Clear();
            pnlPlaceBooks.Controls.Clear();
            pnlAwards.Visible = false;
            pnlChooseDifficulty.Visible = false;
            pnlIdentifyAreas.Visible = false;
            pnlPlaceBooks.Visible = false;
            pnlFindCallNumbers.Visible = false;
            pnlMenu.Visible = true;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Oops, something went wrong, please try again");
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to open the correct game and pass the timelimit
      /// this is called when selectdifficulty returns a value for the timelimit
      /// this can also be used to restart the game as the values are saved before laoding the game
      /// </summary>
      public void OpenGame()
      {

         try
         {
            pnlIdentifyAreas.Controls.Clear();
            pnlPlaceBooks.Controls.Clear();
            pnlFindCallNumbers.Controls.Clear();

            switch (this.selectedGame)
            {
               case 1:
                  //bookShelf1 is located in the designer code
                  bookShelf1 = new BookShelf(this.TimeLimit);
                  bookShelf1.Left = (this.ClientSize.Width - bookShelf1.Width) / 2;
                  bookShelf1.Top = (this.ClientSize.Height - bookShelf1.Height) / 2;
                  pnlPlaceBooks.Controls.Add(bookShelf1);
                  pnlMenu.Visible = false;
                  pnlChooseDifficulty.Visible = false;
                  pnlPlaceBooks.Visible = true;
                  break;
               case 2:
                  //identifyAreas1 is located in the designer code
                  identifyAreas1 = new IdentifyAreas(this.TimeLimit);
                  identifyAreas1.Left = (this.ClientSize.Width - identifyAreas1.Width) / 2;
                  identifyAreas1.Top = (this.ClientSize.Height - identifyAreas1.Height) / 2;
                  pnlIdentifyAreas.Controls.Add(identifyAreas1);
                  pnlMenu.Visible = false;
                  pnlChooseDifficulty.Visible = false;
                  pnlIdentifyAreas.Visible = true;
                  break;
               case 3:
                  //findCallNumber1 is located in the designer code
                  findCallNumber1 = new FindCallNumber(this.TimeLimit);
                  findCallNumber1.Left = (this.ClientSize.Width - findCallNumber1.Width) / 2;
                  findCallNumber1.Top = (this.ClientSize.Height - findCallNumber1.Height) / 2;
                  pnlFindCallNumbers.Controls.Add(findCallNumber1);
                  pnlMenu.Visible = false;
                  pnlChooseDifficulty.Visible = false;
                  pnlFindCallNumbers.Visible = true;
                  break;
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
      /// method to create a insance of the select diff user control and pass it the local Form1 isntance
      /// </summary>
      private void ShowDiff()
      {
         selectDifficulty1.Left = 0;
         selectDifficulty1.Top = 0;
         pnlChooseDifficulty.Controls.Add(selectDifficulty1);
         pnlChooseDifficulty.Visible = true;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnPlaceBooks_Click, calls select diff
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnPlaceBooks_Click(object sender, EventArgs e)
      {
         this.selectedGame = 1;
         pnlMenu.Visible = false;
         pnlChooseDifficulty.Visible = true;
         ShowDiff();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnIdentifyAreas_Click, calls select diff
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnIdentifyAreas_Click(object sender, EventArgs e)
      {
         this.selectedGame = 2;
         pnlMenu.Visible = false;
         ShowDiff();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnAwards_Click, loads awards
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnAwards_Click(object sender, EventArgs e)
      {
         //awards1 is located in the designer code
         awards1 = new Awards();
         awards1.Left = (this.ClientSize.Width - awards1.Width) / 2;
         awards1.Top = (this.ClientSize.Height - awards1.Height) / 2;
         pnlAwards.Controls.Add(awards1);

         pnlMenu.Visible = false;
         pnlAwards.Visible = true;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnFindCallNums_Click, calls select diff
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnFindCallNums_Click(object sender, EventArgs e)
      {
         this.selectedGame = 3;
         pnlMenu.Visible = false;
         ShowDiff();
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------
