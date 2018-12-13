using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Badgr.Utilities
{
    public static class HtmlUtilities
    {
        /// <summary>
        /// This method will call a json endpoint and deserialize an object that the endpoint returns
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static T GetResults<T>(string url, string token = "", string method = "GET")
        {
            T results;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if (!string.IsNullOrEmpty(token))
                request.Headers.Add("Authorization", token);

            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var bodyData = reader.ReadToEnd();
                results = JsonConvert.DeserializeObject<T>(bodyData);
            }
            response.Close();

            return results;            
        }
        /// <summary>
        /// This method will call a json endpoint serialize an object send it to an object and then deserialize an object that the endpoint returns
        /// First generic is what your sending and the second generic is what you are receiving
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TT"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static TT GetResults<T,TT>(string url, T data, string token = "", string method = "POST")
        {
            TT results;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if (!string.IsNullOrEmpty(token))
                request.Headers.Add("Authorization", token);

            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(data);
                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var bodyData = reader.ReadToEnd();
                results = JsonConvert.DeserializeObject<TT>(bodyData);
            }
            response.Close();

            return results;
        }
    }
}
