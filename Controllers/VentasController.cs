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
    public class VentasController : Controller
    {
        private FacturaContext db = new FacturaContext();
        List<LibroData> libros = new List<LibroData>();
        ApiEjemplo _helper = new ApiEjemplo();
        // GET: Ventas
        //public ActionResult Index()
        //{
        //    return View(db.FacturaDatas.ToList());
        //}

        public async Task<ActionResult> Index()
        {
            //List<>
            
            
            return View();
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaData facturaData = db.FacturaDatas.Find(id);
            if (facturaData == null)
            {
                return HttpNotFound();
            }
            return View(facturaData);
        }

        // GET: Ventas/Create
        public async Task<ActionResult> Create()
        {
            List<SelectListItem> opciones = new List<SelectListItem>();
            HttpClient client = _helper.Initial();
            HttpResponseMessage res = await client.GetAsync("api/libro");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                libros = JsonConvert.DeserializeObject<List<LibroData>>(results);
            }
            foreach (var item in libros)
            {
                opciones.Add(new SelectListItem { Text = item.Nombre, Value = item.ID.ToString() });
            }
            

            //Recorro la lista (que en tu caso vendría creada de otro lugar, asumo
            foreach (var opcion in opciones)
            {
                //Evalúo la condición que me llevaría a hacer que esa opción este seleccionada
                if (opcion.Text.Contains(opciones.Count.ToString()))
                {
                    //La selecciono
                    opcion.Selected = true;
                }
            }
            //Por último la asigno a un ViewBag y retorno la vista
            ViewBag.opciones = opciones;
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] FacturaData facturaData)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDatas.Add(facturaData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facturaData);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaData facturaData = db.FacturaDatas.Find(id);
            if (facturaData == null)
            {
                return HttpNotFound();
            }
            return View(facturaData);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] FacturaData facturaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facturaData);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaData facturaData = db.FacturaDatas.Find(id);
            if (facturaData == null)
            {
                return HttpNotFound();
            }
            return View(facturaData);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaData facturaData = db.FacturaDatas.Find(id);
            db.FacturaDatas.Remove(facturaData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
