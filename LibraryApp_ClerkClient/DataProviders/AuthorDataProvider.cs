using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class AuthorDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/author";

        public static IList<Author> GetAuthors()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var author = JsonConvert.DeserializeObject<IList<Author>>(rawData);
                    return author;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void CreateAuthor(Author author)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(author);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }
        public static void UpdateAuthor(Author author)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(author);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static void DeleteAuthor(long id)
        {

            using (var client = new HttpClient())
            {


                var response = client.DeleteAsync(_baseurl + "/" + id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }
    }
}
