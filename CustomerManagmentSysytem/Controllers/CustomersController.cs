using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Mdoels;
using CustomerManagmentSysytem.Services;
using CustomerManagmentSysytem.Exceptions;
using System.Web.Http.Cors;

namespace CustomerManagmentSysytem.Controllers
{
    
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        public readonly CustomerService CustomerService;
        public CustomersController(CustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpPost("AddNew")]
        public IActionResult AddNewCustomer([FromBody] Customers customer)
        {
                var CustomerAdded=CustomerService.AddCustomer(customer);

            return Ok(CustomerAdded);
        }
        [HttpGet("AllCustomers")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await CustomerService.GetAllCustomer());
        }


        [HttpGet("Customer/{id}")]
        public IActionResult GetCustomerById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CustomerReturened=(CustomerService.GetCustomerById(id));

            if (CustomerReturened != null) {
                return Ok(CustomerReturened);
            }
            return NotFound(id);
        }


        [HttpGet("CustomerByEmail/{email}")]
        public IActionResult GetCustomerByMail([FromRoute]string email)
        {
            
            var CustomerReturened = CustomerService.getCustomerByEmail(email);

            if (CustomerReturened != null)
            {
                return Ok(CustomerReturened);
            }
            return NotFound("Customer Having Name " + email);
        }

        [HttpPut("Update/Customer/{id}")]
        public IActionResult UpdateCustomer([FromRoute]int id, [FromBody]Customers customer)
        {
            
            if (id != customer.CustomerId)
            {
                return NotFound(customer.CustomerId);
            }

            try
            {
                var customerToUpdate = CustomerService.UpdateCustomer(id, customer);
                if (customerToUpdate is null)
                {
                    return NotFound(customer);
                }
                return Ok(customerToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (UnwantedBehaviourException ex)
            {
                return StatusCode(500, ex.Message);
            }
                 

        }

        [HttpDelete("Customer/delete/{id}")]
        public IActionResult DeleteCustomer([FromRoute]int id)
        {

            var customerToDelete = CustomerService.DeleteCustomer(id);
            if (customerToDelete is null)
            {
                return NotFound(id);
            }
            return Ok(customerToDelete);
        }

        [HttpPut("Customer/{id}")]
        public async Task<IActionResult> saveFile([FromForm]IFormFile file,[FromRoute] int id, string fileName)
        {
            var result= await CustomerService.saveFileInDb(file,id, fileName);
            if (!result)
            {
                return Ok(fileName + " not created");
            }
            return Ok(fileName + " has been created");
        }


      
        private bool CustomersExists(int id)
        {
            return CustomerService.CustomersExists(id);
        }


    }
}