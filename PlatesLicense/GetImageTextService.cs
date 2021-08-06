using System;
using Newtonsoft.Json;
using RestSharp;

namespace PlateLicense
{
    class GetImageTextService
    {
        private static string URL = "https://api.ocr.space/parse/image";
        public static string getText(string filepath)
        {
            Console.WriteLine(filepath);
            var client = new RestClient(URL);
            var request = new RestRequest(Method.POST);
            request.AddParameter("language", "eng");
            request.AddFile("file", filepath);
            request.AddParameter("isCreateSearchablePdf", "true");
            request.AddParameter("isSearchablePdfHideTextLayer", "true");
            request.AddParameter("apikey", "helloworld");
            IRestResponse response = client.Execute(request);
            dynamic result = JsonConvert.DeserializeObject(response.Content);
            return result["ParsedResults"][0]["TextOverlay"]["Lines"]["LineText"];
        }
    }
}
