using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public ICollection<PetOwner> GetOwners() {
            return _context.Owners.ToArray();
        }

        [HttpGet("{OwnerId}")]
        public IActionResult GetOwnerById(int OwnerId){
            PetOwner foundOwner = _context.Owners.SingleOrDefault(owner => owner.id == OwnerId);
            if(foundOwner == null){
                return NotFound();
            }
            return Ok(foundOwner);
        }

        [HttpPut("{OwnerId}")]
        public IActionResult editOwner([FromBody] PetOwner newOwner, int OwnerId){
            if(OwnerId != newOwner.id) return BadRequest();
            if(!_context.Owners.Any(owner => owner.id == OwnerId)) return NotFound();

            _context.Owners.Update(newOwner);
            _context.SaveChanges();
            return Ok(newOwner);
        }

        [HttpPost]
        public IActionResult createOwner([FromBody] PetOwner newOwner){
            _context.Owners.Add(newOwner);
            _context.SaveChanges();
            return Created($"/api/petowners/{newOwner.id}", newOwner);
        }

        [HttpDelete("{OwnerId}")]
        public IActionResult DeleteOwner(int OwnerId) {
            PetOwner DeletionOwner = _context.Owners.SingleOrDefault(owner => owner.id == OwnerId);

            if (DeletionOwner == null) return NotFound();

            _context.Owners.Remove(DeletionOwner);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
