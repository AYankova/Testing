namespace School
{
    using System;
    using System.Collections.Generic;

    public class School : IStudentHolder
    {
        private string name;
        private ICollection<Course> courses;
        private ICollection<Student> students;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateName(value, "school name");
                this.name = value.Trim();
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            Validator.ValidateIfNotNull(student, "student");
            Validator.ValidateUniqueStudentIsAdded(this, student);
            Validator.ValidateStudentWithUniqueID(this, student);

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateIfNotNull(student, "student");
            Validator.ValidateIfStudentsExists(this, student);

            this.students.Remove(student);
        }

        public void AddCourse(Course course)
        {
            Validator.ValidateIfNotNull(course, "course");
            Validator.ValidateUniqueCourseIsAdded(this, course);

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            Validator.ValidateIfNotNull(course, "course");
            Validator.ValidateIfCourseExists(this, course);

            this.courses.Remove(course);
        }
    }
}
