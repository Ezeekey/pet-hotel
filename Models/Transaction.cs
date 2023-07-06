using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public class Transaction
    {
        public int id { get; set; }

        [Required]
        public string Description;

        [Required]
        public DateTime time { get; set; }

        public Transaction (string descrip) {
            Description = descrip;
            time = DateTime.Now;
        }
    }
}