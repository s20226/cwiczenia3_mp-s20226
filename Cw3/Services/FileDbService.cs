using CsvHelper;
using CsvHelper.Configuration;
using Cw3.Comparers;
using Cw3.Models;
using Cw3.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Cw3.Services
{
    public class FileDbService : IFileDbService
    {
        private readonly string fileDBCSV = "students.csv";
        private HashSet<Student> studentsHashSet = new HashSet<Student>(new StudentComparer());
        private static readonly DataValidator _dataValidator = new DataValidator();

        public void ReadFile()
        {
            StreamReader reader = null;
            try {
                reader = new StreamReader(fileDBCSV);
                string line;
                while ((line = reader.ReadLine()) != null) {

                    var splited = new List<string>(line.Split(','));

                    if (!_dataValidator.HasValidDataStudentsRow(splited)) {

                        Program.Logg(line);
                        continue;
                    }

                    var student = new Student {

                        FirstName = splited[0],
                        LastName = splited[1],
                        IndexNumber = splited[2],
                        BirthDate = DateTime.ParseExact(splited[3], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Studies = new Studies(splited[4], splited[5]),
                        Email = splited[6],
                        MothersName = splited[7],
                        FathersName = splited[8]
                    };

                    studentsHashSet.Add(student);

                }


            }
            catch (FileNotFoundException e) {
                var msg = $"File {fileDBCSV} not found.";
                Program.Logg(msg);
                throw new FileNotFoundException(msg, e);
            }
            catch (IOException e) {
                var msg = $"File {fileDBCSV} can't be load.";
                Program.Logg(msg);
                throw new FileLoadException(msg, e);
            }
            finally {
                if (reader != null) { reader.Dispose(); }
            }

        }


        public void SaveFile()
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false
            };
            using (var writer = new StreamWriter(fileDBCSV))
            using (var csv = new CsvWriter(writer, configPersons)) {
                csv.WriteRecords(studentsHashSet);
            }
        }

        public void AppendToFile(List<Student> studentList)
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false
            };
            using (var stream = File.Open(fileDBCSV, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, configPersons)) {
                csv.WriteRecords(studentList);
            }

        }

        public bool RemoveStudent(string indexNumber)
        {
            ReadFile();
            var studentToDelete = studentsHashSet.Where(e => e.IndexNumber == indexNumber).FirstOrDefault();
            if (studentToDelete == null) { return false; };
            studentsHashSet.Remove(studentToDelete);
            SaveFile();
            return true;
        }

        public bool AddStudent(Student student)
        {
            ReadFile();
            if (studentsHashSet.Contains(student)) { return false; };

            AppendToFile(new List<Student> { student });
            return true;

        }

        public Student GetStudent(string indexNumber)
        {
            ReadFile();
            return studentsHashSet.Where(e => e.IndexNumber == indexNumber).FirstOrDefault(); ;
        }

        public Student PutStudent(Student student)
        {
            ReadFile();

            if (studentsHashSet.Contains(student)) {
                studentsHashSet.Remove(student);
                studentsHashSet.Add(student);
                SaveFile();
            }
            else {
                return null;
            }

            return student;

        }

        public IEnumerable<Student> GetStudents()
        {
            ReadFile();
            return studentsHashSet;
        }
    }
}
