//Jonathan Polakow
//ST10081881
//PROG7312 POE

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanPolakowPROG7312POE
{
   using NAudio.Wave;
   using System;
   using System.IO;

   internal class PlaySounds
   {

      private WaveOutEvent waveOutEvent;

      public PlaySounds()
      {
         waveOutEvent = new WaveOutEvent();
      }

      public async Task PlayBookPlace(string fileName)
      {
         try
         {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".mp3");

            if (!File.Exists(filePath))
            {
               Console.WriteLine($"File not found: {filePath}");
               return;
            }

            var audioFileReader = new AudioFileReader(filePath);

            // Hook up an event to dispose of the AudioFileReader when playback finishes
            audioFileReader.Position = 0;

            waveOutEvent.Init(audioFileReader);
            waveOutEvent.Play();

            // Use an async wait for playback to finish
            await Task.Run(() =>
            {
               while (waveOutEvent.PlaybackState == PlaybackState.Playing)
               {
                  Task.Delay(100).Wait();
               }
            });
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private WMPLib.WindowsMediaPlayer WMPPlaySound1;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// async method to play a sound effect
      /// </summary>
      /// <param name="url"></param>
      public async void PlaySuccess(string url)
      {
         try
         {
            if (WMPPlaySound1 == null)
            {
               WMPPlaySound1 = new WMPLib.WindowsMediaPlayer();
            }

            await Task.Run(() =>
            {
               if (WMPPlaySound1.playState == WMPLib.WMPPlayState.wmppsPlaying)
               {
                  return;
               }

               WMPPlaySound1.URL = url + ".mp3";
               WMPPlaySound1.controls.play();
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
