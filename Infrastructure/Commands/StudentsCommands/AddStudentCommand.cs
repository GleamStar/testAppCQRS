using Domain.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands.StudentsCommands
{
    public class AddStudentCommand: CommandBase<Students>
    {
        private readonly Guid _classId;
        private readonly UpsertStudentDto _dto;

        public AddStudentCommand(Guid classId, UpsertStudentDto dto)
        {
            _classId = classId;
            _dto = dto;
        }

        public override async Task<Students> ExecuteAsync(TestContext context)
        {
            var @class = await context.Classes
                        .FindAsync(_classId);
            if (@class == null)
            {
                throw new ArgumentNullException($"Class {@class} is not exist");
            }

            var student = new Students()
            {
                Name = _dto.Name,
                Dob = _dto.Dob,
                Surname = _dto.Surname,
                Gpa = _dto.Gpa,
                Class = @class
            };

            await context.AddAsync(student);
            return student;
        }
    }
}
