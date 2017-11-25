using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dto;
using Infrastructure;
using Infrastructure.Contracts;
using Microsoft.AspNetCore.SignalR;
using TestApp.Application.SignalR;
using Infrastructure.Commands.StudentsCommands;
using Infrastructure.Queries;

namespace TestApp.Application
{
    public class StudentsService : IStudentsService
    {
        private readonly IExecutor _executor;
        private readonly ITestContext _context;
        private readonly IHubContext<StudentsHub> _hubContext;
        public StudentsService(IExecutor executor, ITestContext context, IHubContext<StudentsHub> hubContext)
        {
            _executor = executor;
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(Guid classId)
        {
            return await _executor.QueryAsync(new GetStudentsByClassId(classId));
        }
        public async Task<Guid> AddStudentAsync(Guid classId, UpsertStudentDto studentDto)
        {
            var student = await _executor.ExecuteAsync(new AddStudentCommand(classId, studentDto));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Creating an student failed on save.");
            }
            if (student.StudentId != null)
                await _hubContext.Clients.All.InvokeAsync("refresh");
            return student.StudentId;
        }
        public async Task UpdateStudentAsync(Guid studentId, Guid classId, UpsertStudentDto studentDto)
        {
            var result = await _executor.ExecuteAsync(new UpdateStudentCommand(classId,studentId,studentDto));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Updating an student failed on save.");
            }
            if (result.Success)
                await _hubContext.Clients.All.InvokeAsync("refresh");
        }
        public async Task DeleteStudentAsync(Guid studentId)
        {
            var result = await _executor.ExecuteAsync(new DeleteStudentCommand(studentId));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Deting an student failed on save.");
            }
            if (result.Success)
                await _hubContext.Clients.All.InvokeAsync("refresh");
        }
    }
}
