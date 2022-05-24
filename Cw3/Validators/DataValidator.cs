using System;
using System.Collections.Generic;

namespace Cw3.Validators
{
    public class DataValidator
    {
        private const int _numbersOfColumn = 9;

        public bool HasValidDataStudentsRow(List<string> studentData)
        {

            return studentData.Count == 9 && !(studentData.Contains("") || studentData.Contains(null));
        }
    }
}
