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
           Console.WriteLine(UploadReferenceMaterial_Test());

           // Test Update Reference Material function
           // Console.WriteLine(UpdateReferenceMaterial_Test());

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
        
        
    }
}
