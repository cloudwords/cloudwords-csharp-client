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
        public string UploadLanguageDeliverable(int projectID, string langcode, string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language/" + langcode, APIToken, Enums.HttpVerb.PUT, "");
                restServiceClient.IsFileUpload = true;
                restServiceClient.FileFullName = fileFullName;
                if (File.Exists(fileFullName))
                {
                    response = (String)restServiceClient.ProcessRequest();
                }
                else
                {
                    response = "error: File does not exist";
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetBundledTranslatedMaterials(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadBundledTranslatedMaterials(int projectID)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string GetAllTranslatedMaterialsByLanguage(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetATranslatedMaterialByLanguage(int projectID, string languageCode)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language/" + languageCode + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadTranslatedMaterialByLanguage(int projectID, string languageCode)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language/" + languageCode + "/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string UploadTranslationMemory(int projectID, string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/tm", APIToken, Enums.HttpVerb.PUT, "");
                restServiceClient.IsFileUpload = true;
                restServiceClient.FileFullName = fileFullName;
                if (File.Exists(fileFullName))
                {
                    response = (String)restServiceClient.ProcessRequest();
                }
                else
                {
                    response = "error: File does not exist";
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetTMMetadata(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadTM(int projectID)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/tm/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string GetProjectTasks(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetProjectTasksWithStatus(int projectID, string status)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task/status/" + status + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetProjectTask(int projectID, int taskID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task/" + taskID + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAllProjectTasks()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "task.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAllProjectTasksWithStatus(string status)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "task/status/" + status + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string UpdateProjectTask(int projectID, int taskID, ProjectTask projectTask)
        {
            string response = "";
            try
            {

                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
                converter.Culture = System.Globalization.CultureInfo.InvariantCulture;
                string jsonData = JsonConvert.SerializeObject(projectTask, converter);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task/" + taskID, APIToken, Enums.HttpVerb.PUT, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
        public string GetTaskAttachment(int projectID, int taskID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task/" + taskID + "/file/attachment/content.json", APIToken, Enums.HttpVerb.GET, "");
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
