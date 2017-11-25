using Domain.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands.ClassesCommands
{
    public class AddClassCommand : CommandBase<Classes>
    {
        private readonly UpsertClassDto _dto;

        public AddClassCommand(UpsertClassDto dto)
        {
            _dto = dto;
        }

        public override async Task<Classes> ExecuteAsync(TestContext context)
        {
            var @class = new Classes()
            {
                Location = _dto.Location,
                Teacher = _dto.Teacher,
                Name = _dto.Name
            };

            await context.AddAsync(@class);
            return @class;
        }
    }
}
