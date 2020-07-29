using CallWebService;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CallWebService
{
    public partial class MainForm : Form
    {
        public class Employee
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Division { get; set; }
        }

        public class Login
        {
            public string ID { get; set; }
            public string Password { get; set; }
        }
        //
        public MainForm()
        {
            InitializeComponent();
        }
        
       

        private void btnWebApi_Click(object sender, EventArgs e)
        {
            WebApiCall web = new WebApiCall(null);
            ApiCallArgument ar = new ApiCallArgument(txtServerUrl.Text, "Employee");
            ar.UseName = txtUser.Text;
            ar.Password = txtPass.Text;
            //
            web.execute(ar, delegate (object p)
            {
                ResponseObject res = (ResponseObject)p;
                this.parseEmployee(res);
               
                return;
            });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            WebApiCall web = new WebApiCall(null);
            ApiCallArgument ar = new ApiCallArgument(txtServerUrl.Text, "Employee");
            ar.UseName = txtUser.Text;
            ar.Password = txtPass.Text;
            ar.Parameter = new Login() { ID = txtUser.Text, Password = txtPass.Text };
            //
            web.execute(ar, delegate (object p)
            {
                Employee emp = parseSingleEmployee(p);
                if(emp != null)
                {
                    this.lblLoginID.Text = "Login as: "+ emp.Name;
                }
            });
        }

        void parseEmployee(ResponseObject obj)
        {
            try
            {
                var responseAsType = JsonConvert.DeserializeObject<Employee[]>((string)obj.Result);

               // Employee[] responseAsType = (Employee[])responseAsType;
                this.listBox1.Items.Clear();
                //
                foreach (Employee emp in responseAsType)
                {
                    this.listBox1.Items.Add("ID: " + emp.ID + ", Name:" + emp.Name + ", Division: " + emp.Division);
                }
            }
            catch(Exception e)
            {
                //new Login { ID = "Saiful", Password = "1111"},
                //new Login { ID = "Shakib", Password = "3333" },
                //new Login { ID = "Fatiha", Password = "2222" },
                MessageBox.Show("Please login with valid User and Password Sample..-> ID = Saiful, Password = 1111");
            }
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            WebApiCall web = new WebApiCall(null);
            ApiCallArgument ar = new ApiCallArgument(txtServerUrl.Text, "Employee", false);
            ar.UseName = txtUser.Text;
            ar.Password = txtPass.Text;
            ar.Parameter = "Saiful";
            //
            web.execute(ar, delegate (object p)
            {
                parseSingleEmployee(p);
            });

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            WebApiCall web = new WebApiCall(null);
            ApiCallArgument ar = new ApiCallArgument(txtServerUrl.Text, "Employee");
            ar.UseName = txtUser.Text;
            ar.Password = txtPass.Text;
            ar.Parameter = new Login() { ID = txtUser.Text, Password = txtPass.Text };
            //
            web.execute(ar, delegate (object p)
            {
                parseSingleEmployee(p);
            });
        }

        Employee parseSingleEmployee(object p)
        {
           try
            {
                ResponseObject obj = (ResponseObject)p;
                var responseAsType = JsonConvert.DeserializeObject<Employee>((string)obj.Result);
                if (responseAsType is Employee)
                {
                    MessageBox.Show("Success");
                    return responseAsType;
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
