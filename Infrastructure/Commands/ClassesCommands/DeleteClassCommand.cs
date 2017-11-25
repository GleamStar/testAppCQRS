using Services.Dto;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands.ClassesCommands
{
    public class DeleteClassCommand : CommandBase<CommandResult>
    {
        private readonly Guid _classId;

        public DeleteClassCommand(Guid classId)
        {
            _classId = classId;
        }

        public override async Task<CommandResult> ExecuteAsync(TestContext context)
        {
            var @class = await context.Classes.Include(c => c.Students)
                        .FirstOrDefaultAsync(c => c.ClassId == _classId);
            if (@class == null)
            {
                throw new ArgumentNullException($"Class {@class} is not exist");
            }

            context.Students.RemoveRange(@class.Students);
            context.Remove(@class);

            return GetSuccessResult();
        }
    }
}
