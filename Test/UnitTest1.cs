using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App03;

namespace Test
{
    [TestClass]
    public class TestGrades
    {

        [TestMethod]
        public void TestConvertHighestFail()
        {
        // Arrange

            StudentGrades App03 = new StudentGrades();

        // Act

            Grades actualGrade = App03.ConvertToGrades(39);

        // Assert

            Assert.AreEqual(actualGrade, Grades.F);
        }

        [TestMethod]
        public void TestConvertLowestPass()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(40);

            // Assert

            Assert.AreEqual(actualGrade, Grades.D);
        }

        [TestMethod]
        public void TestConvertHighestPass()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(49);

            // Assert

            Assert.AreEqual(actualGrade, Grades.D);
        }

        [TestMethod]
        public void TestConvertLowestLowerSecond()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(50);

            // Assert

            Assert.AreEqual(actualGrade, Grades.C);
        }


        [TestMethod]
        public void TestConvertHighestLowerSecond()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(59);

            // Assert

            Assert.AreEqual(actualGrade, Grades.C);
        }


        [TestMethod]
        public void TestConvertHighestUpperSecond()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(60);

            // Assert

            Assert.AreEqual(actualGrade, Grades.B);
        }

        [TestMethod]
        public void TestConvertLowestUpperSecond()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(69);

            // Assert

            Assert.AreEqual(actualGrade, Grades.B);
        }

        [TestMethod]
        public void TestConvertFirst()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(70);

            // Assert

            Assert.AreEqual(actualGrade, Grades.A);
        }

        [TestMethod]
        public void TestConvertErrorGrade()
        {
            // Arrange

            StudentGrades App03 = new StudentGrades();

            // Act

            Grades actualGrade = App03.ConvertToGrades(200);

            // Assert

            Assert.AreEqual(actualGrade, Grades.X);
        }
    }
}
