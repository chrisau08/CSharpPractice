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
            book.AddGrade(91);
            book.AddGrade(89.5f); //f tells the compiler that the value is a float and not double.

            //This would create a new object, gradebook, in memory and assign book2 the memory location.
            GradeBook book2 = new GradeBook();
            book2.AddGrade(75);

            GradeBook book3 = book; //This creates the book3 variable which will have the memory location of book assigned to it.
            //Now any additions to book3 also impact book because they are referencing the same object at the specified memory location (Very Important).
            book3.AddGrade(15);

            GradeStatistics stats = book.ComputeStatistics(); //Runs ComputerStatistics and places the values at the memory locations for the fields in the object stats.
            Console.WriteLine("Avg Grade: " + stats.AverageGrade); //Displays value of 65.16666
            Console.WriteLine("Max Grade: " + stats.HighestGrade); //Displays value of 91
            Console.WriteLine("Min Grade: " + stats.LowestGrade); //Displays value of 15
        }
    }
}
