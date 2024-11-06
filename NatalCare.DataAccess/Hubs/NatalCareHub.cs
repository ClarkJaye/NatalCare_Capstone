﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NatalCare.Models.Entities;

namespace PrinceQ.DataAccess.Hubs
{
    public class NatalCareHub : Hub
    {
        private readonly UserManager<User> _userManager;

        public NatalCareHub(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _userManager.GetUserAsync(Context.User!);
            if (user != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, user.Id);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _userManager.GetUserAsync(Context.User!);
            if (user != null)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.Id);
            }

            await base.OnDisconnectedAsync(exception);
        }
   
    }
}