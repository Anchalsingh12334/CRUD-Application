using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class CustomerController : Controller

    {
        private ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Location>
                Locations = dbContext.Locations.ToList();
            return View(Locations);
        }
        public IActionResult CustomerList (int id)
        {
            List<Customer>
                Customers
                = dbContext.Customers.Where
                (e => e.Location.Id == id).ToList();
            return View(Customers);
        }
        public IActionResult ShowAllCust()
        {
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
      
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return RedirectToAction("ShowAllCust");
        }
        public IActionResult Delete(int?id)
        {
            var data = dbContext.Customers.FirstOrDefault(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = dbContext.Customers.FirstOrDefault(x =>x.Id == id);
            dbContext.Customers.Remove(data);
            dbContext.SaveChanges();
            return RedirectToAction("ShowAllCust");
        }
        public IActionResult Edit(int id)
        {

         var emp=   dbContext.Customers.FirstOrDefault(x => x.Id == id);

            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            dbContext.Customers.Update(customer);
            dbContext.SaveChanges();
            return RedirectToAction("ShowAllCust");
        }

    }
}
