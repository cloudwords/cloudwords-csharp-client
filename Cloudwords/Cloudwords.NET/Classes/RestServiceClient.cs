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
   
        public RestServiceClient(string endpoint,string apiToken, HttpVerb method, string postData)
        {
          EndPoint = endpoint;
          Method = method;
          ContentType = "application/json";
          PostData = postData;
          APIToken = apiToken;
        }
        public string ProcessRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint );
            string responseValue = string.Empty;
            request.Method = Method.ToString();
            request.Accept = ContentType;
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add("Authorization", "UserToken "+APIToken);
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            try
            {

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
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

    }
}
