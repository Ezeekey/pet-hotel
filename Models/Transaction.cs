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
        public string Description { get; set; }

        [Required]
        public DateTime time { get; set; }

        public Transaction () {
            // This is here to prevent an error
        }

        public Transaction (string descrip) {
            Description = descrip;
            time = DateTime.Now;

            Description += $"\nat: {time.ToString()}";
        }
    }
}