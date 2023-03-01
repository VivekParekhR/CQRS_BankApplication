using Bank.Infrastructure.StaticProvider;
using Bank.Shared.ServiceMessagingObject;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Bank.Shared.Utility
{
    public static class SMSUtility
    {
        public static async Task sendMessage(EmailNotification emailNotification)
        {
            var url = "https://api.ultramsg.com/instance33374/messages/chat";
            var client = new RestClient(url);

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", ERPConstant.SMSToken);
            request.AddParameter("to", emailNotification.PhonNo);
            request.AddParameter("body", emailNotification.Body);


            var response = await client.ExecuteAsync(request);
            var output = response;
            Console.WriteLine(output);
        } 
    }
}
