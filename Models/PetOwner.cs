using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {
        public int id { get; set; }

        [Required]
        string name { get; set; }

        [Required]
        string emailAddress { get; set; }

        [JsonIgnore]
        public ICollection<Pet> pets { get; set; }

        [NotMapped]
        public int petCount {
            get {
                return pets == null ? 0 : pets.Count;
            }
        }
    }
}
