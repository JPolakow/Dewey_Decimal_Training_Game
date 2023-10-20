//Jonathan Polakow
//ST10081881
//PROG7312 POE part 1

using System;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312Part1
{
   public partial class Form1 : Form
   {
      PlayMusic playMusic = new PlayMusic();

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
         PlayMusic();
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
      /// method to load the replace book user control
      /// needs to load programily or it will be created with a empty timelimit
      /// </summary>
      /// <param name="timeLimit"></param>
      private void LoadPlaceBooks(int timeLimit)
      {
         //bookShelf1 is located in the designer code
         bookShelf1 = new BookShelf(timeLimit);
         bookShelf1.Left = (this.ClientSize.Width - bookShelf1.Width) / 2;
         bookShelf1.Top = (this.ClientSize.Height - bookShelf1.Height) / 2;
         pnlPlaceBooks.Controls.Add(bookShelf1);

         pnlChooseDifficulty.Visible = false;
         pnlPlaceBooks.Visible = true;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// Method thats called when the UserControl is closed
      /// </summary>
      public void CloseUserControl()
      {
         pnlPlaceBooks.Controls.Clear();
         pnlAwards.Visible = false;
         pnlChooseDifficulty.Visible = false;
         pnlMenu.Visible = true;
         pnlPlaceBooks.Visible = false;
      }
      
      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnPlaceBooks_Click, calls the place book panel
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnPlaceBooks_Click(object sender, EventArgs e)
      {
         pnlMenu.Visible = false;
         pnlChooseDifficulty.Visible = true;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnCasual_Click, starts a casual place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnCasual_Click(object sender, EventArgs e)
      {
         LoadPlaceBooks(0);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnEasy_Click, starts a easy place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnEasy_Click(object sender, EventArgs e)
      {
         LoadPlaceBooks(90);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnMedium_Click, starts a medium place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnMedium_Click(object sender, EventArgs e)
      {
         LoadPlaceBooks(45);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnHard_Click, starts a hard place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnHard_Click(object sender, EventArgs e)
      {
         LoadPlaceBooks(15);
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
   }
}
//-----------------------------------------END OF FILE---------------------------------------------

//  to do
//awards front end
//sorting algo
//ask rudolf if nuget are libraries
//back buttons
