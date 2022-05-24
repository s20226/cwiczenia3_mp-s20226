using Cw3.Models;
using System.Collections.Generic;

namespace Cw3.Services
{
    public interface IFileDbService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string indexNumber);
        bool AddStudent(Student student);
        Student PutStudent(Student student);
        bool RemoveStudent(string indexNumber);
    }
}
