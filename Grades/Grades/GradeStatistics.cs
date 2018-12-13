using System;
using System.Collections.Generic;
using System.Text;

namespace Grades
{
    class GradeStatistics
    {
        //Instantiate the variables in the constructor so that no extra code is necessary in other code.
        public GradeStatistics()
        {
            HighestGrade = float.MinValue;
            LowestGrade = float.MaxValue;
        }

        //Set variables as public to make them available to be called.
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
