using System.Collections;
using System.IO;

namespace Grades_NetFrame
{
    internal interface IGradeTracker : IEnumerable
    {
        //Since we don't know how the AddGrade will need to be defined but we know that we will need to add grades
        //we can specify the method as abstract which allows it to be defined by an inheriting class.
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
    }
}