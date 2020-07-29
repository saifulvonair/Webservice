//######################################################################
//# FILENAME: ApplicationInstanceChecker
//#
//# DESCRIPTION:
//# 
//#
//# AUTHOR:		Mohammad Saiful Alam
//# POSITION:	Senior General Manager
//# E-MAIL:		saiful.alam@ bjitgroup.com
//# CREATE DATE: ...
//#
//# Copyright (c): Free to use
//######################################################################

namespace CallWebService
{
    public interface IWebService
    {
        object Tag { get; set; }
        //
        string Status { get; }
        //
        void execute(ApiCallArgument apiArgument, IDelegeateObserver observer);
        //
        void cancel();
        //
        IDelegeateObserver DelegeateObserver { get; set; }
    }

    //
    public class ApiCallArgument
    {
        //
        public string Url;
        public string ApiName;
        //
        public string UseName = "";
        public string Password = "";
        //
        public object Parameter;
        //
        public bool POST = true;
        //
        public ApiCallArgument(string url, string api, bool post = true)
        {
            this.Url = url;
            this.ApiName = api;
            this.POST = post;
        }
    }
    //
    //
    public class ResponseObject
    {
        public ResponseObject(object result)
        {
            this.Result = result;
        }
        public object Result;
        public object HttpResponseMessage;
    }
    //
    public delegate void IDelegeateObserver(object argument);
        
}
