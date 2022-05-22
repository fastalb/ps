using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.TestData
{
    static public class StudentData
    {
        static public List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return _testStudents;
            }
            set { }
        }

        static private List<Student> _testStudents;

        static private void ResetTestStudentData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Nikita",
                        SecondName = "Stepanovich",
                        LastName = "Peichev",
                        Faculty = "FCST",
                        Major = "CSE",
                        OKS = "Бакалавър",
                        Status = "Редовен",
                        FacNum = "123219013",
                        Course = 3,
                        Stream = 9,
                        Group = 32,
                    },
                    new Student
                    {
                        FirstName = "Ivan",
                        SecondName = "Ivanov",
                        LastName = "Ivanov",
                        Faculty = "FCST",
                        Major = "CSE",
                        OKS = "Магистър",
                        Status = "Задочен",
                        FacNum = "123219014",
                        Course = 1,
                        Stream = 9,
                        Group = 32,
                    },
                    new Student
                    {
                        FirstName = "Boris",
                        SecondName = "Borisov",
                        LastName = "Borisov",
                        Faculty = "FCST",
                        Major = "CSE",
                        OKS = "Бакалавър",
                        Status = "Редовен",
                        FacNum = "123219015",
                        Course = 3,
                        Stream = 9,
                        Group = 32,
                    },
                };
            }
        }
    }
}
