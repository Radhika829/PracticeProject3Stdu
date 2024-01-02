using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PracticeProject3
{
    internal class Student
    {
        public String Name { get; set; }
        public String Class { get; set; }
        static void Main(string[] args)
        {
            List<Student> students = ReadDataFromFile("C:\\Users\\HP\\Desktop\\StudentsInfo.txt");

            students = students.OrderBy(s => s.Name).ToList();

            DisplayStudents(students);

            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(students, searchName);
        }

        static List<Student> ReadDataFromFile(string filePath)
        {
            List<Student> students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    students.Add(new Student { Name = data[0].Trim(), Class = data[1].Trim() });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return students;
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("Sorted Student Data:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (foundStudent != null)
            {
                Console.WriteLine($"Found student: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine($"Student '{searchName}' not found.");
            }
        }
    }
}

