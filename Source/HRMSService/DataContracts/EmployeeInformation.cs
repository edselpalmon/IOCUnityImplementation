using System.Runtime.Serialization;

namespace HRMSService.DataContracts
{
    [DataContract]
    public class EmployeeInformation
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
    }
}