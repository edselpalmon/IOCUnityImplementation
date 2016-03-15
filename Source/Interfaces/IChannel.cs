using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
