using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class BookDataProvider
    {

        private static string _baseurl = "http://localhost:5000/api/book";

        public static IList<Book> GetBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl).Result;

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

        public static void CreateBook(Book book)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(book);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static long GetBookByIsbn(string isbn)
        {
            // http://localhost:5000/api/book/byISBN?isbn=012012

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl+"/byISBN?isbn="+isbn).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var bookId = JsonConvert.DeserializeObject<long>(rawData);
                    return bookId;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }



        public static void UpdateBook(Book book)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(book);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static void DeleteBook(long id)
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
