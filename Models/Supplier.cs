using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1k.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool Delivered_before { get; set; }

        public DateTime Last_delivery{ get; set; }

        public int CategoryId { get; set; }
    }
}
