using Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(Guid classId);
        Task<Guid> AddStudentAsync(Guid classId, UpsertStudentDto studentDto);
        Task UpdateStudentAsync(Guid studentId, Guid classId, UpsertStudentDto studentDto);
        Task DeleteStudentAsync(Guid studentId);
    }
}
