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
    }
}
