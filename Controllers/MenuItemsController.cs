using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truyum.Models;

namespace Truyum.Controllers
{
    public class MenuItemsController : Controller
    {
        TruyumContext db = new TruyumContext();
        //public bool isAdmin = false;

        // GET: MenuItems
        [HandleError]
        public ActionResult Index(bool? isAdmin)
        {
            if(isAdmin==true)
            {
                var items = db.MenuItems.ToList();
                ViewBag.Type = "Admin";
                return View(items);
            }
            else
            {
                List<MenuItem> ilist = new List<MenuItem>();
                var items = db.MenuItems.ToList();
                foreach (var item in items)
                {
                    if (item.active == true && item.dateOfLaunch<=DateTime.Now)
                    {
                        ilist.Add(item);
                    }
                }
                ViewBag.Type = "Customer";
                return View(ilist);
            }
        }
        [HandleError]
        public ActionResult Create()
        {

            //List<Category> ListCategory = new List<Category>()
            //{
            //    new Category() {Id = 1, Name="Main Course" },
            //    new Category() {Id = 2, Name="Starter" },
            //    new Category() {Id = 3, Name="Desert" },
            //};
            //ViewBag.Category = ListCategory;

            return View();
        }
        [HttpPost]
        public ActionResult Create(MenuItem model)
        {
            if (ModelState.IsValid)
            {
              
                    db.MenuItems.Add(model);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                
             
            }
            else
            {
                ModelState.AddModelError("", "Invalid Operation");
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                var item = db.MenuItems.Find(id);
                return View("Create", item);
            }
            catch
            {
                ModelState.AddModelError("", "Invalid Operation");
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public ActionResult Edit(MenuItem model)
        {
            try
            {
                db.Entry<MenuItem>(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Invalid Operation");
                return View("Index");
            }


        }
        Cart c = new Cart();
        public ActionResult AddToCart(int id)
        {
            var menuitem = db.MenuItems.Find(id);
            c.UserId = 1;
            c.MenuItemId = id;
            db.Carts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }
        public ActionResult Cart()
        {

            var query = db.MenuItems.Join(db.Carts, x => x.id, y => y.MenuItemId, (x, y) => x).ToList();
            db.SaveChanges();
            if (query.Count == 0)
            {
                ViewBag.empty = "True";
            }
            else
            {
                ViewBag.empty = "False";
            }
            return View(query);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var item = (from s in db.Carts where s.MenuItemId == id select s).First();
                db.Carts.Remove(item);
                db.SaveChanges();
            }
            catch
            {
                ModelState.AddModelError("", "Invalid Operation");
            }

            return RedirectToAction("Cart");
        }
    }
}