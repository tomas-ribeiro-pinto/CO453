using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;

namespace Test
{
    [TestClass]
    public class TestGrades
    {

        //[TestMethod]
        //public void TestConvertHighestFail()
        //{
        // Arrange

        //    StudentGrades App03 = new StudentGrades();

        // Act

        //    Grades actualGrade = App03.ConvertToGrades(39);

        // Assert

        //    Assert.AreEqual(actualGrade, Grades.F);
        //}

        [TestMethod]
        public void TestMilesToFeet()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Miles";
            App01.convertTo = "Feet";
            App01.FromDistance = 2;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 10560);
        }

        [TestMethod]
        public void TestFeetToMiles()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Feet";
            App01.convertTo = "Miles";
            App01.FromDistance = 10560;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 2);
        }

        [TestMethod]
        public void TestMilesToMetres()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Miles";
            App01.convertTo = "Metres";
            App01.FromDistance = 2;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 3218.69);
        }

        [TestMethod]
        public void TestMetresToMiles()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Metres";
            App01.convertTo = "Miles";
            App01.FromDistance = 3218.69;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 2);
        }

        [TestMethod]
        public void TestMetresToFeet()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Metres";
            App01.convertTo = "Feet";
            App01.FromDistance = 2;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 6.56168);
        }

        [TestMethod]
        public void TestFeetToMetres()
        {
            DistanceConverter App01 = new DistanceConverter();
            App01.convertFrom = "Feet";
            App01.convertTo = "Metres";
            App01.FromDistance = 6.56168;
            App01.ConvertWebDistance();
            Assert.AreEqual(App01.ToDistance, 2);
        }
    }
}
