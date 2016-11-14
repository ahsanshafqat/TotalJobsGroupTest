using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly HttpClient _serviceClient;

        public QuestionnaireController():this(new ServiceClient())
        {
        }

        private QuestionnaireController(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient.Instance;
        }

        public ActionResult Index()
        {
            HttpResponseMessage responseMessage = _serviceClient.GetAsync("questions").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var questions = JsonConvert.DeserializeObject<QuestionnaireViewModel>(responseData);

                return View(questions);
            }
            return View("Error");
        }
    }
}
