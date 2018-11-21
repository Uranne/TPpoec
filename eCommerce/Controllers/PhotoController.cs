using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using eCommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class PhotoController : Controller
    {
        IRepository<Photo> RepPhoto = new EFRepository<Photo>();
        IRepository<Produit> RepProduit = new EFRepository<Produit>();

        // GET: Photo
        public ActionResult Index(int id)
        {
            ViewBag.Title = "Photos de " + RepProduit.Lister().Where(p => p.Id == id).First().Nom;
            ViewBag.IdProduit = id;
            return View(RepPhoto.Lister().Where(p=>p.IdProduit==id));
        }

        // GET: Photo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Photo/Create
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: Photo/Create
        [HttpPost]
        public ActionResult Create(FileViewModel fileModel)
        {
            try
            {
                // TODO: Gérer le catch
                if (ModelState.IsValid)
                {
                    MemoryStream fileData = new MemoryStream();
                    fileModel.Image.InputStream.CopyTo(fileData);

                    Photo p = new Photo { Image = fileData.ToArray(), IdProduit=fileModel.IdProduit, ImageType=string.Format("data:{0};base64,", fileModel.Image.ContentType) };
                    RepPhoto.Ajouter(p);
                }
                return RedirectToAction("Index", new { id =fileModel.IdProduit});
            }
            catch(Exception)
            {

                return RedirectToAction("Create", new { id = fileModel.IdProduit });
            }
        }

        // GET: Photo/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Photo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Gérer le catch
                int idPhoto = RepPhoto.Trouver(id).IdProduit;
                RepPhoto.Supprimer(id);
                return RedirectToAction("Index", new { id =idPhoto});
            }
            catch
            {
                return View();
            }
        }
    }
}
