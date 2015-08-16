namespace School.Test
{
    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithFirstNameNullShouldThrowAnException()
        {
            var student = new Student(null, "Georgiev", 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithLastNameNullShouldThrowAnException()
        {
            var student = new Student("Georgi", null, 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithEmptyFirstNameShouldThrowAnException()
        {
            var student = new Student("", "Georgiev", 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithEmptyLastNameShouldThrowAnException()
        {
            var student = new Student("Georgi", "", 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithFirstNameContainingOnlyWhiteSpacesShouldThrowAnException()
        {
            var student = new Student("      ", "Georgiev", 20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithLastNameContainingOnlyWhiteSpacesShouldThrowAnException()
        {
            var student = new Student("Georgi", "       ", 20000);
        }

        [TestMethod]
        public void StudentWithFirstNameContainingOnlyOneLetterAndSpacesShouldNotThrowAnException()
        {
            var student = new Student("   G   ", "Georgiev", 20000);
        }

        [TestMethod]
        public void StudentWithLastNameContainingOnlyOneLetterAndSpacesShouldNotThrowAnException()
        {
            var student = new Student("Georgi", "   G   ", 20000);
        }

        [TestMethod]
        public void StudentWithFirstNameContaingMultipleWhiteSpacesInTheBeginingAndEndShouldReturnFirstNameTrimmed()
        {
            var student = new Student("    Georgi      ", "Georgiev", 20000);
            var expectedValue = "Georgi";

            Assert.AreEqual(expectedValue, student.FirstName);
        }

        [TestMethod]
        public void StudentWithLastNameContaingMultipleWhiteSpacesInTheBeginingAndEndShouldReturnLastNameTrimmed()
        {
            var student = new Student("Georgi", "     Georgiev    ", 20000);
            var expectedValue = "Georgiev";

            Assert.AreEqual(expectedValue, student.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentWithIDSmallerThanTheMinValueShouldThrowAnException()
        {
            var student = new Student("Georgi", "Georgiev", 5000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentWithIDBiggerThanTheMaxValueShouldThrowAnException()
        {
            var student = new Student("Georgi", "Georgiev", 5000000);
        }

        [TestMethod]
        public void StudentWithIDEqualToMinValueShouldNotThrowAnException()
        {
            var student = new Student("Georgi", "Georgiev", 10000);
        }

        [TestMethod]
        public void StudentWithIDEqualToMaxValueShouldNotThrowAnException()
        {
            var student = new Student("Georgi", "Georgiev", 99999);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldNotThrowAnException()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldReturnCorrectFirstName()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            var expectedResult = "Georgi";

            Assert.AreEqual(expectedResult, student.FirstName);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldReturnCorrectLastName()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            var expectedResult = "Georgiev";

            Assert.AreEqual(expectedResult, student.LastName);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldReturnCorrectID()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            var expectedResult = 20000;

            Assert.AreEqual(expectedResult, student.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithValidNamesAndIDShouldThrowAnExceptionWhenJoiningCourseThatIsNull()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            Course course = null;

            student.JoinCourse(course);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldNotThrowAnExceptionWhenJoiningValidCourse()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            var course = new Course("CSharp");

            student.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithValidNamesAndIDShouldThrowAnExceptionWhenLeavingCourseThatIsNull()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            Course course = null;

            student.LeaveCourse(course);
        }

        [TestMethod]
        public void StudentWithValidNamesAndIDShouldNotThrowAnExceptionWhenLeavingValidCourse()
        {
            var student = new Student("Georgi", "Georgiev", 20000);
            var course = new Course("CSharp");

            student.JoinCourse(course);
            student.LeaveCourse(course);
        }
    }
}
