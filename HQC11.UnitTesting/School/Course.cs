namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course : IStudentHolder
    {
        private const int MaxStudentsCount = 30;
        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
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
                Validator.ValidateName(value, "course name");
                this.name = value.Trim();
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
            Validator.ValidateStudentsCount(this, MaxStudentsCount);
            Validator.ValidateUniqueStudentIsAdded(this, student);

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateIfNotNull(student, "student");
            Validator.ValidateIfStudentsExists(this, student);

            this.students.Remove(student);
        }
    }
}
