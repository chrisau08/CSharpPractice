using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_NetFrame
{
    //The reason for creating the abstract class is so that we can work with the type GradeTracker without needing to worry about the specific type of GradeTracker.
    public abstract class GradeTracker : IGradeTracker
    {
        //Since we don't know how the AddGrade will need to be defined but we know that we will need to add grades
        //we can specify the method as abstract which allows it to be defined by an inheriting class.
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

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

        protected string _name;
    }
}
