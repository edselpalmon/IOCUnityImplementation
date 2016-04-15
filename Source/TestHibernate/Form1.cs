using System;
using System.Windows.Forms;
using DataAccessClass;
using Entities;
using ServiceInterfaces;
using EntityInterfaces;
using NHibernate;
using System.Collections.Generic;
using IOCFactory;

namespace TestHibernate
{
    public partial class Form1 : Form
    {

        private IHibernateDAL _db = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _db.OpenHibernateSession<ISession>("WebHookDB");

            txtDisplayChannel.Clear();
            var tmpText = "User login ID Returned:";
            this.txtDisplayChannel.Text = tmpText + _db.GetChannelById(286).Username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _db.OpenHibernateSession<ISession>("WebHookDB");

            var channel = new Channel
            {
                 ChannelId = 199
                 ,DateCreated = DateTime.Now
                 ,Initialized = false
                 ,Password = "MyPassxx5"
                 ,Status = true
                 ,Username = "EdselPxxx5"
            };

            _db.SaveChannel(channel);
            var tmpText = "User login ID Returned:";
            this.txtDisplayChannel.Text = tmpText + _db.GetChannelById(channel.ChannelId).Username;

        }

        private void btnGetEmployee_Click(object sender, EventArgs e)
        {
            _db.OpenHibernateSession<ISession>("HRMSDB");

            var id = Int64.Parse(txtDisplayChannel.Text);
            txtDisplayChannel.Clear();
            var tmpText ="";
            this.txtDisplayChannel.Text = tmpText + _db.GetRecordById<IEmployeeInformation>(id).LastName;
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                _db.OpenHibernateSession<ISession>("HRMSDB");

                //this will create both EmployeeInformation, addresses, educational backgrounds and employement history

                IEmployeeInformation employeeInformation = new EmployeeInformation
                {
                    FirstName = "EDUCTEST"
                     , MiddleName = "EDUCTEST"
                     , LastName = "EDUCTEST"
                     , BirthDate = DateTime.Parse("09/10/1975")
                     , CivilStatus = "M"
                     , Gender = "M"
                     , Salutation = "MR."
                     , Suffix = "III"
                     , EducationalAttainment = "C"
                     , EmployeeAddresses = new List<IEmployeeAddress>()
                     , EmployementHistories = new List<IEmployementHistory>()
                     , EducationalBackgrounds = new List<IEducationalBackground>()
                };

                var employeeAddress = new EmployeeAddress
                {
                    AddressLine1 = "Latest Addr1"
                    , AddressLine2 = "Latest Addr2"
                    , City = "Pasig"
                    , PostalCode = "1609"
                    , Province = "MyProvince"
                    , State = "MyState"
                    , Country = "Philippines"
                    , EmployeeInformation = employeeInformation
                };

                var employementHistory = new EmployementHistory
                {
                    CompanyAddress = "CompanyAddr"
                    , CompanyName = "Company Name"
                    , EndDate = DateTime.Parse("10/11/2015")
                    , StartDate = DateTime.Parse("03/11/2011")
                    , Industry = "Industry"
                    , LastPositionHeld = "System Analyst"
                    , EmployeeInformation = employeeInformation
                };

                var educationalBackground = new EducationalBackground
                {
                     SchoolCode = "PUP"
                    , SchoolName = "Polytechnic University of the Philippines"
                    , SchoolAddress = "Sta. Mesa, Manila"
                    , Degree = "BSCoE"
                    , DateAttended = DateTime.Parse("06/01/1992")
                    , DateGraduated = DateTime.Parse("03/31/1997")
                    , EmployeeInformation = employeeInformation
                };
                
                employeeInformation.EmployeeAddresses.Add(employeeAddress);
                employeeInformation.EmployementHistories.Add(employementHistory);
                employeeInformation.EducationalBackgrounds.Add(educationalBackground);

                var retEmployeeInfo = _db.SaveRecord(employeeInformation);
                this.txtDisplayChannel.Text = _db.GetRecordById<IEmployeeInformation>(retEmployeeInfo.EmployeeId).LastName;
            }
            catch (Exception exc)
            {
                this.txtDisplayChannel.Text = exc.Message;
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                _db.OpenHibernateSession<ISession>("HRMSDB");

                //this will update employeeinfo, addresses, educational background and employement history

                var id = Int64.Parse(txtDisplayChannel.Text);

                var employeeInformation = _db.GetRecordById<IEmployeeInformation>(id); //_db.LoadRecordInfo<IEmployeeInformation>(3); alternative
                employeeInformation.FirstName = "WAKAKAUlit";

                var employeeAddress = new EmployeeAddress
                    {
                      AddressLine1 = "Updatedxxxx Addr1"
                      , AddressLine2 = "Updatedxxxxx Addr2"
                      , City = "Pasig"
                      , PostalCode = "1609"
                      , Province = "MyProvince"
                      , State = "MyState"
                      , Country = "Philippines"
                      , EmployeeInformation = employeeInformation
                };
                
                employeeInformation.EmployeeAddresses.Add(employeeAddress);

                var employementHistory = new EmployementHistory
                {
                    CompanyAddress = "CompanyAddr"
                    , CompanyName = "Company Name"
                    , EndDate = DateTime.Parse("10/11/2015")
                    , StartDate = DateTime.Parse("03/11/2011")
                    , Industry = "Industry"
                    , LastPositionHeld = "System Analyst"
                    , EmployeeInformation = employeeInformation
                };

                employeeInformation.EmployementHistories.Add(employementHistory);

                var educationalBackground = new EducationalBackground
                {
                     SchoolCode = "PUP"
                    , SchoolName = "Polytechnic University of the Philippines"
                    , SchoolAddress = "Sta. Mesa, Manila"
                    , Degree = "BSCoE"
                    , DateAttended = DateTime.Parse("06/01/1992")
                    , DateGraduated = DateTime.Parse("03/31/1997")
                    , EmployeeInformation = employeeInformation
                };

                employeeInformation.EducationalBackgrounds.Add(educationalBackground);

                var retEmployeeInfo = _db.SaveRecord(employeeInformation);
                this.txtDisplayChannel.Text = _db.GetRecordById<IEmployeeInformation>(retEmployeeInfo.EmployeeId).LastName;


            }
            catch (Exception exc)
            {
                this.txtDisplayChannel.Text = exc.Message;
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                _db.OpenHibernateSession<ISession>("HRMSDB");

                var id = Int64.Parse(txtDisplayChannel.Text);

                var employee = _db.GetRecordById<IEmployeeInformation>(id);
                _db.DeleteRecord(employee);
            }
            catch (Exception exc)
            {
                this.txtDisplayChannel.Text = exc.Message;
            }
        }
    }
}
