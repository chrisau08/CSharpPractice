using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades_NetFrame;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades; //Creates an array of floating point numbers (Declaring a variable).
            grades = new float[3]; //Sets the array to a length of 3 values (Initializing a variable).

            AddGrades(grades); //Passes the value of grades which is the memory location for the array.

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "chris";
            name = name.ToUpper(); //You must assign the value of name.ToUpper back to the name in order to actually change the string variable.

            Assert.AreEqual("CHRIS", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2018, 12, 19); //year, month, day
            date = date.AddDays(1); //You must assign the value of date.AddDays back to date in order to actually increment the date in the variable.

            Assert.AreEqual(20, date.Day);
        }
        [TestMethod]
        //Pass by Value is the default method when passing in a parameter where the value of the variable is passed, not the variable itself.
        public void ValueTypesPassByValue()
        {
            int x = 46;

            IncrementNumber(x);
            Assert.AreEqual(46, x); //Since the variable x itself is not passed, merely the value 46, x is unchanged by IncrementNumber(). (See "Pass by Value")
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        //Pass by Value is the default method when passing in a parameter where the value of the variable is passed, not the variable itself.
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2); //The pointer value (memory location) is sent/copied to the function.
            Assert.AreEqual("A Gradebook", book1.Name); //Since the Name at the memory location was changed to the string these are equal.
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A Gradebook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Chris";
            string name2 = "chris";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase); //Compares strings regardless of casing or language settings.
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Chris' Gradebook";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
