namespace BlazorSignalRChatApp.Hubs
{
    public interface IChatHub
    {
        Task SuccessSendMessage(string user, string message);
    }
}
