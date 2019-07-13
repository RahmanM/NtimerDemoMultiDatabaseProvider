using RestSharp;
using SampleNTier.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sample.NTier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url = ConfigurationManager.AppSettings.Get("Customers.Api.Url");
            var client = new RestClient(url);
            var request = new RestRequest("Customers", Method.GET);
            var response = client.Execute<List<Customer>>(request);
            return View(response.Data);
        }

        public ActionResult Details(int id)
        {
            var url = ConfigurationManager.AppSettings.Get("Customers.Api.Url");
            var client = new RestClient(url);
            var request = new RestRequest("Customers", Method.GET);
            request.AddParameter("id", id); 
            var response = client.Execute<Customer>(request);
            return View(response.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            var url = ConfigurationManager.AppSettings.Get("Customers.Api.Url");
            var client = new RestClient(url);
            var request = new RestRequest("Customers", Method.POST);

            var jsonToSend = new JavaScriptSerializer().Serialize(customer);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<Customer>>(request);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var url = ConfigurationManager.AppSettings.Get("Customers.Api.Url");
            var client = new RestClient(url);
            var request = new RestRequest("Customers", Method.DELETE);
            request.AddParameter("id", id);
            var response = client.Execute<Customer>(request);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}