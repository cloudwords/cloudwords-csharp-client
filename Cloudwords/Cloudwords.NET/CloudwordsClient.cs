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
    public class CloudwordsClient
    {
        private string API_URL { get; set; } 
        public bool TestMode { get; set; }
        public string APIToken { get; set; }
        public CloudwordsClient(bool testMode, string apiToken)
        {
            TestMode = TestMode;
            APIToken = apiToken;
            
            if(testMode)
                API_URL = "https://api-stage.cloudwords.com/1/";
            else
                API_URL = "https://api.cloudwords.com/1/";
        }
        public string CreateProject(Project project)
        {
            string response="";
            try
            {

                if (project.intendedUse != null)
                {
                    if (project.intendedUse.id == 0)
                    {
                        project.intendedUse = null;
                    }
                }
                if (project.department != null)
                {
                    if (project.department.id == 0)
                    {
                        project.department = null;
                    }
                }
                if (project.owner != null)
                {
                    if (project.owner.id == 0)
                    {
                        project.owner = null;
                    }
                }
                if (project.followers != null)
                {
                    if (project.followers.Count == 0)
                    {
                        project.followers = null;
                    }
                }
                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
                converter.Culture = System.Globalization.CultureInfo.InvariantCulture;
                string jsonData = JsonConvert.SerializeObject(project, converter);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project", APIToken, Enums.HttpVerb.POST, jsonData);
                response = (String) restServiceClient.ProcessRequest();
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
        /// <summary>
        /// Note: If you you do not want to update any specific field just set it to null
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public string UpdateProject(int projectID,Project project)
        {
            string response = "";
            try
            {
                if (project.status != null)
                {
                    if (project.status.code == "")
                    {
                        project.status = null;
                    }
                }
                if (project.intendedUse != null)
                {
                    if (project.intendedUse.id == 0)
                    {
                        project.intendedUse = null;
                    }
                }
                if (project.department != null)
                {
                    if (project.department.id == 0)
                    {
                        project.department = null;
                    }
                }
                if (project.owner != null)
                {
                    if (project.owner.id == 0)
                    {
                        project.owner = null;
                    }
                }
                if (project.followers != null)
                {
                    if (project.followers.Count == 0)
                    {
                        project.followers = null;
                    }
                }
                if (!project.bidDueDate.HasValue)
                {
                    project.bidDueDate = null;
                }
                if (!project.bidSelectDeadlineDate.HasValue)
                {
                    project.bidSelectDeadlineDate = null;
                }
                if (!project.createdDate.HasValue)
                {
                    project.createdDate = null;
                }
                if (!project.deliveryDueDate.HasValue)
                {
                    project.deliveryDueDate = null;
                }
                if (!project.reviewDueDate.HasValue)
                {
                    project.reviewDueDate = null;
                }
                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
                converter.Culture = System.Globalization.CultureInfo.InvariantCulture;
                string jsonData = JsonConvert.SerializeObject(project, converter);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID.ToString(), APIToken, Enums.HttpVerb.PUT, jsonData);
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
            HttpWebResponse response=null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/source/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse) restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
               // response = ex.Message;
            }
            return response;
        }
        public string UploadSourceMaterial(int projectID,string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/source", APIToken, Enums.HttpVerb.PUT, "");
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
        public string GetAReferenceMaterial(int projectID,int referenceID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference/"+referenceID+".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public HttpWebResponse DownloadReferenceMaterial(int projectID,int referenceID)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference/" + referenceID + "/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                // response = ex.Message;
            }
            return response;
        }
        public string UploadReferenceMaterial(int projectID, string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference", APIToken, Enums.HttpVerb.POST, "");
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
        public string UpdateReferenceMaterial(int projectID, int referenceID,string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/reference/" + referenceID, APIToken, Enums.HttpVerb.PUT, "");
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
    }
}
