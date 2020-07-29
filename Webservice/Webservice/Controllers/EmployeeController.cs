//#####################################################################
//# DESCRIPTION:
//#
//# AUTHOR:		Mohammad Saiful Alam (Jewel)
//# POSITION:	Senior General Manager
//# E-MAIL:		saiful_vonair@yahoo.com
//# CREATE DATE: 
//#
//# Copyright: Free to use
//######################################################################
using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using Webservice.Models;

namespace Webservice.Controllers
{
    //http://zetcode.com/csharp/httpclient/
    //https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_web_api.htm

    public class EmployeeController : ApiController
    {
        //
         Employee[] employees = new Employee[]{
             new Employee {  ID = "Saiful", Name = "Saiful", Division = "SD4" },
             new Employee { ID = "Shakib", Name = "Shakib" , Division = "SD1" },
             new Employee { ID = "Fatiha", Name = "Fatiha" , Division = "SD3"}
        };

        //
        Login[] logins = new Login[]{
             new Login { ID = "Saiful", Password = "1111"},
             new Login { ID = "Shakib", Password = "3333"},
             new Login { ID = "Fatiha", Password = "2222"},
        };
        
        //[HttpPost]
        public IHttpActionResult GetAllEmployees()
        {
            try
            {
                var employee = verifyHeader();
                if (employee == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return Ok(employees);
        }            
  
        [HttpPost]
        public IHttpActionResult post(Login obj)
        {
            Employee employee = login(obj.ID, obj.Password);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        
        // Normal GET method..
        public IHttpActionResult Get(string id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        Employee login(string id, string password)
        {
            var ID = logins.FirstOrDefault((p) => p.ID == id);
            var Pass = logins.FirstOrDefault((p) => p.Password == password);

            if (ID != null && Pass != null)
            {
                Employee emp = employees.FirstOrDefault((p) => p.ID == id);
                return emp;
            }
            return null;
        }

        Employee verifyHeader()
        {
            string value = Request.Headers.Authorization.Parameter;
            string result = Encoding.ASCII.GetString(Convert.FromBase64String(value));
            string[] values = result.Split(':');
            var employee = employees.FirstOrDefault((p) => p.ID == values[0]);
            //
            return employee;
        }
    }
}
