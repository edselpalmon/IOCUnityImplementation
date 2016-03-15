using System;
using DataAccessLayer;
using System.Windows.Forms;
using DataAccessClass;
using Entities;
using ServiceInterfaces;

namespace TestHibernate
{
    public partial class Form1 : Form
    {
        private IHibernateDAL _db = new HibernateDAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplayChannel.Clear();
            var tmpText = "User login ID Returned:";
            this.txtDisplayChannel.Text = tmpText + _db.GetChannelById(286).Username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
            txtDisplayChannel.Clear();
            var tmpText ="";
            this.txtDisplayChannel.Text = tmpText + _db.GetRecordsById<IEmployeeInformation>(1).LastName;
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                IEmployeeInformation employeeInformation = new EmployeeInformation
                {
                      FirstName = "ALFREDXX"
                     , MiddleName = "PREDOXX"
                     , LastName = "JARANILLAXX"
                     , BirthDate = DateTime.Parse("09/10/1975")
                     , CivilStatus = "M"
                     , Gender = "M"
                     , Salutation = "MR."
                     , Suffix = "III"
                     , EducationalAttainment = "C"
                };

                var retEmployeeInfo = _db.SaveInformation(employeeInformation);
                this.txtDisplayChannel.Text = _db.GetRecordsById<IEmployeeInformation>(retEmployeeInfo.EmployeeId).LastName;
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
                IEmployeeInformation employeeInformation = new EmployeeInformation
                {
                    EmployeeId = 4
                    , FirstName = "ALFREDO"
                    , MiddleName = "FRED"
                    , LastName = "JARANILLA"
                    , BirthDate = DateTime.Parse("10/10/1975")
                    , CivilStatus = "S"
                    , Gender = "M"
                    , Salutation = "MR."
                    , Suffix = "IV"
                    , EducationalAttainment = "C"
                };

                var retEmployeeInfo = _db.SaveInformation(employeeInformation);
                this.txtDisplayChannel.Text = _db.GetEmployeeById(retEmployeeInfo.EmployeeId).LastName;
            }
            catch (Exception exc)
            {
                this.txtDisplayChannel.Text = exc.Message;
            }
        }
    }
}
