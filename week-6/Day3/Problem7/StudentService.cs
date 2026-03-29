using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class StudentService
    {
        private IStudentRepository repository;

        public StudentService(IStudentRepository repo)
        {
            repository = repo;
        }

        public void AddStudent(Student student)
        {
            repository.AddStudent(student);
        }

        public void DisplayStudents()
        {
            var students = repository.GetAllStudents();

            foreach (var s in students)
            {
                Console.WriteLine(s.StudentId + " " + s.StudentName + " " + s.Course);
            }
        }

        public void FindStudent(int id)
        {
            var student = repository.GetStudentById(id);

            if (student != null)
                Console.WriteLine(student.StudentId + " " + student.StudentName + " " + student.Course);
            else
                Console.WriteLine("Student not found");
        }

        public void DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
        }
    }
}
