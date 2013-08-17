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
        public string GetSourceMaterial(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/source.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadSourceMaterial(int projectID)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/source/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();

            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string GetAllReferenceMaterials(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAReferenceMaterial(int projectID, int referenceID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference/" + referenceID + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadReferenceMaterial(int projectID, int referenceID)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference/" + referenceID + "/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string GetBid(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string AcceptRejectBid(int projectID, string code)
        {
            string response = "";
            try
            {
                Status status = new Status(null, code);

                TranslatedMaterialStatus translatedMaterialStatus = new TranslatedMaterialStatus(status);

                JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                string jsonData = JsonConvert.SerializeObject(translatedMaterialStatus, _jsonSerializerSettings);

                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid.json", APIToken, Enums.HttpVerb.POST, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string SubmitBid(int projectID, Bid bid)
        {
            string response = "";
            try
            {
                JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                string jsonData = JsonConvert.SerializeObject(bid, _jsonSerializerSettings);
                //string jsonData = JsonConvert.SerializeObject(bid);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid.json", APIToken, Enums.HttpVerb.PUT, jsonData);
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
