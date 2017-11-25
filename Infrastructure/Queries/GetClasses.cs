using Services.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Queries
{
    public class GetClasses: IQueryCollection<ClassDto>
    {

        public async Task<IEnumerable<ClassDto>> ExecuteAsync(TestContext context)
        {
            return await context.Classes.Select(c => new ClassDto
            {
                ClassId = c.ClassId,
                Location = c.Location,
                Name = c.Name,
                Teacher = c.Teacher
            }).ToListAsync();
        }
    }
}
