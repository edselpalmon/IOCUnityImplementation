using Entities;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System;
using System.Windows.Forms;

namespace HRMS
{
    public partial class frm201File : Form
    {
        private IHibernateDAL _dal = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
        private ISession _dbSession;

        public frm201File()
        {
            InitializeComponent();
            //open a session
            _dbSession = _dal.OpenHibernateSession<ISession>("HRMSDB");
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            var allTestTable = _dal.GetRecords<ITestTable>();
            var allEmployee = _dal.GetRecords<IEmployeeInformation>();


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
    }
}
