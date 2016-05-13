using System.Runtime.Serialization;

namespace SelfHostedHRMSService.DataContracts
{
    public class User
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserRole { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserToken { get; set; }
    }
}