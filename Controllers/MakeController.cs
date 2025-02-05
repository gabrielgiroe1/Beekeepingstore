﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeekeepingStore.Models;
using BeekeepingStore.AppDbContext;
using Microsoft.AspNetCore.Authorization;
namespace BeekeepingStore.Controllers
{
    [Authorize(Roles =(Helpers.Roles.Executive +","+Helpers.Roles.Admin))]
   // [Authorize(Roles ="Admin,Executive")]
    public class MakeController : Controller
    {
        private readonly BeekeepingDbContext _db;
        public MakeController(BeekeepingDbContext db)
        {
            _db = db;
        }
      public IActionResult Index()
        {
            return View(_db.Makes.ToList());
        }
        //HTTP Get Method
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Make make)
        {
            if(ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var make = _db.Makes.Find(id);
            
            if (make == null)
            {
                return NotFound();
            }
            _db.Makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var make = _db.Makes.Find(id);

            if (make == null)
            {
                return NotFound();
            }
           
            return View(make);
        }
        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
         
    }
}
