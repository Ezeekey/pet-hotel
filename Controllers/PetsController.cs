using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return new List<Pet>();
        }

        [HttpPut("{PetId}")]
        public IActionResult EditPet([FromBody] Pet pet, int PetId) {
            if (PetId != pet.id) {
                return BadRequest();
            }

            Pet thePet = pet;
            thePet.petOwner = _context.Owners.SingleOrDefault(owner => owner.id == thePet.petOwnerid);

            _context.Pets.Update(thePet);
            _context.SaveChanges();
            return Ok(thePet);
        }

        [HttpPut("{PetId}/checkin")]
        public IActionResult CheckInPet(int PetId) {
            Pet CheckInPet = _context.Pets.SingleOrDefault(pet => pet.id == PetId);

            if (CheckInPet == null) {
                return NotFound();
            }

            CheckInPet.CheckIn();
            _context.Pets.Update(CheckInPet);
            _context.SaveChanges();
            return Ok(CheckInPet);
        }

        [HttpPut("{PetId}/checkout")]
        public IActionResult CheckOutPet(int PetId) {
            Pet CheckInPet = _context.Pets.SingleOrDefault(pet => pet.id == PetId);

            if (CheckInPet == null) {
                return NotFound();
            }

            CheckInPet.CheckOut();
            _context.Pets.Update(CheckInPet);
            _context.SaveChanges();
            return Ok(CheckInPet);
        }

        [HttpPost]
        public IActionResult CreatePet([FromBody] Pet newPet) {
            Pet theNewNewPet = newPet;
            theNewNewPet.petOwner = _context.Owners.SingleOrDefault(owner => owner.id == newPet.petOwnerid);

            _context.Pets.Add(theNewNewPet);
            _context.SaveChanges();
            Console.WriteLine("uuuuh hi?");
            Console.WriteLine("Owner object, {0}\n Owner id, {1}", theNewNewPet.petOwner, theNewNewPet.petOwnerid);
            return Created($"/api/pets/{newPet.id}", theNewNewPet);
        }

        [HttpDelete("{PetId}")]
        public IActionResult DeletePet(int PetId) {
            Pet DeletionPet = _context.Pets.SingleOrDefault(pet => pet.id == PetId);

            if (DeletionPet == null) {
                return null;
            }
            _context.Pets.Remove(DeletionPet);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
