using System;
using System.Collections.Generic;
using System.IO;
namespace StudentAttendance
{
    public static class Program    {
         
        //program so that the values for the student class are populated from the included studentdata.txt file. 
        //The student’s name is the first thing on each line, followed by some exam scores. 
        //The number of scores might be different for each student.  
        //The program should print out the names of students that have more than six quiz scores.

        public static void Main()
        {
            string[] lines = File.ReadAllLines(@"studentdata.txt");
            List<Student> students = CreateStudent(lines);
            foreach (var student in students)
            {
                if (student.HasSixOrMore())                
                    Console.WriteLine($"{student.Name}");
            }

                //foreach (var student in students)
                //{
                //    Console.WriteLine($"{student.Name}");
                //}


                Console.ReadLine();
            
        }

        private static List<Student> CreateStudent(string[] lines)
        {
            List<string> students = new List<string>();
            List<Student> newStudents = new List<Student>();
            string name = "";
            int[] scores = Array.Empty<int>();

            foreach (string line in lines)
            {
                students.Add(line);
            }

            foreach (string stud in students)
            {
                Student student = new Student(name, scores);
                string[] data = stud.Split(" ");
                name = data[0];
                scores = new int[data.Length - 1];

                for (int i = 0; i < data.Length; i++)
                {
                    if (i != 0)
                        scores[i-1] = Convert.ToInt32(data[i]);                     
                }

                student.Name = name;
                student.Scores = scores;
                newStudents.Add(student);
            }

            return newStudents;

        }
    }
   
}