using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }
}
