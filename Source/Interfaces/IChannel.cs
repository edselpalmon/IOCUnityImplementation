using System;

namespace ServiceInterfaces
{
    public interface IChannel
    {
        int ChannelId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool Status { get; set; }
        DateTime DateCreated { get; set; }
        bool Initialized { get; set; }

    }
}
