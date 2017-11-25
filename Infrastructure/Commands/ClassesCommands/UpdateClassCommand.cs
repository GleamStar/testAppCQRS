using Domain.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands.ClassesCommands
{
    public class UpdateClassCommand: CommandBase<CommandResult>
    {
        private readonly Guid _classId;
        private readonly UpsertClassDto _dto;

        public UpdateClassCommand(Guid classId, UpsertClassDto dto)
        {
            _classId = classId;
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

            @class.Location = _dto.Location;
            @class.Teacher = _dto.Teacher;
            @class.Name = _dto.Name;

            return GetSuccessResult();
        }
    }
}
