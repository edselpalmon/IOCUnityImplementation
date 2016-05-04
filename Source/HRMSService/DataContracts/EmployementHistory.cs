using System;
using System.Runtime.Serialization;

namespace HRMSService.DataContracts
{
    public class EmployementHistory
    {
        [DataMember]
        public virtual Int64 EmployementHistoryId { get; set; }
        [DataMember]
        public virtual string CompanyName { get; set; }
        [DataMember]
        public virtual string CompanyAddress { get; set; }
        [DataMember]
        public virtual DateTime StartDate { get; set; }
        [DataMember]
        public virtual DateTime EndDate { get; set; }
        [DataMember]
        public virtual string LastPositionHeld { get; set; }
        [DataMember]
        public virtual string Industry { get; set; }
        
    }
}
