using System;
using System.Runtime.Serialization;

namespace WindowsService1.DataContracts
{
    public class EmployeeAddress
    {
        [DataMember]
        public Int64 AddressId { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
    }
}
