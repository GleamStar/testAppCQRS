using Domain.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands.StudentsCommands
{
    public class UpdateStudentCommand: CommandBase<CommandResult>
    {
        private readonly Guid _classId;
        private readonly Guid _studentId;
        private readonly UpsertStudentDto _dto;

        public UpdateStudentCommand(Guid classId, Guid studentId, UpsertStudentDto dto)
        {
            _classId = classId;
            _studentId = studentId;
            _dto = dto;
        }

        public override async Task<CommandResult> ExecuteAsync(TestContext context)
        {
            var @class = await context.Classes
                        .FindAsync(_classId);
            if (@class == null)
            {
                throw new ArgumentNullException($"Class {@class} is not exist");
            }

            var student = await context.Students
                        .FindAsync(_studentId);
            if (student == null)
            {
                throw new ArgumentNullException($"Student {student} is not exist");
            }

            student.Gpa = _dto.Gpa;
            student.Name = _dto.Name;
            student.Surname = _dto.Surname;
            student.Dob = _dto.Dob;

            return GetSuccessResult();
        }
    }
}
