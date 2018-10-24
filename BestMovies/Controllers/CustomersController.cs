﻿using BestMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestMovies.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customers> _modelCustomers =  new List<Customers>() { new Customers {IdCustomers = 1, FirstName = "John", LastName = "Smith" },
                                                    new Customers {IdCustomers = 2, FirstName = "Mary", LastName = "Williams"}
                                              };
        
        public ActionResult Index()
        {
          
            return View(_modelCustomers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {

            var customer = _modelCustomers.FirstOrDefault(c => c.IdCustomers == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
