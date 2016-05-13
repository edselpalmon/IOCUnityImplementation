using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SelfHostedHRMSService.DataContracts
{
    [DataContract]
    public class EmployeeInformation
    {
        [DataMember]
        public Int64 EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public DateTime? BirthDate { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string CivilStatus { get; set; }
        [DataMember]
        public string EducationalAttainment { get; set; }
        [DataMember]
        public IList<EmployeeAddress> EmployeeAddresses { get; set; }
        [DataMember]
        public IList<EmployementHistory> EmployementHistories { get; set; }
        [DataMember]
        public IList<EducationalBackground> EducationalBackgrounds { get; set; }

    }
}