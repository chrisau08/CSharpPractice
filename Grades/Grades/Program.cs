using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook(); //Variable that can be used to access the class GradeBook (variable of type GradeBook.
            book.AddGrade(91);
            book.AddGrade(89.5f); //f tells the compiler that the value is a float and not double.

            //This would create a new object, gradebook, in memory and assign book2 the memory location.
            GradeBook book2 = new GradeBook();
            book2.AddGrade(75);

            GradeBook book3 = book; //This creates the book3 variable which will have the memory location of book assigned to it.
            //Now any additions to book3 also impact book because they are referencing the same object at the specified memory location (Very Important).
            book3.AddGrade(15);
        }
    }
}
