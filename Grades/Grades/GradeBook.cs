using System;
using System.Collections.Generic;
using System.Text;

namespace Grades
{
    //Class GradeBook is being used as a blueprint for creating objects (or types). Consider this like an object in PL-SQL.
    class GradeBook
    {
        //static makes the object or function available without the code having to create a new instance of it.
        public static float MinimumGrade = 0; //So this can be called in something like console.writeline as GradeBook.MinimumGrade without needing "new MinimumGrade"
        public static float MaximumGrade = 100;

        //Constructor for the class GradeBook to instantiate or initialize the object.
        public GradeBook()
        {
            grades = new List<float>(); //List that can hold 0 or more numbers
        }

        //This can actually be written as public void AddGrade(float grade) => grades.Add(grade);
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //If you don't specify the access modifier (public, private, etc) then it is a private member (as opposed to public).
        List<float> grades;
    }
}
