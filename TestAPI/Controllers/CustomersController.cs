using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        AppDbContext context;
        public CustomersController(ILogger<CustomersController> logger, AppDbContext _context)
        {
            _logger = logger;
            context = _context;
        }
        [HttpGet]
        public List<Customers> Index()
        {
            return context.Customers.ToList();
        }
        [HttpGet("{id}")]
        public Customers Details(int id)
        {
            return context.Customers.Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public CustomersResult Create(Customers customer)
        {
            if (customer.State.Length >= 2 && customer.State.Any(char.IsDigit)) return new CustomersResult() { Message = "Error, datos incorrectos o no validos.", Status = 400, Body = null}; ;
            context.Customers.Add(customer);
            context.SaveChanges();
            return new CustomersResult() {Message = "OK", Status = 200, Body = new List<Customers>() { customer } };
        }
        [HttpDelete]
        public CustomersResult Delete(int id)
        {
            var entity = context.Customers.FirstOrDefault(item => item.Id == id);
            if (entity != null)
            {
                context.Customers.Remove(entity);
                context.SaveChanges();
                context.SaveChanges();
                return new CustomersResult() { Message = "OK", Status = 200, Body = new List<Customers>() { entity } };
            }
            return new CustomersResult() { Message = "Error, no fue posible encontrar el registro", Status = 400, Body = null };
        }

        [HttpPut]
        public CustomersResult Update(Customers customer)
        {
            var entity = context.Customers.FirstOrDefault(item => item.Id == customer.Id);
            if(entity != null)
            {
                entity.Address = customer.Address;
                entity.City = customer.City;
                entity.Company = customer.Company;
                entity.Department = customer.Department;
                entity.Email = customer.Email;
                entity.Last_Name = customer.Last_Name;
                entity.Name = customer.Name;
                entity.Phone1 = customer.Phone1;
                entity.Phone2 = customer.Phone2;
                entity.State = customer.State;
                entity.Zip = customer.Zip;
                context.SaveChanges();
                return new CustomersResult() { Message = "OK", Status = 200, Body = new List<Customers>() { customer } };
            }
            return new CustomersResult() { Message = "Error, no fue posible encontrar el registro", Status = 400, Body = null}; ;
        }

    }
}
