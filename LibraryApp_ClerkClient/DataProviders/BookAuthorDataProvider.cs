using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class BookAuthorDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/bookauthor";

        public static void CreateBookAuthorLink(BookAuthor ba)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(ba);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }
    }
}
