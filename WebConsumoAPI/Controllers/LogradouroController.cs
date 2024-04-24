using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebConsumoAPI.Controllers
{
    public class LogradouroController : Controller
    {
        // GET: LogradouroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LogradouroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogradouroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogradouroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogradouroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogradouroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogradouroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogradouroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
