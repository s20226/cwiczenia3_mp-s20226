using Cw3.Models;
using System.Collections.Generic;

namespace Cw3.Comparers
{
    internal class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return
                //(x.FirstName == y.FirstName)
                //&& (x.LastName == y.LastName)
                //&& 
                (x.IndexNumber == y.IndexNumber);
        }
        public int GetHashCode(Student obj)
        {
            return obj.IndexNumber.GetHashCode();
        }
    }
}
