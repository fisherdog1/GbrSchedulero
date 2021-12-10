using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GbrWebFrontend.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUpController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignUpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignUpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUpController/Create
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

        // GET: SignUpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUpController/Edit/5
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

        // GET: SignUpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUpController/Delete/5
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
