using System;
using System.Runtime.Serialization;

namespace SelfHostedHRMSService.DataContracts
{
    public class EducationalBackground
    {
        [DataMember]
        public Int64 EducationId { get; set; }
        [DataMember]
        public string SchoolCode { get; set; }
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string SchoolAddress { get; set; }
        [DataMember]
        public DateTime DateAttended { get; set; }
        [DataMember]
        public DateTime DateGraduated { get; set; }
        [DataMember]
        public string Degree { get; set; }
    }
}
