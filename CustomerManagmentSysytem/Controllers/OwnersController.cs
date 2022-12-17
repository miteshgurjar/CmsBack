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

namespace CustomerManagmentSysytem.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class OwnersController : ControllerBase
    {
        private readonly OwnerService _ownersService;

        public OwnersController(OwnerService ownersService)
        {
            _ownersService = ownersService;
        }

        // GET: api/Owners
        [HttpGet("GetAllOwners")]
        public async Task<IActionResult> GetOwners()
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            IEnumerable<Owners> ListOfOwners =   _ownersService.GetAllOwners();
            return Ok(ListOfOwners);

        }

        // GET: api/Owners/5
        [HttpGet("Owner/{id}")]
        public async Task<IActionResult> GetOwnerById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owners = _ownersService.GetOwnerById(id);

            if (owners == null)
            {
                return NotFound("no such owner exists");
            }

            return Ok(owners);
        }

        // PUT: api/Owners/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutOwner([FromRoute] int id, [FromBody] Owners owners)
        {

            //ModelState.Remove("OwnerFullName");
            //ModelState.Remove("OwnerEmail");
            //ModelState.Remove("OwnerPassword;

            if (id != owners.OwnerId)
            {
                return BadRequest("identity doesn not match ");
            }

            

            try
            {
                var OwnerToUpdate = _ownersService.UpdateOwnerDetails(id, owners);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnersExists(id))
                {
                    return NotFound("cannot find Owner");
                }
                else
                {
                    return BadRequest("try again unable to save changes");
                }
            }

            return Ok("updated succesfully");
        }

        // POST: api/Owners
        [HttpPost("AddOwner")]
        public async Task<IActionResult> PostOwner([FromBody] Owners owners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ownersService.AddNewOwner(owners);

            return CreatedAtAction("GetOwners", new { id = owners.OwnerId }, owners);
        }

        // DELETE: api/Owners/5
        [HttpDelete("deleteOwner/{id}")]
        public async Task<IActionResult> DeleteOwner([FromRoute] int id)
        {

            try
            {
                var owner = _ownersService.DeleteOwner(id);
                if (owner == null)
                {
                    return NotFound(owner);
                }

                return Ok(owner);
            }
            catch(DbUpdateConcurrencyException ex) {
                return BadRequest(ex.Message);
            }
        }

        private bool OwnersExists(int id)
        {
            return _ownersService.OwnerExists(id);
        }
    }
}