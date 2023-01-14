using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MyFunctionApp
{
    public static class MakeCall
    {
        [FunctionName("MakeCall")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Twilio Account SID and Auth Token
            const string accountSid = "your_account_sid";
            const string authToken = "your_auth_token";

            // Twilio Phone Number
            const string twilioNumber = "your_twilio_number";

            // Phone number to call
            var toNumber = req.Query["to"];

            // Initialize Twilio client
            TwilioClient.Init(accountSid, authToken);

            try
            {
                // Make call
                var call = await CallResource.CreateAsync(
                    to: new Twilio.Types.PhoneNumber(toNumber),
                    from: new Twilio.Types.PhoneNumber(twilioNumber),
                    url: new Uri("http://demo.twilio.com/docs/voice.xml")
                );

                // Log call SID
                log.LogInformation($"Call SID: {call.Sid}");

                // Return OK status
                return new OkObjectResult("Call in progress");
            }
            catch (Exception ex)
            {
                // Log error
                log.LogError(ex, "Error making call");

                // Return error status
                return new StatusCodeResult(500);
            }
        }
    }
}
