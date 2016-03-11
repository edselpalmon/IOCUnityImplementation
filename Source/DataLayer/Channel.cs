using System;

namespace DataAccessClass
{
    public class Channel
    {

        //private int _ChannelId;
        //private string _Username;
        //private string _Password;
        //private bool _Status;
        //private DateTime _DateCreated;
        //private bool _Initialized;


        public virtual int ChannelId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Status { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool Initialized { get; set; }

    }
}
