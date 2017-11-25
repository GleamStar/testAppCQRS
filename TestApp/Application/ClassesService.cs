using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Dto;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.Contracts;
using Infrastructure;
using TestApp.Application.SignalR;
using Infrastructure.Commands.ClassesCommands;
using Infrastructure.Queries;
using Domain.Entities;

namespace TestApp.Application
{
    public class ClassesService : Controller, IClassesService
    {
        private readonly IExecutor _executor;
        private readonly ITestContext _context;
        private readonly IHubContext<ClassesHub> _hubContext;
        public ClassesService(IExecutor executor, ITestContext context, IHubContext<ClassesHub> hubContext)
        {
            _executor = executor;
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<Guid> AddClassAsync(UpsertClassDto classDto)
        {
            var @class = await _executor.ExecuteAsync(new AddClassCommand(classDto));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Creating an class failed on save.");
            }
            if (@class.ClassId != null)
                await _hubContext.Clients.All.InvokeAsync("refresh", @class.ClassId);
            return @class.ClassId;
        }


        public async Task DeleteClassAsync(Guid classId)
        {
            var result = await _executor.ExecuteAsync(new DeleteClassCommand(classId));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Deting an class failed on save.");
            }
            if (result.Success)
                await _hubContext.Clients.All.InvokeAsync("refresh", classId);
        }

        public async Task<IEnumerable<ClassDto>> GetClassesAsync()
        {
            return await _executor.QueryAsync(new GetClasses());
        }

        public async Task<IEnumerable<Classes>> GetFullInfo()
        {
            return await _executor.QueryAsync(new GetFullInfo());
        }

        public async Task UpdateClassAsync(Guid classId, UpsertClassDto classDto)
        {
            var result = await _executor.ExecuteAsync(new UpdateClassCommand(classId, classDto));
            if (!await _context.CommitAsync())
            {
                throw new Exception("Updating an class failed on save.");
            }
            if (result.Success)
                await _hubContext.Clients.All.InvokeAsync("refresh", classId);
        }
    }
}
