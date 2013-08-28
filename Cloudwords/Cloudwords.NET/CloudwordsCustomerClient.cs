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
    public class CloudwordsCustomerClient
    {
        private string API_URL { get; set; } 
        public string APIToken { get; set; }
        public CloudwordsCustomerClient(string url, string apiToken)
        {
            APIToken = apiToken;
            API_URL = url;
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
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception)
            {
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
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception)
            {
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
        public string CreateBidRequest( int projectID, BidRequest bidRequest)
        {
            string response = "";
            try
            {
                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
                converter.Culture = System.Globalization.CultureInfo.InvariantCulture;
                string jsonData = JsonConvert.SerializeObject(bidRequest, converter);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid-request", APIToken, Enums.HttpVerb.POST, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
        public string GetBidRequest(int projectID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid-request/current.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string SelectAWinningBid(int projectID, int winningBidId)
        {
            string response = "";
            try
            {
                WinningBid winningBid = new WinningBid(winningBidId);
                string jsonData = JsonConvert.SerializeObject(winningBid);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid-request", APIToken, Enums.HttpVerb.PUT, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAllBids(int projectID)
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
        public string GetBid(int projectID,int bidID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/bid/" + bidID + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
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
            catch (Exception)
            {
               
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
        public string GetATranslatedMaterialByLanguage(int projectID,string languageCode)
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
        public HttpWebResponse DownloadTranslatedMaterialByLanguage(int projectID,string languageCode)
        {
            HttpWebResponse response = null;
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language/" + languageCode + "/content", APIToken, Enums.HttpVerb.GET, "");
                restServiceClient.IsFileDownload = true;
                response = (HttpWebResponse)restServiceClient.ProcessRequestForFileDownload();
            }
            catch (Exception)
            {
            }
            return response;
        }

        public string ApproveTranslatedMaterial(int projectID, string languageCode)
        {
            string response = "";
            try
            {
                Status status = new Status(null,"approved");

                TranslatedMaterialStatus translatedMaterialStatus = new TranslatedMaterialStatus(status);

                JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                string jsonData = JsonConvert.SerializeObject(translatedMaterialStatus, _jsonSerializerSettings);

                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/file/translated/language/" + languageCode, APIToken, Enums.HttpVerb.PUT, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
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

        public string CreateProjectTask(int projectID, ProjectTask projectTask)
        {
            string response = "";
            try
            {

                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
                converter.Culture = System.Globalization.CultureInfo.InvariantCulture;
                
                string jsonData = JsonConvert.SerializeObject(projectTask, converter);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task", APIToken, Enums.HttpVerb.POST, jsonData);
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
        public string UploadTaskAttachment(int projectID, int taskID,string fileFullName)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/" + projectID + "/task/" + taskID + "/file/attachment/content", APIToken, Enums.HttpVerb.PUT, "");
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
        public string GetTaskAttachment(int projectID,int taskID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project/"+projectID+"/task/"+taskID+"/file/attachment/content.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetPreferredVendors()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "vendor/preferred.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAVendor(int vendorID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "vendor/" + vendorID + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetSourceLanguages()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "org/settings/project/language/source.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetTargetLanguages()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "org/settings/project/language/target.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetDepartments()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string CreateDepartment(string departmentName)
        {
            string response = "";
            try
            {
                var department = new { name=departmentName};

                string jsonData = JsonConvert.SerializeObject(department);
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department", APIToken, Enums.HttpVerb.POST, jsonData);
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetCurrentUser()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "user/current.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetActiveUsers()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "user.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAvailableFollowers()
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "follower/available.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetOpenProjectsByDepartment(int departmentID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/project/open.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetClosedProjectsByDepartment(int departmentID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/project/closed.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAllProjectTasksByDepartment(int departmentID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/task.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAllProjectTasksWithStatusByDepartment(int departmentID,string status)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/task/status/" + status + ".json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetActiveUsersByDepartment(int departmentID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/user.json", APIToken, Enums.HttpVerb.GET, "");
                response = (String)restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
        public string GetAvailableFollowersByDepartment(int departmentID)
        {
            string response = "";
            try
            {
                RestServiceClient restServiceClient = new RestServiceClient(API_URL + "department/" + departmentID + "/follower/available.json", APIToken, Enums.HttpVerb.GET, "");
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
