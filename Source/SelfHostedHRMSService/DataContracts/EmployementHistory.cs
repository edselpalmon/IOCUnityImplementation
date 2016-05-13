using System;
using System.Runtime.Serialization;

namespace SelfHostedHRMSService.DataContracts
{
    public class EmployementHistory
    {
        [DataMember]
        public Int64 EmployementHistoryId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string LastPositionHeld { get; set; }
        [DataMember]
        public string Industry { get; set; }
        
    }
}
