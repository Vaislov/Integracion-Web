using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Helper;
using System.Diagnostics;
using WebApplication10.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {

        ApiEjemplo _helper = new ApiEjemplo();

        public async Task<ActionResult> Index()
        {
            //List<>
            List<ClienteData> clientes = new List<ClienteData>();
            HttpClient client = _helper.Initial();
            HttpResponseMessage res = await client.GetAsync("api/cliente");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<ClienteData>>(results);
            }
            return View(clientes);
        }

        //[HttpPost]
        //public async Task<ClienteData> Edit(ClienteData product)
        //{
        //    HttpClient client = _helper.Initial();

        //    HttpResponseMessage response = await client.PutAsJsonAsync(
        //        $"api/cliente/{product.ID}", product);
        //    response.EnsureSuccessStatusCode();

        //    product = await response.Content.ReadAsAsync<ClienteData>();
        //    return product;
        //}


        [HttpPost]
        public ActionResult Create(ClienteData cliente)
        {
            HttpClient client = _helper.Initial();
            var content = new StringContent(cliente.ToString(), Encoding.UTF8, "application/json");
            var postTask = client.PostAsync("api/cliente", content);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}



        public ActionResult Privacy()
        {
            return View();
        }

        //[Respon(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}