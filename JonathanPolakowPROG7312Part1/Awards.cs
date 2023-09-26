//Jonathan Polakow
//ST10081881
//PROG7312 POE part 1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JonathanPolakowPROG7312Part1
{
   public partial class Awards : UserControl
   {
      /// <summary>
      /// awards model singleton
      /// </summary>
      private AwardsModelSingleton _Awards = AwardsModelSingleton.Instance;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// constructor
      /// </summary>
      public Awards()
      {
         InitializeComponent();
         LoadAwards();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to laod the awards to the front end and then ajust the layout
      /// </summary>
      private void LoadAwards()
      {
         lblEasy.Text = "Beat Easy: "+_Awards.CompleteEasy1.ToString();
         lblEasy.Left = this.Width /2  - lblEasy.Width;
         lblEasyHalve.Text = "Beat Easy in under half time: " + _Awards.HalveEasy1.ToString();
         lblEasyHalve.Left = this.Width / 2 - lblEasyHalve.Width;
         lblMedium.Text = "Beat Medium: " + _Awards.CompleteMedium1.ToString();
         lblMedium.Left = this.Width / 2 - lblMedium.Width;
         lblMediumHalve.Text = "Beat Medium in under half time: " + _Awards.HalveMedium1.ToString();
         lblMediumHalve.Left = this.Width / 2 - lblMediumHalve.Width;
         lblHard.Text = "Beat Hard: " + _Awards.CompleteHard1.ToString();
         lblHard.Left = this.Width / 2 - lblHard.Width;
         lblHardHalve.Text = "Beat Hard in under half time: " + _Awards.CompleteHard1.ToString();
         lblHardHalve.Left = this.Width / 2 - lblHardHalve.Width;
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// reset button, calls the main form and disposes itself
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void BtnReset_Click(object sender, EventArgs e)
      {
         if (this.ParentForm is Form1 mainForm)
         {
            mainForm.CloseUserControl();
         }

         this.Dispose();
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------