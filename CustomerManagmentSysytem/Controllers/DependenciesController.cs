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
using CustomerManagmentSysytem.Data.Models;
using System.Security.Cryptography;

namespace CustomerManagmentSysytem.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]

    public class DependenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly DependencyService _dependencyService ;
        public DependenciesController(ApplicationDbContext context, DependencyService dependencyService)
        {
            _context = context;
            _dependencyService = dependencyService;
        }

        [HttpGet("GetDependencies")]
        public IActionResult ListAll() {
            var ListOfDependencies = _dependencyService.GetAllDependencies();
            return Ok(ListOfDependencies);
        }

        [HttpGet("DependencyByPair/{Cid}/{Sid}")]
        public IActionResult GetPerticularDependency([FromRoute] int Cid, [FromRoute] int Sid)
        {
            var Dependency = _dependencyService.GetDependencyByUnique( Cid, Sid);
            return Ok(Dependency);
        }

        [HttpPost("RegisterDependency")]

        public IActionResult Register([FromBody] Customer_Service customer_Service) {
            var RegistringDependency = _dependencyService.RegisterDependency(customer_Service);

            return Ok(RegistringDependency);

        }
        [HttpPut("EditDependency/{id}")]
        public IActionResult EditService([FromBody] Customer_Service customer_Service)
        {
            var DependencyToRegister = _dependencyService.UpdateDependency(customer_Service);
            return Ok(DependencyToRegister);
        }

        [HttpDelete("DeleteDependencyByCustomer/{id}")]
        public IActionResult DeleteCustomerDependency(int id)
        {
            var RemovedDependency = _dependencyService.DeleteDependencyByCustomerId(id);
            return Ok(RemovedDependency);
        }
        [HttpDelete("DeleteDependencyByService/{id}")]
        public IActionResult DeleteServiceDependency(int id)
        {
            var RemovedDependency = _dependencyService.DeleteDependencyByService(id);
            return Ok(RemovedDependency);
        }
        [HttpDelete("DeleteDependency/{id}")]
        public IActionResult DeleteDependency(int id)
        {
            var RemovedDependency = _dependencyService.DeleteDependency(id);
            return Ok(RemovedDependency);
        }
        //// GET: api/Dependencies
        //[HttpGet]
        //public IEnumerable<Dependencies> GetDependencies()
        //{
        //    return _context.Dependencies;
        //}

        //// GET: api/Dependencies/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetDependencies([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dependencies = await _context.Dependencies.FindAsync(id);

        //    if (dependencies == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dependencies);
        //}

        //// PUT: api/Dependencies/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDependencies([FromRoute] int id, [FromBody] Dependencies dependencies)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dependencies.ServiceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dependencies).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DependenciesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Dependencies
        //[HttpPost]
        //public async Task<IActionResult> PostDependencies([FromBody] Dependencies dependencies)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Dependencies.Add(dependencies);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDependencies", new { id = dependencies.ServiceId }, dependencies);
        //}

        //// DELETE: api/Dependencies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDependencies([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dependencies = await _context.Dependencies.FindAsync(id);
        //    if (dependencies == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Dependencies.Remove(dependencies);
        //    await _context.SaveChangesAsync();

        //    return Ok(dependencies);
        //}

        //private bool DependenciesExists(int id)
        //{
        //    return _context.Dependencies.Any(e => e.ServiceId == id);
        //}
    }
}