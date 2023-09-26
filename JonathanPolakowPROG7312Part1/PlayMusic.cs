//Jonathan Polakow
//ST10081881
//PROG7312 POE part 1

using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace JonathanPolakowPROG7312Part1
{
   internal class PlayMusic
   {
      /// <summary>
      /// list of WindowsMediaPlayers, this keeps the media playing in context
      /// </summary>
      private List<WindowsMediaPlayer> soundPlayers = new List<WindowsMediaPlayer>();
      /// <summary>
      /// bool to prevent the media player starting another song
      /// </summary>
      private bool notPlaying = true;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to play music in the background
      /// needs to be async inorder to not slow down the app
      /// </summary>
      public async void PlayMusicMethod()
      {
         try
         {
            if (notPlaying)
            {
               await Task.Run(() =>
               {
                  //WindowsMediaPlayer is not thread safe so extra precautions need to be taken
                  //such as running it on the main thread and a empty catch
                  WindowsMediaPlayer WMPPlaySound = new WindowsMediaPlayer();
                  WMPPlaySound.URL = "chillmusic.mp3";
                  WMPPlaySound.settings.setMode("loop", true);
                  WMPPlaySound.controls.play();

                  soundPlayers.Add(WMPPlaySound);
                  notPlaying = false;
               });
            }
         }
         catch
         {
            //I am aware that empty catches are not good practice, in this case they work the best
            //This method plays sound effects, thus it is called alot, if a thredding or other issue happens then this catch prevents a crash 
            //displaying a popup is overkill and will disrupt the user experiance, not playing a sound effect is a better outcome
         }
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------