using System;

namespace SleepIntro
{
    class Actions
    {
        public static void Sleep(int hours)
        {
            if (hours > 7)
            {
                Console.WriteLine("You are well rested.");
            }
            else
            {
                Console.WriteLine("You need more rest.");
            }
        }
    }
    class Program
    {
        static string SleepChk(int hours)
        {
            string msg;

            if (hours > 7)
            {
                msg = "You are well rested.";
            }
            else
            {
                msg = "You need more rest.";
            }

            return msg;
        }

        static void Main(string[] args)
        {
            string name;
            string SlpMsg;

            //Prompt user
            Console.WriteLine("Your name:");
            name = Console.ReadLine();

            //Clear prompt and respond
            Console.Clear();
            Console.WriteLine("Hello " + name);
            Console.ReadKey();

            //Clear response and prompt user
            Console.Clear();
            Console.WriteLine("How many hours of sleep did you get last night?");
            int hoursOfSleep = int.Parse(Console.ReadLine());

            //Clear prompt and respond
            Console.Clear();
            //Actions.Sleep(hoursOfSleep);
            SlpMsg = SleepChk(hoursOfSleep);

            Console.WriteLine(SlpMsg);

            //if (hoursOfSleep >= 8)
            //{
            //    Console.WriteLine("You are well rested.");
            //}
            //else
            //{
            //    Console.WriteLine("Go back to sleep.");
            //}

            Console.ReadKey();
        }
    }
}
