using Entities;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace HRMS
{
    public partial class frm201File : Form
    {
        private IHibernateDAL _dal = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
        private ISession _dbSession;
        private ITransactionLogger _logger = DependencyFactory.Resolve<ITransactionLogger>("TransactionLogger");
        private IList<IEmployeeInformation> _employees;

        public frm201File()
        {
            InitializeComponent();
            //open a session
            _dbSession = _dal.OpenHibernateSession<ISession>("HRMSDB");
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            _logger.CreateInfoLog("frm201File", "btnEmployeeSearch_Click", "Search employee transaction");

           
            var allEmployee = _dal.GetRecords<IEmployeeInformation>();

            _employees = _dal.GetRecords<IEmployeeInformation>();

            gvPersonalInfo.AutoGenerateColumns = false;
            gvPersonalInfo.DataSource = _employees;

            var allTestTable = _dal.GetRecords<ITestTable>();
            var test = _dal.GetRecordById<ITestTable>(1);
            var testtbl = new TestTable
            {
                TestDesc = "jjdhkasdh",
                TestName = "xxxxxx"
            };
            _dal.SaveRecord<ITestTable>(testtbl);

            var employeeInformation = _dal.GetRecordById<IEmployeeInformation>(65);


        }

        private void frm201File_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dbSession.Close();
            _dbSession.Dispose();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            var employeeInformation = DependencyFactory.Resolve<IEmployeeInformation>("EmployeeInformation");
            employeeInformation.FirstName = "JENNY";
            employeeInformation.MiddleName = "S";
            employeeInformation.LastName = "VILLA";
            employeeInformation.BirthDate = DateTime.Parse("09/10/1975");
            employeeInformation.CivilStatus = "M";
            employeeInformation.Gender = "F";
            employeeInformation.Salutation = "MS.";
            employeeInformation.Suffix = "III";
            employeeInformation.EducationalAttainment = "C";
            employeeInformation.EmployeeAddresses = new List<IEmployeeAddress>();
            employeeInformation.EmployementHistories = new List<IEmployementHistory>();
            employeeInformation.EducationalBackgrounds = new List<IEducationalBackground>();


            var employeeAddress = DependencyFactory.Resolve<IEmployeeAddress>("EmployeeAddress");
            employeeAddress.AddressLine1 = "Latest Addr1";
            employeeAddress.AddressLine2 = "Latest Addr2";
            employeeAddress.City = "Pasig";
            employeeAddress.PostalCode = "1609";
            employeeAddress.Province = "MyProvince";
            employeeAddress.State = "MyState";
            employeeAddress.Country = "Philippines";
            employeeAddress.EmployeeInformation = employeeInformation;

            var employementHistory = DependencyFactory.Resolve<IEmployementHistory>("EmployementHistory");
            employementHistory.CompanyAddress = "CompanyAddr";
            employementHistory.CompanyName = "Company Name";
            employementHistory.EndDate = DateTime.Parse("10/11/2015");
            employementHistory.StartDate = DateTime.Parse("03/11/2011");
            employementHistory.Industry = "Industry";
            employementHistory.LastPositionHeld = "System Analyst";
            employementHistory.EmployeeInformation = employeeInformation;

            var educationalBackground = DependencyFactory.Resolve<IEducationalBackground>("EducationalBackground");
            educationalBackground.SchoolCode = "PUP";
            educationalBackground.SchoolName = "Polytechnic University of the Philippines";
            educationalBackground.SchoolAddress = "Sta. Mesa, Manila";
            educationalBackground.Degree = "BSCoE";
            educationalBackground.DateAttended = DateTime.Parse("06/01/1992");
            educationalBackground.DateGraduated = DateTime.Parse("03/31/1997");
            educationalBackground.EmployeeInformation = employeeInformation;
                
            employeeInformation.EmployeeAddresses.Add(employeeAddress);
            employeeInformation.EmployementHistories.Add(employementHistory);
            employeeInformation.EducationalBackgrounds.Add(educationalBackground);

            var retEmployeeInfo = _dal.SaveRecord(employeeInformation);
            
        }

        private void gvPersonalInfo_Click(object sender, EventArgs e)
        {

            var parentGrid = (DataGridView)sender;
            var selectedid = (Int64)parentGrid.CurrentRow.Cells[0].Value;
            var childsource = (from employee in _employees
                               where employee.EmployeeId == selectedid
                               select employee.EmployementHistories).FirstOrDefault();

            var childview = new DataGridView();
            childview.AutoGenerateColumns = true;
            childview.DataSource = childsource;

            gvPersonalInfo.Controls.Add(childview);
        }
    }
}
