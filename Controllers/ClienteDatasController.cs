using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApplication10.Models;
using WebApplication12.Helper;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class ClienteDatasController : Controller
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

        public ActionResult Create()
        {
            return View();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,DNI,RUC")] ClienteData cliente)
        {
            System.Diagnostics.Debug.WriteLine("No resulto faf");
            if (ModelState.IsValid)
            {
                HttpClient client = _helper.Initial();
                var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
                //var content = new StringContent(cliente.ToString(), Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("api/cliente", content);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No resulto");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No valido");
            }
            System.Diagnostics.Debug.WriteLine("No resulto ff");


            return View(cliente);
            
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}



        public ActionResult Privacy()
        {
            return View();
        }

        //private WebApplication12Context db = new WebApplication12Context();

        //// GET: ClienteDatas
        //public ActionResult Index()
        //{
        //    return View(db.ClienteDatas.ToList());
        //}

        //// GET: ClienteDatas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClienteData clienteData = db.ClienteDatas.Find(id);
        //    if (clienteData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clienteData);
        //}

        //// GET: ClienteDatas/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ClienteDatas/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,DNI,RUC")] ClienteData clienteData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ClienteDatas.Add(clienteData);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(clienteData);
        //}

        //// GET: ClienteDatas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClienteData clienteData = db.ClienteDatas.Find(id);
        //    if (clienteData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clienteData);
        //}

        //// POST: ClienteDatas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,DNI,RUC")] ClienteData clienteData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(clienteData).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(clienteData);
        //}

        //// GET: ClienteDatas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClienteData clienteData = db.ClienteDatas.Find(id);
        //    if (clienteData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clienteData);
        //}

        //// POST: ClienteDatas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ClienteData clienteData = db.ClienteDatas.Find(id);
        //    db.ClienteDatas.Remove(clienteData);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
