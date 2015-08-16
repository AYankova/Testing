namespace School
{
    using System;
    using System.Collections;
    using System.Linq;

    internal static class Validator
    {
        internal static void ValidateName(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(propertyName, "can't be null or empty");
            }
        }

        internal static void ValidateID(int value, int minValue, int maxValue, string propertyName)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentOutOfRangeException(propertyName, string.Format("should be in the range [{0}, {1}]", minValue, maxValue));
            }
        }

        internal static void ValidateIfNotNull<T>(T param, string propertyName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(propertyName, "can't be null");
            }
        }

        internal static void ValidateStudentsCount(Course course, int maxValue)
        {
            if (course.Students.Count + 1 > maxValue)
            {
                throw new InvalidOperationException("No more students can be added to the course!");
            }
        }

        internal static void ValidateUniqueStudentIsAdded<T>(T param, Student student) where T : IStudentHolder
        {
            if (param.Students.Contains(student))
            {
                throw new InvalidOperationException(string.Format("{0} has already joined {1}", student.FullName, param.Name));
            }
        }

        internal static void ValidateIfStudentsExists<T>(T param, Student student) where T : IStudentHolder
        {
            if (!param.Students.Contains(student))
            {
                throw new InvalidOperationException(string.Format("{0} hasn't joined {1} and can't be removed from it", student.FullName, param.Name));
            }
        }

        internal static void ValidateStudentWithUniqueID(School school, Student student)
        {
            if (school.Students.Any(s => s.ID == student.ID))
            {
                throw new InvalidOperationException(string.Format("{0} has already exists in  {1}", student.FullName, school.Name));
            }
        }

        internal static void ValidateUniqueCourseIsAdded(School school, Course course)
        {
            if (school.Courses.Contains(course))
            {
                throw new InvalidOperationException(string.Format("{0} has already been added to {1}", course.Name, school.Name));
            }
        }

        internal static void ValidateIfCourseExists(School school, Course course)
        {
            if (!school.Courses.Contains(course))
            {
                throw new InvalidOperationException(string.Format("{0} hasn't been added to {1} and can't be removed from it", course.Name, school.Name));
            }
        }
    }
}
