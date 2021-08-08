﻿using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace PlateLicense
{
    class ImageToTextService
    {
        private static string API_URL = "https://api.ocr.space/parse/image";

        public static string API_KEY { get; set; } = "helloworld";

        private static string LANGUAGE = "eng";
        public static string getImageText(string filepath)
        {
            double bestTextHigh = 0;
            string boldAndbestSizeWord = "";
            var client = new RestClient(API_URL);
            var request = new RestRequest(Method.POST);
            request.AddParameter("language", LANGUAGE);
            request.AddFile("file", filepath);
            request.AddParameter("isCreateSearchablePdf", "true");
            request.AddParameter("isSearchablePdfHideTextLayer", "true");
            request.AddParameter("apikey", API_KEY);
            try
            {              
                IRestResponse response = client.Execute(request);
                Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
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
                //Get the most bold text
                foreach (dynamic data in result["ParsedResults"][0]["TextOverlay"]["Lines"])
                {
                    string wordHigh = data["Words"][0]["Height"];
                    if (double.Parse(wordHigh) > bestTextHigh)
                    {
                        bestTextHigh = double.Parse(wordHigh);
                        boldAndbestSizeWord = data["LineText"];
                    }
                }
                return boldAndbestSizeWord;
            }
            catch(Exception e)
            {
               LoggerService.GetInstance().ERROR(e.Message);
               return "API ERROR";
            }
            
        }
    }
}
