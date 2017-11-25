using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class GetStudentsByClassId : IQueryCollection<StudentDto>
    {
        private readonly Guid _classId;

        public GetStudentsByClassId(Guid classId)
        {
            _classId = classId;
        }
        public async Task<IEnumerable<StudentDto>> ExecuteAsync(TestContext context)
        {
            var @class = await context.Classes
            .FindAsync(_classId);
            if (@class == null)
            {
                throw new ArgumentNullException($"Class {@class} is not exist");
            }
            return await context.Students
                .Where(s => s.ClassId == _classId)
                .Select(s => new StudentDto
                {
                    Dob = s.Dob,
                    Name = s.Name,
                    Gpa = s.Gpa,
                    StudentId = s.StudentId,
                    Surname = s.Surname
                }).ToListAsync();
        }

    }
}
