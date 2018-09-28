using System;
using ComingSoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ComingSoon.Controllers
{
    public class HomeController : Controller
    {
        private IOptions<SendinblueConfiguration> _sendinblueConfiguration;

        public HomeController(IOptions<SendinblueConfiguration> sendinblueConfiguration)
        {
            _sendinblueConfiguration = sendinblueConfiguration;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            var client = new RestClient("https://api.sendinblue.com/v3/contacts");
            var request = new RestRequest(Method.POST);
            request.AddHeader("api-key", _sendinblueConfiguration.Value.ApiKey);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", $"{{\"email\":\"{email}\",\"listIds\":[],\"smtpBlacklistSender\":[]}}", ParameterType.RequestBody);
            var response = client.Execute(request);

            return RedirectPermanent("https://twitter.com/safeblock_io/status/1045515455719493632");
        }
    }
}
