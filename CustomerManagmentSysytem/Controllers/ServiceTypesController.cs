using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Models;
using CustomerManagmentSysytem.Services;

namespace CustomerManagmentSysytem.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
        private readonly ServiceTypeService _serviceTypeService;

        public ServiceTypesController(ServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        // GET: api/ServiceTypes/GetAllServices
        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetServices()
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            IEnumerable<ServiceTypes> ListOfServices = _serviceTypeService.GetAllServices();
            return Ok(ListOfServices);

        }

        // GET: api/ServiceTypes/Service/5
        [HttpGet("Service/{id}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Service = _serviceTypeService.GetServiceById(id);

            if (Service == null)
            {
                return NotFound(Service);
            }

            return Ok(Service);
        }

        [HttpGet("Service/Owners/{id}")]
        public async Task<IActionResult> GetServiceByOwnerId([FromRoute] int id)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ServiceTypes> Service = _serviceTypeService.getServiceByCustomerId(id);

            //if (Service.Count == 0)
            //{
            //    return NotFound(Service);
            //}

            return Ok(Service);
        }

        // PUT: api/ServiceTypes/update/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] ServiceTypes service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.ServiceId)
            {
                return BadRequest("identity doesn not match ");
            }

            

            try
            {
                var ServiceToUpdate = _serviceTypeService.UpdateService(id, service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound("cannot find Service");
                }
                else
                {
                    return BadRequest("try again unable to save changes");
                }
            }

            return Ok("updated succesfully");
        }

        // POST: api/ServiceTypes/AddService
        [HttpPost("AddService")]
        public async Task<IActionResult> PostService([FromBody] ServiceTypes service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                _serviceTypeService.AddService(service);
            }
            catch(Exception ex) {
                return NotFound(ex.Message);
            }
            return Ok(service);
        }

        // DELETE: api/ServiceTypes/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            
     
            var service = _serviceTypeService.DeleteService(id);
            if (service is null)
            {
                return NotFound(service);
            }
            else
            {
                return Ok(service);
            }
        }

        private bool ServiceExists(int id)
        {
            return _serviceTypeService.ServiceTypeExists(id);
        }
    }
}