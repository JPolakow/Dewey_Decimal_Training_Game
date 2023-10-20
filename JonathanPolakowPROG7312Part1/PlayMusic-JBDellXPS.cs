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
                  WindowsMediaPlayer WMPPlaySound = new WindowsMediaPlayer();
                  WMPPlaySound.URL = "chillmusic.mp3";
                  WMPPlaySound.settings.setMode("loop", true);
                  WMPPlaySound.controls.play();

                  soundPlayers.Add(WMPPlaySound);
                  notPlaying = false;
               });
            }
         }
         catch { }
      }
   }
}
