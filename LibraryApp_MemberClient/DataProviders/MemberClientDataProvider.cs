using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_MemberClient.DataProviders
{
    class MemberClientDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/member";

        public static Member GetMemberByFullName(string name)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byFullName?name=" + name).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var member = JsonConvert.DeserializeObject<Member>(rawData);
                    return member;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
