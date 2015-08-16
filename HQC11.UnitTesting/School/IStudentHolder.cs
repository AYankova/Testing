namespace School
{
    using System.Collections.Generic;

    internal interface IStudentHolder
    {
        ICollection<Student> Students { get; }

        string Name { get; set; }
    }
}
