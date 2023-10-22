using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312POE
{
   public partial class SelectDifficulty : UserControl
   {
    //  private Form1 mainForm;

      public event EventHandler<int> timeLimit;

      public SelectDifficulty()
      {
         InitializeComponent();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnCasual_Click, starts a casual place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnCasual_Click(object sender, EventArgs e)
      {
         //mainForm.LoadPlaceBooks(0);
         timeLimit?.Invoke(this, 0);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnEasy_Click, starts a easy place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnEasy_Click(object sender, EventArgs e)
      {
         //mainForm.LoadPlaceBooks(90);
         timeLimit?.Invoke(this, 90);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnMedium_Click, starts a medium place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnMedium_Click(object sender, EventArgs e)
      {
         //mainForm.LoadPlaceBooks(45);
         timeLimit?.Invoke(this, 45);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnHard_Click, starts a hard place book game
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnHard_Click(object sender, EventArgs e)
      {
         //mainForm.LoadPlaceBooks(15);
         timeLimit?.Invoke(this, 15);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// btnBack_Click, sends the user back the menu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnBack_Click(object sender, EventArgs e)
      {
        // mainForm.CloseUserControl();
      }
   }
}
