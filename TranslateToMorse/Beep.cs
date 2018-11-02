using System.Collections.Generic;

namespace TranslateToMorse
{
    public class Beeps
    {
        private static Dictionary<char, string> _beepCode = new Dictionary<char, string>
        {
            
        };

        

        //    protected static void ToBeep(Note[] tune)
        //    {
        //        foreach (Note n in tune)
        //        {
        //            if (n.NoteTone == Tone.REST)
        //                Thread.Sleep((int)n.NoteDuration);
        //            else
        //                Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
        //        }
        //    }

        //    protected enum Tone
        //    {
        //        n = 800
        //    }

        //    protected enum Duration
        //    {
        //        dot = 200,
        //        dash = 600,
        //    }

        //    protected struct Beep
        //    {
        //        Tone toneVal;
        //        Duration durVal;

        //        public Beep(Tone frequency, Duration time)
        //        {
        //            toneVal = frequency;
        //            durVal = time;
        //        }

        //        public Tone BeepTone { get { return toneVal; } }
        //        public Duration BeepDuration { get { return durVal; } }
        //    }
    }

}

