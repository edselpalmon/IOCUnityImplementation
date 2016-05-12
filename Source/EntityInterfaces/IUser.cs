using System;

namespace EntityInterfaces
{
    public interface IUser
    {
        Int64 UserId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string UserToken { get; set; }
        string UserRole { get; set; }
        DateTime? TokenExpiryDate { get; set; }
        IEmployeeInformation EmployeeInformation { get; set; }
    }
}
