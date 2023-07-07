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
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TransactionsController (ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ICollection<Transaction> GetAllTransactions ()
        {
            return _context.Transactions.ToArray();
        }

        [HttpGet("{TransactionId}")]
        public IActionResult GetTransactionById (int TransactionId)
        {
            Transaction theTransaction = _context.Transactions.SingleOrDefault(action => action.id == TransactionId);

            if (theTransaction == null) return NotFound();

            return Ok(theTransaction);
        }

        [HttpDelete("{TransactionId}")]
        public IActionResult DeleteTransaction (int TransactionId)
        {
            Transaction DeletionAction = _context.Transactions.SingleOrDefault(action => action.id == TransactionId);

            if (DeletionAction == null) return NotFound();

            _context.Transactions.Remove(DeletionAction);
            _context.SaveChanges();
            return NoContent();
        }
    }
}