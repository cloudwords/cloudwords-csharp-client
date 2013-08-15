using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET.Classes;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Converters;
using System.Net;
using System.IO;

namespace Cloudwords.NET
{
    public class CloudwordsVendorClient
    {
        private string API_URL { get; set; } 
        public string APIToken { get; set; }
        public CloudwordsVendorClient(string url, string apiToken)
        {
            APIToken = apiToken;
            API_URL = url;
        }
        public string GetOpenProjects()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/open.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetClosedProjects()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/closed.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetProject(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
    }
}
