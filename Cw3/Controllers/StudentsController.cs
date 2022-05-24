using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    // [Route("[controller]")]
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IFileDbService _fileDbService;
        public StudentsController(IFileDbService fileDbService)
        {
            _fileDbService = fileDbService;

        }


        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _fileDbService.GetStudents();
            return Ok(students);
        }

        //[HttpGet]
        [HttpGet("{indexNumber}")]
        //[Route("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            var student = _fileDbService.GetStudent(indexNumber);
            if (student is null) {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            if (!_fileDbService.AddStudent(newStudent)) {
                return BadRequest($"Student cant be added, {newStudent.IndexNumber} is taken");
            }


            return Created("Student added", newStudent);
        }
        [HttpDelete("{indexNumber}")]
        public IActionResult RemoveStudent(string indexNumber)
        {
            if (!_fileDbService.RemoveStudent(indexNumber)) {
                return BadRequest($"Can't assign {indexNumber} to any student. Delete action failed");
            }

            return Ok($"Usuwanie zakonczone {indexNumber}");
        }

        [HttpPut("{indexNumber}")]
        public IActionResult PutStudent(Student student)
        {
            var updatedStudent = _fileDbService.PutStudent(student);
            if (updatedStudent is null) {
                return NotFound("Student not found");
            }

            return Created($"Student with {student.IndexNumber} updated", updatedStudent);
        }

    }
}
