//Jonathan Polakow
//ST10081881
//PROG7312 POE

namespace JonathanPolakowPROG7312POE
{
   internal class AwardsModelSingleton
   {
      /// <summary>
      /// makes this model a singleton, creats one instance and then hands that instance to all calling objects
      /// this allows it to store counts of awards nativly and be able to have external classes send and retreive data without the new keyword
      /// </summary>
      private static readonly AwardsModelSingleton instance = new AwardsModelSingleton();
      public static AwardsModelSingleton Instance => instance;

      public int CompleteEasy1 { get => CompleteEasy; set => CompleteEasy = value; }
      public int CompleteMedium1 { get => CompleteMedium; set => CompleteMedium = value; }
      public int CompleteHard1 { get => CompleteHard; set => CompleteHard = value; }
      public int HalveEasy1 { get => HalveEasy; set => HalveEasy = value; }
      public int HalveMedium1 { get => HalveMedium; set => HalveMedium = value; }
      public int HalveHard1 { get => HalveHard; set => HalveHard = value; }

      private int CompleteEasy = 0;
      private int CompleteMedium = 0;
      private int CompleteHard = 0;
      private int HalveEasy = 0;
      private int HalveMedium = 0;
      private int HalveHard = 0;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// Method that takes in the teri and the timer taken to compelte the tier
      /// it then calls a method to process the correct tier
      /// </summary>
      /// <param name="tier"></param>
      /// <param name="time"></param>
      public void AddNewEntry(int tier, int time)
      {
         switch (tier)
         {
            case 0: // casual
               break;
            case 90: //easy
               Easy(time);
               break;
            case 45: //medium
               Medium(time);
               break;
            case 15: //hard
               Hard(time);
               break;
            default: break;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method ot handel the completion of easy 
      /// </summary>
      /// <param name="time"></param>
      private void Easy(int time)
      {
         CompleteEasy++;
         if (time > 90 / 2)
         {
            HalveEasy++;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method ot handel the completion of medium 
      /// </summary>
      /// <param name="time"></param>
      private void Medium(int time)
      {
         CompleteMedium++;
         if (time > 45 / 2)
         {
            HalveMedium++;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method ot handel the completion of hard 
      /// </summary>
      /// <param name="time"></param>
      private void Hard(int time)
      {
         CompleteHard++;
         if (time > 15 / 2)
         {
            HalveHard++;
         }
      }
   }
}
//-----------------------------------------END OF FILE---------------------------------------------