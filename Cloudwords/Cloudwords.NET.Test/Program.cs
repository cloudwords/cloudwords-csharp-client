using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET;
using Cloudwords.NET.Classes;
using System.Net;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Converters;
namespace Cloudwords.NET.Test
{
    class Program
    {
        
        /// <summary>
        /// Set you API URL here Including the version number for example https://api.cloudwords.com/1/
        /// </summary>
        private static string API_URL = "";

        /// <summary>
        /// Set your API Key here
        /// </summary>
        private static string TOKEN="";
       
        static CloudwordsCustomerClient customerClient;
        static CloudwordsVendorClient vendorClient;
        static void Main(string[] args)
        {
            //customerClient = new CloudwordsCustomerClient(API, Token);
            vendorClient = new CloudwordsVendorClient(API_URL, TOKEN);
             
           // Test Create Project function
           // Console.WriteLine(Customer_CreateProject_Test());

           // Test Get Project function
           //Console.WriteLine(Customer_GetProject_Test());

           // Test Get Open Projects function
           //Console.WriteLine(Customer_GetOpenProjects_Test());

           // Test Get Closed Projects function
           // Console.WriteLine(Customer_GetClosedProjects_Test());

           // Test Update Project function
           // Console.WriteLine(Customer_UpdateProject_Test());

           // Test Get Source Material function
           // Console.WriteLine(Customer_GetSourceMaterial_Test());

           // Test Download Source Material function
           //Console.WriteLine(Customer_DownloadSourceMaterial_Test());

           // Test Upload Source Material function
           // Console.WriteLine(Customer_UploadSourceMaterial_Test());

           // Test Get All Reference Materials function
           // Console.WriteLine(Customer_GetAllReferenceMaterials_Test());

           // Test Get A Reference Material function
           // Console.WriteLine(Customer_GetAReferenceMaterial_Test());

           // Test Download Reference Material function
           // Console.WriteLine(Customer_DownloadReferenceMaterial_Test());

           // Test Upload Reference Material function
           // Console.WriteLine(Customer_UploadReferenceMaterial_Test());

           // Test Update Reference Material function
           // Console.WriteLine(Customer_UpdateReferenceMaterial_Test());

           // Test Create Bid Request function
           // Console.WriteLine(Customer_CreateBidRequest_Test());
            
           // Test Get Bid Request function
           // Console.WriteLine(Customer_GetBidRequest_Test());

           // Test Select A Winning Bid function
           // Console.WriteLine(Customer_SelectAWinningBid_Test());

           // Test Get All Bids function
           // Console.WriteLine(Customer_GetAllBids_Test());

           // Test Get Bid function
           // Console.WriteLine(Customer_GetBid_Test());

           // Test Get the Bundled Translated Materials function
           // Console.WriteLine(Customer_GetBundledTranslatedMaterials_Test());
           
           // Test Download Bundled Translated Materials function
           // Console.WriteLine(Customer_DownloadBundledTranslatedMaterials_Test());
          
           // Test Get All Translated Materials by language function
           // Console.WriteLine(Customer_GetAllTranslatedMaterialsByLanguage_Test());
            
           // Test Get A Translated Material by language function
           // Console.WriteLine(Customer_GetATranslatedMaterialByLanguage_Test());

           // Test Download Translated Material by Language function
           // Console.WriteLine(Customer_DownloadTranslatedMaterialByLanguage_Test());

           // Test Approve a Translated Material function
           // Console.WriteLine(Customer_ApproveTranslatedMaterial_Test());

           // Test Get Project Tasks function
           // Console.WriteLine(Customer_GetProjectTasks_Test());

           // Test Get Project Tasks with Status function
           //Console.WriteLine(Customer_GetProjectTasksWithStatus_Test());

           // Test Get Project Task function
           // Console.WriteLine(Customer_GetProjectTask_Test());

           // Test Get All Project Tasks function
           // Console.WriteLine(Customer_GetAllProjectTasks_Test());

           // Test Get All Project Tasks With Status function
           // Console.WriteLine(Customer_GetAllProjectTasksWithStatus_Test());

           // Test Create Project Task function
           // Console.WriteLine(Customer_CreateProjectTask_Test());

           // Test Update Project Task function
           // Console.WriteLine(Customer_UpdateProjectTask_Test());
           
           // Test Upload Task Attachment function
           // Console.WriteLine(Customer_UploadTaskAttachment_Test());

           // Test Get Task Attachment function
           // Console.WriteLine(Customer_GetTaskAttachment_Test());

           // Test Get Preferred Vendors function
           // Console.WriteLine(Customer_GetPreferredVendors_Test());
           
           // Test Get A Vendor function
           // Console.WriteLine(Customer_GetVendor_Test());

           // Test Get Source Languages function
           // Console.WriteLine(Customer_GetSourceLanguages_Test());
            
           // Test Get Target Languages function
           // Console.WriteLine(Customer_GetTargetLanguages_Test());

           // Test Get Departments function
           // Console.WriteLine(Customer_GetDepartments_Test());

           // Test Create Department function
           // Console.WriteLine(Customer_CreateDepartment_Test());
            
           // Test current user function
           // Console.WriteLine(Customer_GetCurrentUser_Test());
           
           // Test Active users function
           // Console.WriteLine(Customer_GetActiveUsers_Test());

           // Test Get Available Followers function
           // Console.WriteLine(Customer_GetAvailableFollowers_Test());

           // TestGet Open Projects by department function
           // Console.WriteLine(Customer_GetOpenProjectsByDepartment_Test());

           // TestGet Closed Projects by department function
           // Console.WriteLine(Customer_GetClosedProjectsByDepartment_Test());
        
           // TestGet All Projects Tasks by department function
           // Console.WriteLine(Customer_GetAllProjectTasksByDepartment_Test());
           
           // TestGet All Projects Tasks by status by department function
           // Console.WriteLine(Customer_GetAllProjectTasksWithStatusByDepartment_Test());
           
           // TestGet Active users by department function
           // Console.WriteLine(Customer_GetActiveUsersByDepartment_Test());
           
           // TestGet Available Followers by department function
           //Console.WriteLine(Customer_GetAvailableFollowersByDepartment_Test());
            
           // Test Vendor Get Open Projects function
           // Console.WriteLine(Vendor_GetOpenProjects_Test());
            
           // Test Vendor Get Closed Projects function
           // Console.WriteLine(Vendor_GetClosedProjects_Test());
            
           // Test Vendor Get Project function
           //  Console.WriteLine(Vendor_GetProject_Test());
           
           // Test Vendor Get Source Material function
           //  Console.WriteLine(Vendor_GetSourceMaterial_Test());
            
           // Test Vendor Download Source Material function
           //   Console.WriteLine(Vendor_DownloadSourceMaterial_Test());

           // Test Vendor Get All Reference Materials function
           // Console.WriteLine(Vendor_GetAllReferenceMaterials_Test());
            
            // Test Vendor Get A Reference Material function
            //Console.WriteLine(Vendor_GetAReferenceMaterial_Test());

            // Test Vendor Download Reference Material function
            //Console.WriteLine(Vendor_DownloadReferenceMaterial_Test());

            // Test Vendor Get Bid function
            // Console.WriteLine(Vendor_GetBid_Test());

            // Test Vendor Accept/Reject Bid function
            //Console.WriteLine(Vendor_AcceptRejectBid_Test());
            
            // Test Vendor Submit Bid function
            //Console.WriteLine(Vendor_SubmitBid_Test());
            
            // Test Vendor Upload Language Deliverable function
            //Console.WriteLine(Vendor_UploadLanguageDeliverable_Test());
            
            // Test Vendor Get the Bundled Translated Materials function
            // Console.WriteLine(Vendor_GetBundledTranslatedMaterials_Test());

            // Test Vendor Download the Bundled Translated Materials function
            // Console.WriteLine(Vendor_DownloadBundledTranslatedMaterials_Test());

            // Test Vendor Get All Translated Materials by Language function
            // Console.WriteLine(Vendor_GetAllTranslatedMaterialsByLanguage_Test());

            // Test Vendor Get a Translated Material by Language function
            // Console.WriteLine(Vendor_GetATranslatedMaterialByLanguage_Test());

            // Test Vendor Download Translated Material by Language function
            // Console.WriteLine(Vendor_DownloadTranslatedMaterialByLanguage_Test());

            // Test Vendor Upload Translation Memory function
            // Console.WriteLine(Vendor_UploadTranslationMemory_Test());

            // Test Vendor Get TM Metadata function
            // Console.WriteLine(Vendor_GetTMMetadata_Test());

            // Test Vendor Download TM function
            // Console.WriteLine(Vendor_DownloadTM_Test());

            // Test Vendor Get Project Tasks function
            // Console.WriteLine(Vendor_GetProjectTasks_Test());

            // Test Vendor Get Project Tasks with Status function
           //  Console.WriteLine(Vendor_GetProjectTasksWithStatus_Test());

            // Test Vendor Get Project Task function
            // Console.WriteLine(Vendor_GetProjectTask_Test());

            // Test Vendor Get All Project Tasks function
            // Console.WriteLine(Vendor_GetAllProjectTasks_Test());

            // Test Vendor Get All Project Tasks With Status function
            // Console.WriteLine(Vendor_GetAllProjectTasksWithStatus_Test());

            // Test Vendor Update Project Task function
            // Console.WriteLine(Vendor_UpdateProjectTask_Test());

            // Test Vendor Get Task Attachment function
            // Console.WriteLine(Vendor_GetTaskAttachment_Test());
           
            Console.ReadLine();

        }
        private static string Customer_CreateProject_Test()
        {
            Project project = new Project();
            project.name = "test project 11";
            project.description = "This is a test project 11";
            project.sourceLanguage = new SourceLanguage("en-us");

            List<TargetLanguage> targetLanguagesList = new List<TargetLanguage>();
            targetLanguagesList.Add(new TargetLanguage("fr"));
            project.targetLanguages = targetLanguagesList;
            project.bidDueDate = DateTime.Now.AddDays(3);
            project.deliveryDueDate = DateTime.Now.AddDays(6);
            project.reviewDueDate = DateTime.Now.AddDays(7);
            project.notes = "testing notes";
            project.intendedUse = new IntendedUse(1143) ;
            project.department = new Department();
            project.owner = new Owner();
            project.poNumber = "12345";
            List<Follower> followerList = new List<Follower>();
            followerList.Add(new Follower(845));
            project.followers = followerList;

            return customerClient.CreateProject(project);

        }
        private static string Customer_GetProject_Test()
        {
            return customerClient.GetProject(10149);
        }
        private static string Customer_GetOpenProjects_Test()
        {
            return customerClient.GetOpenProjects();
        }
        private static string Customer_GetClosedProjects_Test()
        {
            return customerClient.GetClosedProjects();
        }
        private static string Customer_UpdateProject_Test()
        {
            Project project = new Project();
            project.name = "test project 10189";
            project.description = "";
            project.sourceLanguage = new SourceLanguage("en-gb");

            List<TargetLanguage> targetLanguagesList = new List<TargetLanguage>();
            targetLanguagesList.Add(new TargetLanguage("de"));
            project.targetLanguages = targetLanguagesList;
            return customerClient.UpdateProject(10189,project);

        }
        private static string Customer_GetSourceMaterial_Test()
        {
            return customerClient.GetSourceMaterial(10149);
        }
        private static HttpWebResponse Customer_DownloadSourceMaterial_Test()
        {
            //byte[] result;
            //byte[] buffer = new byte[4096];
            //string fileName = "";
            //if (response.Headers["Content-Disposition"] != null)
            //{
            //    fileName = response.Headers["Content-Disposition"].Replace("attachment;filename*=UTF-8''", "").Replace("\"", "");

            //}
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    int count = 0;
            //    do
            //    {
            //        count = responseStream.Read(buffer, 0, buffer.Length);
            //        memoryStream.Write(buffer, 0, count);

            //    } while (count != 0);

            //    result = memoryStream.ToArray();

            //}
            return customerClient.DownloadSourceMaterial(10149);
        }
        private static string Customer_UploadSourceMaterial_Test()
        {
            return (String)customerClient.UploadSourceMaterial(10189, @"C:\test.xls_(1).zip");
        }
        private static string Customer_GetAllReferenceMaterials_Test()
        {
            return customerClient.GetAllReferenceMaterials(10159);
        }
        private static string Customer_GetAReferenceMaterial_Test()
        {
            return customerClient.GetAReferenceMaterial(10159,13011);
        }
        private static HttpWebResponse Customer_DownloadReferenceMaterial_Test()
        {
             return customerClient.DownloadReferenceMaterial(10149,1);
        }
        private static string Customer_UploadReferenceMaterial_Test()
        {
            return (String)customerClient.UploadReferenceMaterial(10159, @"C:\test.xls_2.zip");
        }
        private static string Customer_UpdateReferenceMaterial_Test()
        {
            return (String)customerClient.UpdateReferenceMaterial(10159, 13011, @"C:\test.xls_2_updated.zip");
        }
        private static string Customer_CreateBidRequest_Test()
        {
            BidRequest bidRequest = new BidRequest();
            bidRequest.doLetCloudwordsChoose=false;
            List<PreferredVendor> preferredVendorList= new List<PreferredVendor>();
            preferredVendorList.Add(new PreferredVendor(3319));
            bidRequest.preferredVendors = preferredVendorList;
            bidRequest.doAutoSelectBidFromVendor=false;
            return customerClient.CreateBidRequest(10149,bidRequest);
        }
        private static string Customer_GetBidRequest_Test()
        {
            return customerClient.GetBidRequest(10149);
        }
        private static string Customer_SelectAWinningBid_Test()
        {
            return customerClient.SelectAWinningBid(10159,7797);
        }
        private static string Customer_GetAllBids_Test()
        {
            return customerClient.GetAllBids(10159);
        }
        private static string Customer_GetBid_Test()
        {
            return customerClient.GetBid(10149, 7793);
        }
        private static string Customer_GetBundledTranslatedMaterials_Test()
        {
            return customerClient.GetBundledTranslatedMaterials(10159);
        }
        private static HttpWebResponse Customer_DownloadBundledTranslatedMaterials_Test()
        {
            return customerClient.DownloadBundledTranslatedMaterials(10159);
        }
        private static string Customer_GetAllTranslatedMaterialsByLanguage_Test()
        {
            return customerClient.GetAllTranslatedMaterialsByLanguage(10159);
        }
        private static string Customer_GetATranslatedMaterialByLanguage_Test()
        {
            return customerClient.GetATranslatedMaterialByLanguage(10159,"fr");
        }
        private static HttpWebResponse Customer_DownloadTranslatedMaterialByLanguage_Test()
        {
            return customerClient.DownloadTranslatedMaterialByLanguage(10159,"fr");
        }
        private static string Customer_ApproveTranslatedMaterial_Test()
        {
            return customerClient.ApproveTranslatedMaterial(10159, "fr");
        }
        private static string Customer_GetProjectTasks_Test()
        {
            return customerClient.GetProjectTasks(10159);
        }
        private static string Customer_GetProjectTasksWithStatus_Test()
        {
            return customerClient.GetProjectTasksWithStatus(10159,"closed");
        }
        private static string Customer_GetProjectTask_Test()
        {
            return customerClient.GetProjectTask(10159, 29427);
        }
        private static string Customer_GetAllProjectTasks_Test()
        {
            return customerClient.GetAllProjectTasks();
        }
        private static string Customer_GetAllProjectTasksWithStatus_Test()
        {
            return customerClient.GetAllProjectTasksWithStatus("closed");
        }
        private static string Customer_CreateProjectTask_Test()
        {
            ProjectTask projectTask= new ProjectTask();
            projectTask.name="test Task";
            projectTask.type="custom";
            projectTask.assignee= new Assignee(new CustomerUser(845));
            projectTask.dueDate = null;
            projectTask.startDate = null;
            //projectTask.description="test task description";
            return customerClient.CreateProjectTask(10159, projectTask);
        }
        private static string Customer_UpdateProjectTask_Test()
        {
            ProjectTask projectTask= new ProjectTask();
            projectTask.name="test Task";
            projectTask.type="custom";
            projectTask.assignee= new Assignee(new CustomerUser(845));
            projectTask.dueDate = null;
            projectTask.startDate = null;
            //projectTask.description="test task description";
            return customerClient.UpdateProjectTask(10159,1, projectTask);
        }
        private static string Customer_UploadTaskAttachment_Test()
        {
            return (String)customerClient.UploadTaskAttachment(10159, 1,@"C:\test.xls_2.zip");
        }
        private static string Customer_GetTaskAttachment_Test()
        {
            return (String)customerClient.GetTaskAttachment(10159, 1);
        }
        private static string Customer_GetPreferredVendors_Test()
        {
            return (String)customerClient.GetPreferredVendors();
        }
        private static string Customer_GetVendor_Test()
        {
            return (String)customerClient.GetAVendor(3319);
        }
        private static string Customer_GetSourceLanguages_Test()
        {
            return (String)customerClient.GetSourceLanguages();
        }
        private static string Customer_GetTargetLanguages_Test()
        {
            return (String)customerClient.GetTargetLanguages();
        }
        private static string Customer_GetDepartments_Test()
        {
            return (String)customerClient.GetDepartments();
        }
        private static string Customer_CreateDepartment_Test()
        {
            return (String)customerClient.CreateDepartment("sk_test");
        }
        private static string Customer_GetCurrentUser_Test()
        {
            return (String)customerClient.GetCurrentUser();
        }
        private static string Customer_GetActiveUsers_Test()
        {
            return (String)customerClient.GetActiveUsers();
        }
        private static string Customer_GetAvailableFollowers_Test()
        {
            return (String)customerClient.GetAvailableFollowers();
        }
        private static string Customer_GetOpenProjectsByDepartment_Test()
        {
            return (String)customerClient.GetOpenProjectsByDepartment(335);
        }
        private static string Customer_GetClosedProjectsByDepartment_Test()
        {
            return (String)customerClient.GetClosedProjectsByDepartment(335);
        }
        private static string Customer_GetAllProjectTasksByDepartment_Test()
        {
            return (String)customerClient.GetAllProjectTasksByDepartment(335);
        }
        private static string Customer_GetAllProjectTasksWithStatusByDepartment_Test()
        {
            return (String)customerClient.GetAllProjectTasksWithStatusByDepartment(335,"opened");
        }
        private static string Customer_GetActiveUsersByDepartment_Test()
        {
            return (String)customerClient.GetActiveUsersByDepartment(335);
        }
        private static string Customer_GetAvailableFollowersByDepartment_Test()
        {
            return (String)customerClient.GetAvailableFollowersByDepartment(325);
        }

