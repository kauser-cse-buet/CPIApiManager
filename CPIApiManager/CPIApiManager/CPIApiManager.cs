using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;

namespace CPIApiManager
{
    class CPIApiManager
    {
        public string CpiApiUrl { get; set; }
        public string SeriesID { get; set; }

        public CPIApiManager()
        {
            CpiApiUrl = Properties.Settings.Default.CpiApiUrl;
            SeriesID = Properties.Settings.Default.SeriesID;
        }

        public string CreateRequest()
        {
            string UrlRequest = CpiApiUrl + SeriesID;
            return (UrlRequest); 
        }


        public Response MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Response jsonResponse
                    = objResponse as Response;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
