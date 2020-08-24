using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); 
        }
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDtos>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();


            return Ok(Mapper.Map<Customer ,CustomerDtos>(customer));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var customer = Mapper.Map<CustomerDtos, Customer>(customerDtos);

            _context.Customers.Add(customer);

            customerDtos.Id = customer.Id;

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id) , customerDtos);


        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                return NotFound();
            Mapper.Map(customerDtos, customerInDb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
