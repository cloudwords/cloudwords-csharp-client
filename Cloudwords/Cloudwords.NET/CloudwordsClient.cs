using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET.Classes;
using Newtonsoft.Json;
using System.Xml;

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
        public string CreateProject(string name, string description, string sourceLanguageCode, List<string> targetLanguagesCode,
                                    string bidDueDate, string deliveryDueDate, string reviewDueDate, string notes, int intendedUse,
                                    int? department, int? owner, string poNumber, List<int> followers)
        {
            string response="";
            try
            {
                string validationError = Validate.CreateProjectInput(name, description, sourceLanguageCode, targetLanguagesCode, bidDueDate, deliveryDueDate, reviewDueDate,
                                            notes,intendedUse,department,owner, poNumber);

                if (validationError == "")
                {
                    Project project = new Project();
                    project.name = name;
                    project.description = description;
                    project.sourceLanguage = new SourceLanguage() {  languageCode = sourceLanguageCode };

                    List<TargetLanguage> targetLanguagesList = new List<TargetLanguage>();

                    foreach (string langcode in targetLanguagesCode)
                    {
                        if (!string.IsNullOrEmpty(langcode))
                        {
                            targetLanguagesList.Add(new TargetLanguage() {  languageCode = langcode });
                        }
                    }
                    project.targetLanguages = targetLanguagesList;
                    project.bidDueDate = bidDueDate;
                    project.deliveryDueDate = deliveryDueDate;
                    project.reviewDueDate = reviewDueDate;
                    project.notes = notes;
                    project.intendedUse = new IntendedUse() { id = intendedUse };


                    if (department.HasValue)
                    {
                        project.department = new Department() { id = owner.Value };
                    }
                    if (owner.HasValue)
                    {
                        project.owner = new Owner() { id = owner.Value};
                    }

                    project.poNumber = poNumber;

                    if (followers != null)
                    {
                        List<Follower> followerList = new List<Follower>();
                        foreach (int fID in followers)
                        {
                            Follower follower = new Follower();
                            follower.id = fID;
                            followerList.Add(follower);
                        }
                        if (followerList.Count>0)
                            project.followers = followerList;
                    }
                    

                    string jsonData = JsonConvert.SerializeObject(project);
                    RestServiceClient restServiceClient = new RestServiceClient(API_URL + "project", APIToken, Enums.HttpVerb.POST, jsonData);
                    response = restServiceClient.ProcessRequest();
                }
                else
                {
                    response = validationError;
                }

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
                response = restServiceClient.ProcessRequest();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

    
    }
}
