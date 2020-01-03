using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context;
        // GET: Hero
        public HeroController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.Heroes.ToList());
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();
            return View(hero);
        }
        


        // GET: Hero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Hero  hero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult List()
        {
            List<Hero> heroList = context.Heroes.ToList();
            return View(heroList);
        }

        [HttpPost]
        public ActionResult List(List<Hero> heroList)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).First();
            return View(hero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hero hero)
        {
            try
            {
                // TODO: Add update logic here

                context.Heroes.Remove(context.Heroes.FirstOrDefault(h => h.Id == hero.Id));
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero heroDelete = context.Heroes.Find(id); 
            return View(heroDelete);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                // TODO: Add delete logic here
                context.Heroes.Remove(context.Heroes.FirstOrDefault(h => h.Id == hero.Id));
                context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
