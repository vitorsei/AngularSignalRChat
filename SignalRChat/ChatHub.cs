using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(SendData data)
        {
            Clients.Group(data.roomName).newMessage(data.name + ": " + data.message);
        }

        public void JoinRoom(string roomName)
        {
            Groups.Add(Context.ConnectionId, roomName);
        }

        public void LeaveRoom(string roomName)
        {
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }

    public class SendData
    {
        public string roomName { get; set; }
        public string message { get; set; }
        public string name { get; set; }
    }
}