        private static string Vendor_GetOpenProjects_Test()
        {
            return vendorClient.GetOpenProjects();
        }
        private static string Vendor_GetClosedProjects_Test()
        {
            return vendorClient.GetClosedProjects();
        }
        private static string Vendor_GetProject_Test()
        {
            return vendorClient.GetProject(117);
        }
        private static string Vendor_GetSourceMaterial_Test()
        {
            return vendorClient.GetSourceMaterial(117);
        }
        private static HttpWebResponse Vendor_DownloadSourceMaterial_Test()
        {
            return vendorClient.DownloadSourceMaterial(117);
        }
        private static string Vendor_GetAllReferenceMaterials_Test()
        {
            return vendorClient.GetAllReferenceMaterials(117);
        }
        private static string Vendor_GetAReferenceMaterial_Test()
        {
            return vendorClient.GetAReferenceMaterial(117, 443);
        }
        private static HttpWebResponse Vendor_DownloadReferenceMaterial_Test()
        {
            return vendorClient.DownloadReferenceMaterial(117, 443);
        }
        private static string Vendor_GetBid_Test()
        {
            return vendorClient.GetBid(117);
        }
        private static string Vendor_AcceptRejectBid_Test()
        {
            return vendorClient.AcceptRejectBid(131, "vendor_accepted");
        }
        private static string Vendor_SubmitBid_Test()
        {
            string strBid=vendorClient.GetBid(117);
            Bid bid = JsonConvert.DeserializeObject<Bid>(strBid);
            foreach (var bidItem in bid.bidItems)
            {
                foreach (var bidItemTask in bidItem.bidItemTasks)
                {
                    if (bidItemTask.projectTaskType.parentType == "translation")
                    {
                        bidItemTask.attributes = new Attributes();
                        bidItemTask.attributes.numWords = 2;
                    }
                    else
                    {
                        bidItemTask.attributes = null;
                    }
                    bidItemTask.cost = 1;
                }
            }

            return vendorClient.SubmitBid(117, bid);
        }

