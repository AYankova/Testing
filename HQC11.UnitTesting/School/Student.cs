namespace School
{
    using System;

    public class Student
    {
        private const int MinIDNumber = 10000;
        private const int MaxIDNumber = 99999;
        private string firstName;
        private string lastName;
        private int id;

        public Student(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.ValidateName(value, "firstName");
                this.firstName = value.Trim();
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.ValidateName(value, "lastName");
                this.lastName = value.Trim();
            }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                Validator.ValidateID(value, MinIDNumber, MaxIDNumber, "id");
                this.id = value;
            }
        }

        public void JoinCourse(Course course)
        {
            Validator.ValidateIfNotNull(course, "course");

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            Validator.ValidateIfNotNull(course, "course");

            course.RemoveStudent(this);
        }
    }
}
