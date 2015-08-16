namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseWithNameNullShouldThrowAnException()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseWithNameEmptyStringShouldThrowAnException()
        {
            var course = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseWithNameContainingOnlyWhiteSpacesShouldThrowAnException()
        {
            var course = new Course("      ");
        }

        [TestMethod]
        public void CourseWithNameContainingOnlyOneLetterAndWhiteSpacesShouldNotThrowAnException()
        {
            var course = new Course("   C   ");
        }

        [TestMethod]
        public void CourseWithNameContainingMultipleWhiteSpacesInTheBeginningAndEndShouldNotThrowException()
        {
            var course = new Course("   CSharp   ");
        }

        [TestMethod]
        public void CourseWithNameContainingMultipleWhiteSpacesInTheBeginningAndEndShouldReturnNameTrimmed()
        {
            var course = new Course("   CSharp   ");
            var expectedValue = "CSharp";

            Assert.AreEqual(expectedValue, course.Name);
        }

        [TestMethod]
        public void CourseWithValidNameShouldNotThrowAnException()
        {
            var course = new Course("CSharp 1");
        }

        [TestMethod]
        public void CourseWithValidNameShouldReturnCorrectName()
        {
            var course = new Course("CSharp 1");
            var expectedValue = "CSharp 1";

            Assert.AreEqual(expectedValue, course.Name);
        }

        [TestMethod]
        public void CourseShouldNotThrowAnExceptionWhenAddingValidStudent()
        {
            var course = new Course("CSharp");
            var student = new Student("Georgi", "Georgiev", 10001);

            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseShouldContainTheStudentWhenHeHasBeenAdded()
        {
            var course = new Course("CSharp");
            var student = new Student("Georgi", "Georgiev", 10001);

            course.AddStudent(student);
            var actualValue = course.Students.First();

            Assert.AreSame(student, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowAnExceptionWhenAddingStudentWithValueNull()
        {
            var course = new Course("CSharp");
            Student student = null;

            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowAnExceptionWhenMoreThan30StudentsAreAdded()
        {
            var course = new Course("CSharp");

            for (int i = 0; i < 40; i++)
            {
                course.AddStudent(new Student("First name " + i, "Last name " + i, 10000 + i));
            }
        }

        [TestMethod]
        public void CourseShouldNotThrowAnExceptionWhenExactly30StudentsAreAdded()
        {
            var course = new Course("CSharp");

            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student("First name " + i, "Last name " + i, 10000 + i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowAnExceptionWhenExistingStudentIsAdded()
        {
            var course = new Course("CSharp");
            Student student = new Student("Georgi", "Georgiev", 12000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseShouldNotThrowAnExceptionWhenRemovingValidStudent()
        {
            var course = new Course("CSharp");
            var student = new Student("Georgi", "Georgiev", 10001);

            course.AddStudent(student);
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowAnExceptionWhenRemovingStudentWithValueNull()
        {
            var course = new Course("CSharp");
            Student student = null;

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowAnExceptionWhenRemovingStudentThatHasntBeenAdded()
        {
            var course = new Course("CSharp");
            Student student = new Student("Georgi", "Georgiev", 10001);

            course.RemoveStudent(student);
        }

        [TestMethod]
        public void CourseShouldContainNoStudentsWhenTheOnlyStudentHasBeenDeleted()
        {
            var course = new Course("CSharp");
            Student student = new Student("Georgi", "Georgiev", 10001);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }
    }
}
