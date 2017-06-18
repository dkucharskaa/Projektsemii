using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektSemi.Models;
using System.Threading.Tasks;
using System.Net;


namespace ProjektSemi.Controllers
{
    public class NieruchomosciController : Controller
    {
        // GET: Nieruchomosci


        public ActionResult Index(string sortOrder)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.TypeSort = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.ModelSort = sortOrder == "modelsort" ? "modelsort_desc" : "modelsort";
            ViewBag.NameSort = sortOrder == "namesort" ? "namesort_desc" : "namesort";
            ViewBag.CategorySort = sortOrder == "categorysort" ? "categorysort_desc" : "categorysort";
            ViewBag.AddressSort = sortOrder == "addresssort" ? "addresssort_desc" : "addresssort";
            ViewBag.PriceSort = sortOrder == "pricesort" ? "pricesort" : "pricesort";
            ViewBag.SurfaceSort = sortOrder == "surfacesort" ? "surfacesort" : "surfacesort";


            switch (sortOrder)
            {

                case "modelsort":
                    model = model.OrderBy(m => m.Model).ToList();
                    break;
                case "modelsort_desc":
                    model = model.OrderByDescending(m => m.Model).ToList();
                    break;

                case "producentsort":
                    model = model.OrderBy(m => m.Producent).ToList();
                    break;
                case "producentsort_desc":
                    model = model.OrderByDescending(m => m.Producent).ToList();
                    break;

                case "pricesort":
                    model = model.OrderBy(m => m.Price).ToList();
                    break;
                case "pricesort_desc":
                    model = model.OrderByDescending(m => m.Price).ToList();
                    break;

                case "qualitysort":
                    model = model.OrderBy(m => m.Quality).ToList();
                    break;
                case "qualitysort_desc":
                    model = model.OrderByDescending(m => m.Quality).ToList();
                    break;

            }
            var items = DocumentDBRepository.GetIncompleteItems();
            return this.View(items);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nazwa,Kategoria,Adres,Cena,Powierzchnia,CzySprzedane,Dom,Opis,Completed")] Nieruchomosci item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository.CreateItemAsync(item);
                return this.RedirectToAction("Index");
            }
            return this.View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nazwa,Kategoria,Adres,Cena,Powierzchnia,CzySprzedane,Opis,Completed")] Nieruchomosci item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository.UpdateItemAsync(item);
                return this.RedirectToAction("Index");
            }
            return this.View(item);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nieruchomosci item = (Nieruchomosci)DocumentDBRepository.GetItem(id);
            if (item == null)
            {
                return this.HttpNotFound();
            }
            return this.View(item);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nieruchomosci item = (Nieruchomosci)DocumentDBRepository.GetItem(id);
            if (item == null)
            {
                return this.HttpNotFound();
            }
            return this.View(item);
        }
        [HttpPost, ActionName("Delete")]
        //// To protect against Cross-Site Request Forgery, validate that the anti-forgery token was received and is valid
        //// for more details on preventing see http://go.microsoft.com/fwlink/?LinkID=517254
        [ValidateAntiForgeryToken]
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<ActionResult> DeleteConfirmed([Bind(Include = "Id")] string id)
        {
            await DocumentDBRepository.DeleteItemAsync(id);
            return this.RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var item = DocumentDBRepository.GetItem(id);
            return this.View(item);
        }
    }
}