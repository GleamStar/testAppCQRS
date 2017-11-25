using Domain.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IClassesService
    {
        Task<IEnumerable<ClassDto>> GetClassesAsync();
        Task<IEnumerable<Classes>> GetFullInfo();
        Task<Guid> AddClassAsync(UpsertClassDto classDto);
        Task UpdateClassAsync(Guid classId, UpsertClassDto classDto);
        Task DeleteClassAsync(Guid classId);

    }
}
