using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRChatApp.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.Others.SuccessSendMessage(Context.ConnectionId, $"joined the party!");
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    await Clients.Others.SuccessSendMessage(Context.ConnectionId, $"left the party!");
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SuccessSendMessage(user, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SuccessSendMessage(Context.ConnectionId, $"joined the {groupName}!");
        }

        public async Task SendMessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SuccessSendMessage(Context.ConnectionId, $"{message}");
        }
    }
}
