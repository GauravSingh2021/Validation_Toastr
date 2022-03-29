using AspNetCoreHero.ToastNotification.Abstractions;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class EmployerController : Controller
    {
        private readonly DemoDbContext dbContext;
        private readonly INotyfService _notfy;
        public EmployerController(DemoDbContext context, INotyfService notfy)
        {
            dbContext = context;
            _notfy = notfy;
        }
        public IActionResult Index()
        {
            var list = dbContext.demotbl.ToList();
            return View(list);
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employer employer)
        {
            dbContext.demotbl.Add(employer);
            dbContext.SaveChanges();
            _notfy.Success("User created Successfully");
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var list = dbContext.demotbl.SingleOrDefault(e => e.Id == id);
            return View(list);
        }
        [HttpPost]
        public IActionResult Edit(Employer model)
        {
            dbContext.demotbl.Update(model);
            dbContext.SaveChanges();
            _notfy.Warning("User updated Successfully");
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var list = dbContext.demotbl.SingleOrDefault(e => e.Id == id);
            return View(list);
        }
        public IActionResult Delete(int Id)
        {
            var list = dbContext.demotbl.SingleOrDefault(e => e.Id == Id);
            if (list != null)
            {
                dbContext.demotbl.Remove(list);
                dbContext.SaveChanges();
                _notfy.Error("User deleted Successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