        private static string Vendor_UploadLanguageDeliverable_Test()
        {
            return vendorClient.UploadLanguageDeliverable(117, "fr", @"C:\test.xls_2_updated.zip");
        }
        private static string Vendor_GetBundledTranslatedMaterials_Test()
        {
            return vendorClient.GetBundledTranslatedMaterials(117);
        }
        private static HttpWebResponse Vendor_DownloadBundledTranslatedMaterials_Test()
        {
            return vendorClient.DownloadBundledTranslatedMaterials(117);
        }
        private static string Vendor_GetAllTranslatedMaterialsByLanguage_Test()
        {
            return vendorClient.GetAllTranslatedMaterialsByLanguage(117);
        }
        private static string Vendor_GetATranslatedMaterialByLanguage_Test()
        {
            return vendorClient.GetATranslatedMaterialByLanguage(117, "fr");
        }
        private static HttpWebResponse Vendor_DownloadTranslatedMaterialByLanguage_Test()
        {
            return vendorClient.DownloadTranslatedMaterialByLanguage(117, "fr");
        }
        private static string Vendor_UploadTranslationMemory_Test()
        {
            return vendorClient.UploadTranslationMemory(117, @"C:\test3.tmx");
        }
        private static string Vendor_GetTMMetadata_Test()
        {
            return vendorClient.GetTMMetadata(117);
        }
        private static HttpWebResponse Vendor_DownloadTM_Test()
        {
            return vendorClient.DownloadTM(117);
        }
        private static string Vendor_GetProjectTasks_Test()
        {
            return vendorClient.GetProjectTasks(117);
        }
        private static string Vendor_GetProjectTasksWithStatus_Test()
        {
            return vendorClient.GetProjectTasksWithStatus(133, "open");
        }
        private static string Vendor_GetProjectTask_Test()
        {
            return vendorClient.GetProjectTask(117, 1071);
        }
        private static string Vendor_GetAllProjectTasks_Test()
        {
            return vendorClient.GetAllProjectTasks();
        }
        private static string Vendor_GetAllProjectTasksWithStatus_Test()
        {
            return vendorClient.GetAllProjectTasksWithStatus("closed");
        }
        private static string Vendor_UpdateProjectTask_Test()
        {
            ProjectTask projectTask = new ProjectTask();
            projectTask.name = "test Task";
            projectTask.type = "custom";
            projectTask.assignee = null;
            projectTask.dueDate = null;
            projectTask.startDate = null;
            projectTask.description="test task description";
            return customerClient.UpdateProjectTask(117, 1111, projectTask);
        }
        private static string Vendor_GetTaskAttachment_Test()
        {
            return vendorClient.GetTaskAttachment(133, 1111);
        }
    }
}
