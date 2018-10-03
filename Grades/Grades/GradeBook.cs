using System;
using System.Collections.Generic;
using System.Text;

namespace Grades
{
    //Class GradeBook is being used as a blueprint for creating objects (or types). Consider this like an object in PL-SQL.
    class GradeBook
    {
        //Constructor for the class GradeBook to instantiate or initialize the object.
        public GradeBook()
        {
            grades = new List<float>(); //List that can hold 0 or more numbers
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        List<float> grades;
    }
}
