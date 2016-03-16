using ServiceInterfaces;
using System;

namespace DataAccessClass
{
    public class Channel : IChannel
    {

        public virtual int ChannelId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Status { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool Initialized { get; set; }

    }


    public interface IChannelX
    {
        int ChannelId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool Status { get; set; }
        DateTime DateCreated { get; set; }
        bool Initialized { get; set; }
    }
}
