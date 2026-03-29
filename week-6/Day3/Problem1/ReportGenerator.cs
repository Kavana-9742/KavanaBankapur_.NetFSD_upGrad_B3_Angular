using System;
using System.Collections.Generic;
using System.Text;

namespace SRP_Example
{
    internal class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n===== Student Report =====");

            foreach (var student in students)
            {
                string grade;

                if (student.Marks >= 75)
                    grade = "Distinction";
                else if (student.Marks >= 50)
                    grade = "Pass";
                else
                    grade = "Fail";

                Console.WriteLine("Student ID   : " + student.StudentId);
                Console.WriteLine("Student Name : " + student.StudentName);
                Console.WriteLine("Marks        : " + student.Marks);
                Console.WriteLine("Grade        : " + grade);
                Console.WriteLine("----------------------------");
            }
        }
    }
}
