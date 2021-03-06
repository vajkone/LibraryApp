﻿using LibraryApp_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryApp_ClerkClient.DataProviders
{
    class LoanBookDataProvider
    {
        private static string _baseurl = "http://localhost:5000/api/loanbook";
        public static void CreateLoanBook(LoanBook loanbook)
        {

            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(loanbook);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_baseurl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }

        }

        public static LoanBook GetLoanBookByInvNum(string invnum)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byInvNum?invnum=" + invnum).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var lb = JsonConvert.DeserializeObject<LoanBook>(rawData);
                    return lb;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static long GetMemberIdByLoanBook(string invnum)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseurl + "/byLoanBook?invnum=" + invnum).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var member = JsonConvert.DeserializeObject<long>(rawData);
                    return member;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void RemoveLoanBook(LoanBook loanbook)
        {
            using (var client = new HttpClient())
            {


                var response = client.DeleteAsync(_baseurl + "/" + loanbook.LB_InventoryNumber).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }
    }
}
