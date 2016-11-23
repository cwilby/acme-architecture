using Acme.Core.Domain.Customer;
using Acme.Core.DTO.Customer;
using Acme.Core.Exceptions;
using Acme.Core.Infrastructure;
using Acme.Core.Repository.Customer;
using Acme.Core.Service.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Http;

namespace Acme.Api.Controllers.Customer
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _customerService.GetAll();
        }

        // GET: api/customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                return Ok(_customerService.GetById(id));
            }
            catch (ReadEntityException)
            {
                return NotFound();
            }
        }

        // POST: api/customers
        public IHttpActionResult PostCustomer(CustomerDTO.WithRelations customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customer = _customerService.Create(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // PUT: api/customers/5
        public IHttpActionResult PutCustomer(int id, CustomerDTO.WithRelations customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerService.Update(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/customers/5
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.Delete(id);

                return Ok(customer);
            }
            catch (DeleteEntityException)
            {
                return NotFound();
            }
        }
    }
}