using APITestingTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace APITestingTool.Controllers
{
    public class SoapController : Controller
    {
        private readonly HttpClient _httpClient;

        public SoapController()
        {
            _httpClient = new HttpClient();
        }

        public ActionResult Index()
        {
            return View(new SoapRequestModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(SoapRequestModel model)
        {
            try
            {
                string response = await CallSoapApiAsync(model.SoapAction, model.SoapBody, model.SoapNamespace);
                model.Response = response;
            }
            catch (Exception ex)
            {
                model.Response = $"Error calling SOAP API: {ex.Message}";
            }

            return View(model);
        }

        private async Task<string> CallSoapApiAsync(string soapAction, string soapBody,string soapNamespace)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, soapNamespace);
            request.Headers.Add("SOAPAction", soapAction);
            request.Content = new StringContent(soapBody, Encoding.UTF8, "text/xml");

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
