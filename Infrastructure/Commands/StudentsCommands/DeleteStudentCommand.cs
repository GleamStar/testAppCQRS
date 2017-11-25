using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands.StudentsCommands
{
    public class DeleteStudentCommand: CommandBase<CommandResult>
    {
        private readonly Guid _studentId;

        public DeleteStudentCommand(Guid studentId)
        {
            _studentId = studentId;
        }

        public override async Task<CommandResult> ExecuteAsync(TestContext context)
        {
            var student = await context.Students
                        .FindAsync(_studentId);
            if (student == null)
            {
                throw new ArgumentNullException($"Student {student} is not exist");
            }

            context.Students.Remove(student);

            return GetSuccessResult();
        }
    }
}
