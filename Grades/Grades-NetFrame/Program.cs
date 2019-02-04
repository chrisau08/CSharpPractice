using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades_NetFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook(); //Variable that can be used to access the class GradeBook (variable of type GradeBook.

            // Since the delegate is an event we no longer need the "new NameChangedEvent()" to add a subscriber.
            book.NameChanged += OnNameChanged; //Take whatever is in NameChanged and add this delegate to it.

            book.Name = "Chris' Grade Book";
            book.Name = null; //Based on the code in the property Name this will be ignored.
            book.AddGrade(91);
            book.AddGrade(89.5f); //f tells the compiler that the value is a float and not double.

            //This would create a new object, gradebook, in memory and assign book2 the memory location.
            GradeBook book2 = new GradeBook();
            book2.AddGrade(75);

            GradeBook book3 = book; //This creates the book3 variable which will have the memory location of book assigned to it.
            //Now any additions to book3 also impact book because they are referencing the same object at the specified memory location (Very Important).
            book3.AddGrade(15);

            GradeStatistics stats = book.ComputeStatistics(); //Runs ComputerStatistics and places the values at the memory locations for the fields in the object stats.
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Max Grade", (int)stats.HighestGrade); //Type coercion/conversion from float to int
            WriteResult("Min Grade", (int)stats.LowestGrade); //Type coercion/conversion from float to int
            WriteResult("Grade", stats.LetterGrade);
        }
        
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, int result) //Must be static because the Main procedure is static and it will be calling this procedure.
        {
            Console.WriteLine($"{description}: {result}", description, result); //This method will place the values in their specified locations in the string.
        }

        static void WriteResult(string description, float result) //Must be static because the Main procedure is static and it will be calling this procedure.
        {
            Console.WriteLine("{0}: {1:F2}", description, result); //The 0 and 1 are placeholders for the elements in positions. Description would go to {0}; Result would go to {1}. Also displays the result as a float with 2 decimal places.
        }

        static void WriteResult(string description, string result) //Must be static because the Main procedure is static and it will be calling this procedure.
        {
            Console.WriteLine("{0}: {1}", description, result); //The 0 and 1 are placeholders for the elements in positions. Description would go to {0}; Result would go to {1}. Also displays the result as a float with 2 decimal places.
        }
    }
}
