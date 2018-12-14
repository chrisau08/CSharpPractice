using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_NetFrame
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

        //Contain all computations within the public function.
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades) //specify the variable to hold the value from the list "grades" as the list is looped through.
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); //Math.Max will return the highest value given two inputs.
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade); //Math.Min will return the lowest value given two inputs.
                sum += grade; //+= will add the value on the right to the value on the left and store in the variable on the left.
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
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
