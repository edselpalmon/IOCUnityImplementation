using EntityInterfaces;
using System;
using System.Reflection;


namespace Entities
{
    public class User : IUser
    {
        public virtual Int64 UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserToken { get; set; }
        public virtual string UserRole { get; set; }   
        public virtual DateTime? TokenExpiryDate { get; set; }
        public virtual IEmployeeInformation EmployeeInformation { get; set; }

    }
}
