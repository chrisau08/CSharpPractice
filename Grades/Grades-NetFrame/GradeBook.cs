using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_NetFrame
{
    //Class GradeBook is being used as a blueprint for creating objects (or types). Consider this like an object in PL-SQL.
    //Additionally, a class is default to the internal keyword which means only available within the same assembly (project) unless explicitly marked as public.
    public class GradeBook
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

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        //This can actually be written as public void AddGrade(float grade) => grades.Add(grade);
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //This is now a property as we have the get and set functions. Use properties by default instead of fields.
        public string Name
        {
            get //Allows code outside of this class to obtain the value in the variable.
            {
                return _name;
            }
            set //Allows code outside of this class to apply a value to the variable.
            {
                //if (!String.IsNullOrEmpty(value)) //This will ensure that a NULL value can't be assigned to the _name.
                //{
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null) //Checks that the current name and value are not the same and that there is a subscriber to the NameChanged event.
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args); //this is variable that refers to itself
                }
                _name = value;
                //}
            }
        }

        public event NameChangedDelegate NameChanged;

        private string _name;

        //If you don't specify the access modifier (public, private, etc) then it is a private member (as opposed to public).
        public List<float> grades;
    }
}
