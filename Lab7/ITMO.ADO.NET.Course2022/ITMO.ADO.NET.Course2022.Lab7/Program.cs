using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.ADO.NET.Course2022.Lab7
{
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        static List<Student> students = new List<Student>
        {
             new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int> {97, 92, 81, 79}},
             new Student {First="Claire", Last="O’Donnell", ID=112, Scores = new List<int> {75, 84, 91, 39}},
             new Student {First="Aleksei", Last="Muraviev", ID=113, Scores = new List<int> {92, 2, 2, 2}},
             new Student {First="Serg", Last="Shoigu", ID=114, Scores = new List<int> {1, 1, 1, 1}},
             new Student {First="Vladimir", Last="Surkov", ID=113, Scores = new List<int> {98, 0, 0, 0}},
             new Student {First="Sergo", Last="Popov", ID=114, Scores = new List<int> {100, 1, 81, 12}},
             new Student {First="Savelii", Last="Reversov", ID=114, Scores = new List<int> {91, 15, 10, 71}},
             new Student {First="Victor", Last="Gubin", ID=114, Scores = new List<int> {94, 1112, 31, 1}},
             new Student {First="Oleg", Last="Petrov", ID=114, Scores = new List<int> {71, 18, 1, 91}},
        };

        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery = from student in students
                                                where student.Scores[0] > 90 && student.Scores[3] < 80
                                                orderby student.Scores[0] descending
                                                select student;
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }

            var studentQuery2 = from student in students
                                group student by student.Last[0];
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);

                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }

            var studentQuery3 = from student in students
                                group student by student.Last[0];
            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }

            var studentQuery4 = from student in students
                                group student by student.Last[0] into studentGroup
                                orderby studentGroup.Key
                                select studentGroup;
            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);

                }
            }

            var studentQuery5 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            var studentQuery6 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                                select totalScore;
            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            IEnumerable<string> studentQuery7 = from student in students
                                                where student.Last == "Garcia"
                                                select student.First;
            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            var studentQuery8 = from student in students
                                let x = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                                where x > averageScore
                                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }


        }
    }
}



