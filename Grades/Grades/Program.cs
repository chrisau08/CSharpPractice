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

            GradeBook book2 = new GradeBook();
            book2.AddGrade(75);
        }
    }
}
