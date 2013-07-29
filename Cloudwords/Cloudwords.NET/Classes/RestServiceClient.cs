using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloudwords.NET.Enums;
using System.Net;
using System.IO;

namespace Cloudwords.NET.Classes
{
    public class RestServiceClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public string APIToken { get; set; }
        public bool IsFileDownload { get; set; }
        public bool IsFileUpload { get; set; }
        public string FileFullName { get; set; }

        private static readonly Encoding encoding = Encoding.UTF8;
        public RestServiceClient(string endpoint,string apiToken, HttpVerb method, string postData)
        {
          EndPoint = endpoint;
          Method = method;
          ContentType = "application/json";
          PostData = postData;
          APIToken = apiToken;
        }
        public object ProcessRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint );
            string responseValue = string.Empty;
            request.Method = Method.ToString();
            request.Accept = ContentType;
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add("Authorization", "UserToken "+APIToken);
            
            if (!string.IsNullOrEmpty(PostData) && (Method == HttpVerb.POST ||Method == HttpVerb.PUT))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            else if (string.IsNullOrEmpty(PostData) && (Method == HttpVerb.PUT || Method == HttpVerb.POST) && IsFileUpload == true)
            {
               // string file = FileName;
                FileStream fs = new FileStream(FileFullName, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();

                FileInfo fInfo = new FileInfo(FileFullName);
                
                // Generate post objects
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("filename", fInfo.Name);
                postParameters.Add("fileformat", fInfo.Extension);
                postParameters.Add("file", new FileParameter(data, fInfo.Name, MIMEAssistant.GetMimeType(fInfo.Extension)));

                string userAgent = "Someone";

                string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
                string contentType = "multipart/form-data; boundary=" + formDataBoundary;

                byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

                if (Method == HttpVerb.PUT)
                    request.Method = "PUT";
                else
                    request.Method = "POST";
                request.ContentType = contentType;
                request.UserAgent = userAgent;
                request.CookieContainer = new CookieContainer();
                request.ContentLength = formData.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }
            }
            try
            {

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (!IsFileDownload)
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (var reader = new StreamReader(responseStream))
                                {
                                    responseValue = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    else
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            return response;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                responseValue= ex.Message;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (Stream responseStream = ex.Response.GetResponseStream())
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                       responseValue =responseReader.ReadToEnd();
                    }
                }
              
            }
          return responseValue;
        }
        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }
        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}
