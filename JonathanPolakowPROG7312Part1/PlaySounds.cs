using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanPolakowPROG7312POE
{
   internal class PlaySounds
   {

      private WMPLib.WindowsMediaPlayer WMPPlaySound;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// async method to play a sound effect
      /// </summary>
      /// <param name="url"></param>
      public async void PlaySound(string url)
      {
         try
         {
            if (WMPPlaySound == null)
            {
               WMPPlaySound = new WMPLib.WindowsMediaPlayer();
            }

            await Task.Run(() =>
            {
               WMPPlaySound.URL = url + ".mp3";
               WMPPlaySound.controls.play();
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
   }
}
