using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades_NetFrame
{
    class Program
    {
        static void Main(string[] args)
        {

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");

            //GradeBook book = new ThrowAwayGradeBook(); //Variable that can be used to access the class GradeBook (variable of type GradeBook.

            IGradeTracker book = CreateGradeBook();

            // Since the delegate is an event we no longer need the "new NameChangedEvent()" to add a subscriber.
            //book.NameChanged += OnNameChanged; //Take whatever is in NameChanged and add this delegate to it.

            GetBookName(book);

            AddGrades(book);

            //This would create a new object, gradebook, in memory and assign book2 the memory location.
            //GradeBook book2 = new GradeBook();
            //book2.AddGrade(75);

            //GradeBook book3 = book; //This creates the book3 variable which will have the memory location of book assigned to it.
            //Now any additions to book3 also impact book because they are referencing the same object at the specified memory location (Very Important).
            //book3.AddGrade(15);

            SaveGrades(book);

            WriteResults(book);
        }

        private static void GetBookName(IGradeTracker book)
        {
            //book.Name = "Chris' Grade Book";
            //book.Name = null; //Based on the code in the property Name this will be ignored.
            Console.WriteLine("Please enter a name");

            try
            {
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); //Outputs the exception message to the screen.
            }
            catch (NullReferenceException) //Catches a NULL exception.
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f); //f tells the compiler that the value is a float and not double.
            book.AddGrade(15);
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics(); //Runs ComputerStatistics and places the values at the memory locations for the fields in the object stats.

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Max Grade", (int)stats.HighestGrade); //Type coercion/conversion from float to int
            WriteResult("Min Grade", (int)stats.LowestGrade); //Type coercion/conversion from float to int
            WriteResult(stats.LetterGrade, stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            //Using ensures that the resources are cleaned up (close and dispose) even if exception encountered.
            using (StreamWriter outputFile = File.CreateText(@"C:\users\chris.kenny\desktop\grades.txt")) //Have to use the @ to escape the filepath.
            {
                book.WriteGrades(outputFile); //Provides the output stream as the input variable. In this instance it will cause the function to output to the screen.
            }
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
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
