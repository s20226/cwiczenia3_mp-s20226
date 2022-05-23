using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Services
{
    public class FileDbService : IFileDbService
    {
        public bool AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(string indexNumber)
        {
            var list = new List<Student>()
            {
                new Student
                {
                    IndexNumber = "s1234",
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Student
                {
                    IndexNumber = "s1235",
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            };
            // return student = list.Find(e => e.IndexNumber == indexNumber);
            return list.Find(e => e.IndexNumber == indexNumber);
        }

        public IEnumerable<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student
                {
                    IndexNumber = "s1234",
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Student
                {
                    IndexNumber = "s1235",
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            };
        }
    }
}
