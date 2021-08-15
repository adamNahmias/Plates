using System;
using System.Configuration;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace PlateLicense
{
    public class ImageToTextService
    {
        private static ImageToTextService imageToTextService;
        private string API_URL = ConfigurationManager.AppSettings["API_URL"];
        private RestClient client;
        private string language;

        public static ImageToTextService GetInstance(string language)
        {
            if (imageToTextService == null || !language.Equals(imageToTextService.language))
            {
                imageToTextService = new ImageToTextService(language);
            }
            return imageToTextService;
        }
        private ImageToTextService(string language)
        {
            client = new RestClient(API_URL);
            this.language = language;
        }

        public string getImageText(string filepath, string apiKey= "helloworld")
        {
            double bestTextHigh = 0;
            string mostBoldedWord = "";
            //request params
            var request = new RestRequest(Method.POST);
            request.AddParameter("language", "eng");
            request.AddFile("file", filepath);
            request.AddParameter("isCreateSearchablePdf", "true");
            request.AddParameter("isSearchablePdfHideTextLayer", "true");
            request.AddParameter("apikey", apiKey);

            //Check if picture exist
            if (!File.Exists(filepath))
            {
                LoggerService.GetInstance().ERROR(string.Format("Image was not found,filepath: {0}",filepath));
                throw(new Exception(string.Format("Image was not found,filepath: {0}", filepath)));
            }

            try
            {              
                IRestResponse response = client.Execute(request);
                Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK), response.Content);
                dynamic result = JsonConvert.DeserializeObject(response.Content);
                //empty plate
                try
                {
                    if (result["ParsedResults"][0]["ParsedText"] =="")
                    {
                        return "";
                    }

                }
                catch
                {
                    LoggerService.GetInstance().WARNING("Not empty case,continue to parse plate number");
                }
                //Get the most bolded text
                foreach (dynamic data in result["ParsedResults"][0]["TextOverlay"]["Lines"])
                {
                    string wordHeight = data["Words"][0]["Height"];
                    if (double.Parse(wordHeight) > bestTextHigh)
                    {
                        bestTextHigh = double.Parse(wordHeight);
                        mostBoldedWord = data["LineText"];
                    }
                }
                return mostBoldedWord;
            }
            catch(Exception e)
            {
               LoggerService.GetInstance().ERROR(e.Message);
               return "API ERROR";
            }
            
        }
    }
}
