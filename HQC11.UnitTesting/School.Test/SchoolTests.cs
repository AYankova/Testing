namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolWithNameNullShouldThrowAnException()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolWithNameEmptyStringShouldThrowAnException()
        {
            var school = new School("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolWithNameContainingOnlyWhiteSpacesShouldThrowAnException()
        {
            var school = new School("      ");
        }

        [TestMethod]
        public void SchoolWithNameContainingOnlyOneLetterAndWhiteSpacesShouldNotThrowAnException()
        {
            var school = new School("   S   ");
        }

        [TestMethod]
        public void SchoolWithNameContainingMultipleWhiteSpacesInTheBeginningAndEndShouldNotThrowException()
        {
            var school = new School("   School   ");
        }

        [TestMethod]
        public void SchoolWithNameContainingMultipleWhiteSpacesInTheBeginningAndEndShouldReturnNameTrimmed()
        {
            var school = new School("   School   ");
            var expectedValue = "School";

            Assert.AreEqual(expectedValue, school.Name);
        }

        [TestMethod]
        public void SchoolWithValidNameShouldNotThrowAnException()
        {
            var school = new School("School");
        }

        [TestMethod]
        public void SchoolWithValidNameShouldReturnCorrectName()
        {
            var school = new School("School");
            var expectedValue = "School";

            Assert.AreEqual(expectedValue, school.Name);
        }

        [TestMethod]
        public void SchoolShouldNotThrowAnExceptionWhenAddingValidStudent()
        {
            var school = new School("School");
            var student = new Student("Georgi", "Georgiev", 10001);

            school.AddStudent(student);
        }

        [TestMethod]
        public void SchoolShouldContainTheStudentWhenHeHasBeenAdded()
        {
            var school = new School("School");
            var student = new Student("Georgi", "Georgiev", 10001);

            school.AddStudent(student);
            var actualValue = school.Students.First();

            Assert.AreSame(student, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowAnExceptionWhenAddingStudentWithValueNull()
        {
            var school = new School("School");
            Student student = null;

            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowAnExceptionWhenExistingStudentIsAdded()
        {
            var school = new School("School");
            Student student = new Student("Georgi", "Georgiev", 10001);

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowAnExceptionWhenAddingStudentWithDuplicateID()
        {
            var school = new School("School");
            var student = new Student("Georgi", "Georgiev", 10001);
            var studentWithDuplicateID = new Student("Ivan", "Ivanov", 10001);

            school.AddStudent(student);
            school.AddStudent(studentWithDuplicateID);
        }

        [TestMethod]
        public void SchoolShouldNotThrowAnExceptionWhenRemovingValidStudent()
        {
            var school = new School("School");
            var student = new Student("Georgi", "Georgiev", 10001);

            school.AddStudent(student);
            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowAnExceptionWhenRemovingStudentWithValueNull()
        {
            var school = new School("School");
            Student student = null;

            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowAnExceptionWhenRemovingStudentThatHasntBeenAdded()
        {
            var school = new School("School");
            Student student = new Student("Georgi", "Georgiev", 10001);

            school.RemoveStudent(student);
        }

        [TestMethod]
        public void SchoolShouldContainNoStudentsWhenTheOnlyStudentHasBeenDeleted()
        {
            var school = new School("School");
            Student student = new Student("Georgi", "Georgiev", 10001);

            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        public void SchoolShouldNotThrowAnExceptionWhenAddingValidCourse()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolShouldContainTheCourseWhenItHasBeenAdded()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.AddCourse(course);
            var actualValue = school.Courses.First();

            Assert.AreSame(course, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowAnExceptionWhenAddingCoursetWithValueNull()
        {
            var school = new School("School");
            Course course = null;

            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowAnExceptionWhenExistingCoursetIsAdded()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolShouldNotThrowAnExceptionWhenRemovingValidCourse()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.AddCourse(course);
            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowAnExceptionWhenRemovingCourseWithValueNull()
        {
            var school = new School("School");
            Course course = null;

            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowAnExceptionWhenRemovingCourseThatHasntBeenAdded()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.RemoveCourse(course);
        }

        [TestMethod]
        public void SchoolShouldContainNoCoursesWhenTheOnlyCourseHasBeenDeleted()
        {
            var school = new School("School");
            var course = new Course("CSharp");

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(0, school.Courses.Count);
        }
    }
}
