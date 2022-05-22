using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Faculty { get; set; }

        public string Major { get; set; }

        public string OKS { get; set; }

        public string Status { get; set; }

        public string FacNum { get; set; }

        public int Course { get; set; }

        public int Stream { get; set; }

        public int Group { get; set; }

        public byte[] Photo { get; set; }

        public Student()
        {
            FirstName = "Ivan";
            SecondName = "Ivanov";
            LastName = "Ivanov";
            Faculty = "FCST";
            Major = "CSE";
            OKS = "Бакалавър";
            Status = "Редовен";
            FacNum = "123219016";
            Course = 3;
            Stream = 9;
            Group = 31;
        }

        public Student(string firstName, string secondName, string lastName, string faculty, string major, string oks, string status, string facNum, int course, int stream, int group)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Faculty = faculty ?? throw new ArgumentNullException(nameof(faculty));
            Major = major ?? throw new ArgumentNullException(nameof(major));
            OKS = oks ?? throw new ArgumentNullException(nameof(oks));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            FacNum = facNum ?? throw new ArgumentNullException(nameof(facNum));
            Course = course;
            Stream = stream;
            Group = group;
        }
    }
}
