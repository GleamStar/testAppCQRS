using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Dto;
using System;
using System.Threading.Tasks;

namespace TestApp.Controllers
{
    [Produces("application/json")]
    [Route("api/classes")]
    public class ClassesContoller : Controller
    {
        private readonly IClassesService _classesService;

        public ClassesContoller(IClassesService classesService)
        {
            _classesService = classesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var result = await _classesService.GetClassesAsync();
            return Ok(result);
        }
        [HttpGet("fullinfo")]
        public async Task<IActionResult> GetClassesFullInfo()
        {
            var result = await _classesService.GetFullInfo();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] UpsertClassDto classDto)
        {
            if (classDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

            var id = await _classesService.AddClassAsync(classDto);

            return Ok(id);
        }
        [HttpDelete("{classId}")]
        public async Task<IActionResult> DeleteClass(Guid classId)
        {
            await _classesService.DeleteClassAsync(classId);
            return NoContent();
        }

        [HttpPut("{classId}")]
        public async Task<IActionResult> UpdateBookForAuthor(Guid classId, [FromBody] UpsertClassDto classDto)
        {
            if (classDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

            await _classesService.UpdateClassAsync(classId, classDto);

            return NoContent();
        }
    }
}
