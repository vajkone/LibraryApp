using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_MemberClient.DataProviders
{
    class BookDataProvider
    {

        private static string _baseurl = "http://localhost:5000/api/book";

        public static IList<Book> GetBooksOfMember(long memberId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl+"/ofMember?id="+memberId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var book = JsonConvert.DeserializeObject<IList<Book>>(rawData);
                    return book;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
