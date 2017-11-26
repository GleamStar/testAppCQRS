using System;
using Microsoft.AspNetCore.SignalR;

namespace TestApp.Application.SignalR
{
    public class ClassesHub: Hub
    {
        public void Refresh() 
        {
            Clients.All.InvokeAsync("refresh");
        }
    }
}
