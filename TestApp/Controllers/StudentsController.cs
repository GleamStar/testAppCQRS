using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Dto;
using System;
using System.Threading.Tasks;

namespace TestApp.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class StudentsController: Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("classes/{classId}/students")]
        public async Task<IActionResult> GetStudents(Guid classId)
        {
            var result = await _studentsService.GetStudentsByClassIdAsync(classId);
            return Ok(result);
        }

        [HttpPost("classes/{classId}/students")]
        public async Task<IActionResult> CreateStudent(Guid classId,[FromBody] UpsertStudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

            var id = await _studentsService.AddStudentAsync(classId, studentDto);

            return Ok(id);
        }
        [HttpDelete("students/{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            await _studentsService.DeleteStudentAsync(studentId);
            return NoContent();
        }
        [HttpPut("classes/{classId}/students/{studentId}")]
        public async Task<IActionResult> UpdateStudent(Guid classId,Guid studentId, [FromBody] UpsertStudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

            await _studentsService.UpdateStudentAsync(studentId, classId, studentDto);

            return NoContent();
        }
    }
}
