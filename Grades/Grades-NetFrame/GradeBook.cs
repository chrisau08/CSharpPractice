using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_NetFrame
{
    //Class GradeBook is being used as a blueprint for creating objects (or types). Consider this like an object in PL-SQL.
    //Additionally, a class is default to the internal keyword which means only available within the same assembly (project) unless explicitly marked as public.
    public class GradeBook : GradeTracker
    {
        //static makes the object or function available without the code having to create a new instance of it.
        public static float MinimumGrade = 0; //So this can be called in something like console.writeline as GradeBook.MinimumGrade without needing "new MinimumGrade"
        public static float MaximumGrade = 100;

        //Constructor for the class GradeBook to instantiate or initialize the object.
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>(); //List that can hold 0 or more numbers
        }

        //Contain all computations within the public function.
        //Specifying virtual will have the compiler use whatever object is passed instead of using the function with the matching object type.
        //Since Gradebook is inheriting from GradeTracker the override must be specified instead of virtual. Abstract is treated like virtual in the base class.
        public override GradeStatistics ComputeStatistics()
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

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        //This can actually be written as public void AddGrade(float grade) => grades.Add(grade);
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        //If you don't specify the access modifier (public, private, etc) then it is a private member (as opposed to public).
        protected List<float> grades; //protected can be accessed by the class or a class that has inherited from the class
    }
}
