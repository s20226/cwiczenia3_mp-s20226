using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Controllers
{
    [Route("[controller]")]
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
            if (student is null) return NotFound("Nie znaleziono studenta");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            //logika dodawania studenta
            return Created("", student);
        }
    }
}
