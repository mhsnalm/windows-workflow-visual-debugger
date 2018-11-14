using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net;
using System.IO;

namespace WindowsWorkflowVisualDebugger.Activity
{

    public sealed class InvokeWebService : CodeActivity
    {
        public InArgument<String> BasePath { get; set; }

        public InArgument<String> Method { get; set; }

        public InArgument<String> Action { get; set; }
            
        public InArgument<String> Parameters { get; set; }

        public OutArgument<String> Response { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            string basePath = BasePath.Get(executionContext).ToString();
            string method = Method.Get(executionContext).ToString() ;
            string action = Action.Get(executionContext)?.ToString();
            string parameters = Parameters.Get(executionContext)?.ToString();

            string _webAddress = basePath + "/" + method;

            string json = CallService(_webAddress);
        }

        String CallService(string svcUri)
        {
            String response = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(svcUri);
                request.ContentType = "application/json; charset=utf-8";


                var tmp = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(tmp.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                
            }

            return response;
        }
    }
}
