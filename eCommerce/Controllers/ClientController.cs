﻿using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ClientController : Controller
    {

        IRepository<Client> RepClient = new EFRepository<Client>();

        // GET: Client
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Index()
        {
            return View(RepClient.Lister());
        }

        //GET : Client/EditClient/identifiant
        [Authorize(Roles = CustomRoles.Client)]
        public ActionResult EditClient(string identifiant)
        {
            Client c = RepClient.Lister().Where(cl => cl.Identifiant == identifiant).First();
            return View(c);
        }

        [HttpPost]
        [Authorize(Roles = CustomRoles.Client)]
        public ActionResult EditClient(Client c)
        {
            try
            {
                // TODO: Add update logic here
                RepClient.Modifier(c.Id, c);
                return RedirectToAction("Index", "Manage");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Edit(int id)
        {
            Client c = RepClient.Trouver(id);
            return View(c);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Edit(int id, Client c)
        {
            try
            {
                // TODO: Add update logic here
                RepClient.Modifier(id, c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
