using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Application.SignalR
{
    public class StudentsHub: Hub
    {
        public void Refresh()
        {
            Clients.All.InvokeAsync("refresh");
        }
    }
}
