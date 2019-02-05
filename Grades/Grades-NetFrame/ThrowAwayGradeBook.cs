using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_NetFrame
{
    //Class has inherited from GradeBook class.
    public class ThrowAwayGradeBook : GradeBook
    {
        //If actually working with a ThrowAwayGradeBook then the method will be called instead of the virtual in GradeBook.
        public override GradeStatistics ComputeStatistics()
        {
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);

            return base.ComputeStatistics(); //Base will use the function from the base class.
        }
    }
}
