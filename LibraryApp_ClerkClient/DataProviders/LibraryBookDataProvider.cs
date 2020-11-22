using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class LibraryBookDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/librarybook";
        public static IList<LibraryBook> GetCopiesOfBook(long bookId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl+"/"+bookId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var libraryBook = JsonConvert.DeserializeObject<IList<LibraryBook>>(rawData);
                    return libraryBook;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        

        public static void CreateLibraryBook(LibraryBook libraryBook)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(libraryBook);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static void LendLibraryBook(LibraryBook libraryBook)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(libraryBook);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_baseurl+"/"+libraryBook.InventoryNumber, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }
    }
}
