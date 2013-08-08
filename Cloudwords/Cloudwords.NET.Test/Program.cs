using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET;
using Cloudwords.NET.Classes;
using System.Net;
namespace Cloudwords.NET.Test
{
    class Program
    {
        static CloudwordsClient client;
        static void Main(string[] args)
        {
           client = new CloudwordsClient(true, "bb8568eb355aa091fb5bee0fcad5e902afd5f268217919488c269fbd3de73455");

            // Test Create Project function
           //Console.WriteLine(CreateProject_Test());

           // Test Get Project function
           //Console.WriteLine(GetProject_Test());

           // Test Get Open Projects function
           //Console.WriteLine(GetOpenProjects_Test());

           // Test Get Closed Projects function
           // Console.WriteLine(GetClosedProjects_Test());

           // Test Update Project function
           // Console.WriteLine(UpdateProject_Test());

           // Test Get Source Material function
           // Console.WriteLine(GetSourceMaterial_Test());

           // Test Download Source Material function
           //Console.WriteLine(DownloadSourceMaterial_Test());

           // Test Upload Source Material function
           // Console.WriteLine(UploadSourceMaterial_Test());

           // Test Get All Reference Materials function
           // Console.WriteLine(GetAllReferenceMaterials_Test());

           // Test Get A Reference Material function
           // Console.WriteLine(GetAReferenceMaterial_Test());

           // Test Download Reference Material function
           // Console.WriteLine(DownloadReferenceMaterial_Test());

           // Test Upload Reference Material function
           // Console.WriteLine(UploadReferenceMaterial_Test());

           // Test Update Reference Material function
           // Console.WriteLine(UpdateReferenceMaterial_Test());

           // Test Create Bid Request function
           // Console.WriteLine(CreateBidRequest_Test());
            
           // Test Get Bid Request function
           // Console.WriteLine(GetBidRequest_Test());

           // Test Select A Winning Bid function
           // Console.WriteLine(SelectAWinningBid_Test());

           // Test Get All Bids function
           // Console.WriteLine(GetAllBids_Test());

           // Test Get Bid function
           // Console.WriteLine(GetBid_Test());

           // Test Get the Bundled Translated Materials function
           // Console.WriteLine(GetBundledTranslatedMaterials_Test());
           
           // Test Download Bundled Translated Materials function
           // Console.WriteLine(DownloadBundledTranslatedMaterials_Test());
          
           // Test Get All Translated Materials by language function
           // Console.WriteLine(GetAllTranslatedMaterialsByLanguage_Test());
            
           // Test Get A Translated Material by language function
           // Console.WriteLine(GetATranslatedMaterialByLanguage_Test());

           // Test Download Translated Material by Language function
           // Console.WriteLine(DownloadTranslatedMaterialByLanguage_Test());

           // Test Approve a Translated Material function
           // Console.WriteLine(ApproveTranslatedMaterial_Test());

           // Test Get Project Tasks function
           // Console.WriteLine(GetProjectTasks_Test());

           // Test Get Project Tasks with Status function
           //Console.WriteLine(GetProjectTasksWithStatus_Test());

           // Test Get Project Task function
           // Console.WriteLine(GetProjectTask_Test());

           // Test Get All Project Tasks function
           // Console.WriteLine(GetAllProjectTasks_Test());

           // Test Get All Project Tasks With Status function
           // Console.WriteLine(GetAllProjectTasksWithStatus_Test());

           // Test Create Project Task function
           // Console.WriteLine(CreateProjectTask_Test());

           // Test Update Project Task function
           // Console.WriteLine(UpdateProjectTask_Test());
           
           // Test Upload Task Attachment function
           // Console.WriteLine(UploadTaskAttachment_Test());

           // Test Get Task Attachment function
           // Console.WriteLine(GetTaskAttachment_Test());

           // Test Get Preferred Vendors function
           // Console.WriteLine(GetPreferredVendors_Test());
           
           // Test Get A Vendor function
           // Console.WriteLine(GetVendor_Test());

           // Test Get Source Languages function
           // Console.WriteLine(GetSourceLanguages_Test());
            
           // Test Get Target Languages function
           // Console.WriteLine(GetTargetLanguages_Test());

           // Test Get Departments function
           // Console.WriteLine(GetDepartments_Test());

           // Test Create Department function
           // Console.WriteLine(CreateDepartment_Test());
            
           // Test current user function
           // Console.WriteLine(GetCurrentUser_Test());
           
           // Test Active users function
           // Console.WriteLine(GetActiveUsers_Test());

           // Test Get Available Followers function
           // Console.WriteLine(GetAvailableFollowers_Test());

           // TestGet Open Projects by department function
           // Console.WriteLine(GetOpenProjectsByDepartment_Test());

           // TestGet Closed Projects by department function
           // Console.WriteLine(GetClosedProjectsByDepartment_Test());
        
           // TestGet All Projects Tasks by department function
           // Console.WriteLine(GetAllProjectTasksByDepartment_Test());
           
           // TestGet All Projects Tasks by status by department function
           // Console.WriteLine(GetAllProjectTasksWithStatusByDepartment_Test());
           
           // TestGet Active users by department function
           // Console.WriteLine(GetActiveUsersByDepartment_Test());
           
           // TestGet Available Followers by department function
           Console.WriteLine(GetAvailableFollowersByDepartment_Test());
            
           Console.ReadLine();

        }
        private static string CreateProject_Test()
        {
            Project project = new Project();
            project.name = "test project 10";
            project.description = "This is a test project 10";
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

            return client.CreateProject(project);

        }
        private static string GetProject_Test()
        {
            return client.GetProject(10149);
        }
        private static string GetOpenProjects_Test()
        {
            return client.GetOpenProjects();
        }
        private static string GetClosedProjects_Test()
        {
            return client.GetClosedProjects();
        }
        private static string UpdateProject_Test()
        {
            Project project = new Project();
            project.name = "test project 10189";
            project.description = "";
            project.sourceLanguage = new SourceLanguage("en-gb");

            List<TargetLanguage> targetLanguagesList = new List<TargetLanguage>();
            targetLanguagesList.Add(new TargetLanguage("de"));
            project.targetLanguages = targetLanguagesList;
            return client.UpdateProject(10189,project);

        }
        private static string GetSourceMaterial_Test()
        {
            return client.GetSourceMaterial(10149);
        }
        private static HttpWebResponse DownloadSourceMaterial_Test()
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
            return client.DownloadSourceMaterial(10149);
        }
        private static string UploadSourceMaterial_Test()
        {
            return (String)client.UploadSourceMaterial(10189, @"C:\test.xls_(1).zip");
        }
        private static string GetAllReferenceMaterials_Test()
        {
            return client.GetAllReferenceMaterials(10159);
        }
        private static string GetAReferenceMaterial_Test()
        {
            return client.GetAReferenceMaterial(10159,13011);
        }
        private static HttpWebResponse DownloadReferenceMaterial_Test()
        {
             return client.DownloadReferenceMaterial(10149,1);
        }
        private static string UploadReferenceMaterial_Test()
        {
            return (String)client.UploadReferenceMaterial(10159, @"C:\test.xls_2.zip");
        }
        private static string UpdateReferenceMaterial_Test()
        {
            return (String)client.UpdateReferenceMaterial(10159, 13011, @"C:\test.xls_2_updated.zip");
        }
        private static string CreateBidRequest_Test()
        {
            BidRequest bidRequest = new BidRequest();
            bidRequest.doLetCloudwordsChoose=false;
            List<PreferredVendor> preferredVendorList= new List<PreferredVendor>();
            preferredVendorList.Add(new PreferredVendor(3319));
            bidRequest.preferredVendors = preferredVendorList;
            bidRequest.doAutoSelectBidFromVendor=false;
            return client.CreateBidRequest(10149,bidRequest);
        }
        private static string GetBidRequest_Test()
        {
            return client.GetBidRequest(10149);
        }
        private static string SelectAWinningBid_Test()
        {
            return client.SelectAWinningBid(10159,7797);
        }
        private static string GetAllBids_Test()
        {
            return client.GetAllBids(10159);
        }
        private static string GetBid_Test()
        {
            return client.GetBid(10149, 7793);
        }
        private static string GetBundledTranslatedMaterials_Test()
        {
            return client.GetBundledTranslatedMaterials(10159);
        }
        private static HttpWebResponse DownloadBundledTranslatedMaterials_Test()
        {
            return client.DownloadBundledTranslatedMaterials(10159);
        }
        private static string GetAllTranslatedMaterialsByLanguage_Test()
        {
            return client.GetAllTranslatedMaterialsByLanguage(10159);
        }
        private static string GetATranslatedMaterialByLanguage_Test()
        {
            return client.GetATranslatedMaterialByLanguage(10159,"fr");
        }
        private static HttpWebResponse DownloadTranslatedMaterialByLanguage_Test()
        {
            return client.DownloadTranslatedMaterialByLanguage(10159,"fr");
        }
        private static string ApproveTranslatedMaterial_Test()
        {
            return client.ApproveTranslatedMaterial(10159, "fr");
        }
        private static string GetProjectTasks_Test()
        {
            return client.GetProjectTasks(10159);
        }
        private static string GetProjectTasksWithStatus_Test()
        {
            return client.GetProjectTasksWithStatus(10159,"closed");
        }
        private static string GetProjectTask_Test()
        {
            return client.GetProjectTask(10159, 29427);
        }
        private static string GetAllProjectTasks_Test()
        {
            return client.GetAllProjectTasks();
        }
        private static string GetAllProjectTasksWithStatus_Test()
        {
            return client.GetAllProjectTasksWithStatus("closed");
        }
        private static string CreateProjectTask_Test()
        {
            ProjectTask projectTask= new ProjectTask();
            projectTask.name="test Task";
            projectTask.type="custom";
            projectTask.assignee= new Assignee(new CustomerUser(845));
            projectTask.dueDate = null;
            projectTask.startDate = null;
            //projectTask.description="test task description";
            return client.CreateProjectTask(10159, projectTask);
        }
        private static string UpdateProjectTask_Test()
        {
            ProjectTask projectTask= new ProjectTask();
            projectTask.name="test Task";
            projectTask.type="custom";
            projectTask.assignee= new Assignee(new CustomerUser(845));
            projectTask.dueDate = null;
            projectTask.startDate = null;
            //projectTask.description="test task description";
            return client.UpdateProjectTask(10159,1, projectTask);
        }
        private static string UploadTaskAttachment_Test()
        {
            return (String)client.UploadTaskAttachment(10159, 1,@"C:\test.xls_2.zip");
        }
        private static string GetTaskAttachment_Test()
        {
            return (String)client.GetTaskAttachment(10159, 1);
        }
        private static string GetPreferredVendors_Test()
        {
            return (String)client.GetPreferredVendors();
        }
        private static string GetVendor_Test()
        {
            return (String)client.GetAVendor(3319);
        }
        private static string GetSourceLanguages_Test()
        {
            return (String)client.GetSourceLanguages();
        }
        private static string GetTargetLanguages_Test()
        {
            return (String)client.GetTargetLanguages();
        }
        private static string GetDepartments_Test()
        {
            return (String)client.GetDepartments();
        }
        private static string CreateDepartment_Test()
        {
            return (String)client.CreateDepartment("sk_test");
        }
        private static string GetCurrentUser_Test()
        {
            return (String)client.GetCurrentUser();
        }
        private static string GetActiveUsers_Test()
        {
            return (String)client.GetActiveUsers();
        }
        private static string GetAvailableFollowers_Test()
        {
            return (String)client.GetAvailableFollowers();
        }
        private static string GetOpenProjectsByDepartment_Test()
        {
            return (String)client.GetOpenProjectsByDepartment(335);
        }
        private static string GetClosedProjectsByDepartment_Test()
        {
            return (String)client.GetClosedProjectsByDepartment(335);
        }
        private static string GetAllProjectTasksByDepartment_Test()
        {
            return (String)client.GetAllProjectTasksByDepartment(335);
        }
        private static string GetAllProjectTasksWithStatusByDepartment_Test()
        {
            return (String)client.GetAllProjectTasksWithStatusByDepartment(335,"opened");
        }
        private static string GetActiveUsersByDepartment_Test()
        {
            return (String)client.GetActiveUsersByDepartment(335);
        }
        private static string GetAvailableFollowersByDepartment_Test()
        {
            return (String)client.GetAvailableFollowersByDepartment(325);
        }
        
    }
}
