using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Rema1k.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string Unit { get; set; }

        public int Quanity { get; set; }

        public decimal Price { get; set; }

        [Required]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }
        [JsonIgnore]
        //Needed for the DbSet but not to be seen in the browser
        public virtual Supplier Supplier { get; set; }
        [JsonIgnore]
        //Needed for the DbSet but not to be seen in the browser
        public virtual Category Category { get; set; }
    }
}
