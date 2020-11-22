using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class MemberDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/member";

        public static IList<Member> GetMembers()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var member = JsonConvert.DeserializeObject<IList<Member>>(rawData);
                    return member;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static IList<Member> GetMembersByName(string name)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl+"/byName?name="+name).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var member = JsonConvert.DeserializeObject<IList<Member>>(rawData);
                    return member;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static Member GetMemberById(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/" + id).Result;

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

        public static Member GetLoaningMember(string invNum)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byInvNum?invNum=" + invNum).Result;

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



        public static void CreateMember(Member member)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(member);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        



        public static void UpdateMember(Member member)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(member);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static void DeleteMember(long id)
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

