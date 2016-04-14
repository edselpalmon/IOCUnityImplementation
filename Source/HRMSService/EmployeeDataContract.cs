using System.Runtime.Serialization;

namespace HRMSService
{
    [DataContract]
    public class EmployeeDataContract
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
    }
}