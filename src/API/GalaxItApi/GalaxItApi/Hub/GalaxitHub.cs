using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GalaxItApi.Hub
{
    public interface IActionClient
    {
        Task UpdateSeats(bool[] table);
    }
    public class GalaxitHub:Hub<IActionClient>
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public async Task JoinGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroupAsync(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
