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

        public static IList<Book> GetBooksByTitle(string title)
        {
            // http://localhost:5000/api/book/byTitle?title=012012

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byTitle?title=" + title).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IList<Book>>(rawData);
                    return books;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }

        public static IList<Book> GetBooksByAuthor(string author)
        {
           

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byAuthor?author=" + author).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IList<Book>>(rawData);
                    return books;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }
        

        public static IList<LoanBook> GetBooksOfMember(long memberId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl+"/ofMember?id="+memberId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var book = JsonConvert.DeserializeObject<IList<LoanBook>>(rawData);
                    return book;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static Book GetBookByInvNum(string invnum)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byInvNum?invnum=" + invnum).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var book = JsonConvert.DeserializeObject<Book>(rawData);
                    return book;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static Author GetBookAuthor(long bookid)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/authorById?bookid=" + bookid).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var author = JsonConvert.DeserializeObject<Author>(rawData);
                    return author;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
        
    }
}
