//Jonathan Polakow
//ST10081881
//PROG7312 POE Part 2

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
         //PlayMusic();

         selectDifficulty1.timeLimit += (sender, timeLimit) =>
         {
            TimeLimit = timeLimit;
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
            pnlPlaceBooks.Controls.Clear();
            pnlAwards.Visible = false;
            pnlChooseDifficulty.Visible = false;
            pnlIdentifyAreas.Visible = false;
            pnlPlaceBooks.Visible = false;
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
      /// Method thats called when the UserControl is closed
      /// </summary>
      public void restartUserControl(UserControl name)
      {
         try
         {
            //bookShelf1 is located in the designer code
            pnlIdentifyAreas.Controls.Clear();
            identifyAreas1 = new IdentifyAreas(0);
            identifyAreas1.Left = (this.ClientSize.Width - identifyAreas1.Width) / 2;
            identifyAreas1.Top = (this.ClientSize.Height - identifyAreas1.Height) / 2;
            pnlIdentifyAreas.Controls.Add(identifyAreas1);

            pnlMenu.Visible = false;
            pnlIdentifyAreas.Visible = true;
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

            switch (selectedGame)
            {
               case 1:
                  //bookShelf1 is located in the designer code
                  bookShelf1 = new BookShelf(TimeLimit);
                  bookShelf1.Left = (this.ClientSize.Width - bookShelf1.Width) / 2;
                  bookShelf1.Top = (this.ClientSize.Height - bookShelf1.Height) / 2;
                  pnlPlaceBooks.Controls.Add(bookShelf1);
                  pnlMenu.Visible = false;
                  pnlChooseDifficulty.Visible = false;
                  pnlPlaceBooks.Visible = true;
                  break;
               case 2:
                  //identifyAreas1 is located in the designer code
                  identifyAreas1 = new IdentifyAreas(TimeLimit);
                  identifyAreas1.Left = (this.ClientSize.Width - identifyAreas1.Width) / 2;
                  identifyAreas1.Top = (this.ClientSize.Height - identifyAreas1.Height) / 2;
                  pnlIdentifyAreas.Controls.Add(identifyAreas1);
                  pnlMenu.Visible = false;
                  pnlChooseDifficulty.Visible = false;
                  pnlIdentifyAreas.Visible = true;
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
      /// btnPlaceBooks_Click, calls select diff
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnPlaceBooks_Click(object sender, EventArgs e)
      {
         selectedGame = 1;
         pnlMenu.Visible = false;
         pnlChooseDifficulty.Visible = true;
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
      /// btnIdentifyAreas_Click, calls select diff
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnIdentifyAreas_Click(object sender, EventArgs e)
      {
         selectedGame = 2;
         pnlMenu.Visible = false;
         pnlChooseDifficulty.Visible = true;
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------

/*TO DO
 * front end
 * uncomment play music
 * back button from diff
 * check that my front end code amout change is ok
 */

/*CHANGED 
 * mocved play soudns to another class
 * fixed reset
 * moved code out of form 1 into select difficulty user control
 * placed funualnaity into worker class
 * 
 */