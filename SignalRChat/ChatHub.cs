using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SaySomething(string message)
        {
            Clients.All.speak(message + "from the server");
        }
    }
}