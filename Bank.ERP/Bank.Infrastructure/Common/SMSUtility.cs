using Bank.Domain.Entity; 
using RestSharp; 

namespace Bank.Infrastructure.Common
{
    public static class SMSUtility
    {
        public static async Task SendMessage(EmailNotification emailNotification)
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
