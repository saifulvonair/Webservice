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
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Text;

//http://zetcode.com/csharp/httpclient/
//https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_web_api.htm
namespace CallWebService
{
    class WebApiCall : AbsWebService
    {
        public WebApiCall(Label progress) : base(progress)
        {

        }

        private HttpClient  setup()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //To FIX this => "The request was aborted: Could not create SSL/TLS secure channel."
            // using System.Net;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons

            return client;
        }

        // Match with Webservice
        // public IHttpActionResult Get(string id)
        private async void executeGET(ApiCallArgument apiArgument)
        {
            try
            {
                HttpClient client = setup();
                //
                HttpResponseMessage response = await client.GetAsync(apiArgument.ApiName+ "/"+ apiArgument.Parameter);
                HttpResponseMessage message =  response.EnsureSuccessStatusCode();
                
                // Get the URI of the created resource.  
                var responseAsString = await response.Content.ReadAsStringAsync();
                //var json = JsonConvert.DeserializeObject(responseAsString);
                //var responseAsType = JsonConvert.DeserializeObject<Employee>(responseAsString);
                //notifyObserver(new ResponseObject(responseAsType));
                notifyObserver(new ResponseObject(responseAsString));
            }
            catch (Exception e)
            {
                notifyObserver(new ResponseObject(e));
            }
        }

        // Match with Webservice
        // public IHttpActionResult post(Login obj)
        private async void executePOST(ApiCallArgument apiArgument)
        {
            try
            {
                HttpClient client = setup();
                HttpResponseMessage response = await client.PostAsJsonAsync(apiArgument.ApiName, apiArgument.Parameter);
                HttpResponseMessage message = response.EnsureSuccessStatusCode();
                // Get the URI of the created resource.  
                var responseAsString = await response.Content.ReadAsStringAsync();
                //var json = JsonConvert.DeserializeObject(responseAsString);
                //var responseAsType = JsonConvert.DeserializeObject<Employee>(responseAsString);
                //notifyObserver(new ResponseObject(responseAsType)); 
                notifyObserver(new ResponseObject(responseAsString));
            }
            catch (Exception e)
            {
                notifyObserver(new ResponseObject(e));
            }
        }

        async void execute(ApiCallArgument apiArgument)
        {
            try
            {
                HttpClient client = setup();
                //
                var authToken = Encoding.ASCII.GetBytes($"{apiArgument.UseName}:{apiArgument.Password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                //
                HttpResponseMessage response = await client.GetAsync(apiArgument.ApiName);
                HttpResponseMessage message = response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();
                //var responseAsType = JsonConvert.DeserializeObject<Employee[]>(responseAsString);
                //              
                // notifyObserver(new ResponseObject(responseAsType));
                notifyObserver(new ResponseObject(responseAsString));
            }
            catch (Exception e)
            {
                notifyObserver(new ResponseObject(e));
            }
        }

        // http://localhost/Webservice/api/
        // Match with GetAllEmployees
        // Pass User and Password in Authorization with Ecoding 
        public override  void execute(ApiCallArgument apiArgument, IDelegeateObserver observer)
        {
            this.url = apiArgument.Url;
            // Set the Notiifcation Observer..
            this.mDelegeateObserver = observer;
            
            if(apiArgument.Parameter != null)
            {
                if (!apiArgument.POST)
                {
                    executeGET(apiArgument);
                }
                else
                {
                    executePOST(apiArgument);
                }
            }
            else
            {
                execute(apiArgument);
            }
        }
    }
}
