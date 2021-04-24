﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Cine_metodologia.Controllers
{
    public class ComprasController : Controller
    {
        // GET: ComprasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComprasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult PaginaCompras()
        {
            return View();
        }

        public IActionResult Informacion()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprasController/Create
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

        // GET: ComprasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComprasController/Edit/5
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

        // GET: ComprasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComprasController/Delete/5
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
