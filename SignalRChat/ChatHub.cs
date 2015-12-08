using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace SignalRChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(SendData data)
        {
            Clients.Group(data.roomName, Context.ConnectionId).newMessage(data.name + ": " + data.message);

        }

        public void JoinRoom(string roomName, string name)
        {
            Clients.OthersInGroup(roomName).newNotification(name + " has joined the room.");
            Groups.Add(Context.ConnectionId, roomName);
        }

        public void LeaveRoom(string roomName, string name)
        {
            Clients.OthersInGroup(roomName).newNotification(name + " has left the room.");
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }

    public class SendData
    {
        public string message { get; set; }
        public string roomName { get; set; }
        public string name { get; set; }
    }
}