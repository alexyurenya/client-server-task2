using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataApp2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DataApp2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index()
        {
            return View(await db.Phones.ToListAsync());
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            db.Phones.Add(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Filtr(string name)
        {
            IQueryable<Phone> users = db.Phones;

            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));

            }
            ForView viewModel = new ForView
            {
                Phones = users.ToList(),
                Name = name,

            };
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            db.Phones.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                {
                    db.Phones.Remove(phone);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }       
    }
}

    




