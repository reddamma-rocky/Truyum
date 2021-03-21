using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Truyum.Models
{
    public class MenuItem
    {
        [Key]
        public long id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public bool active { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime dateOfLaunch { get; set; }
        [Required]
        public String category { get; set; }
        [Required]
        public bool freeDelivery { get; set; }

        public virtual Cart Carts { get; set; }

    }
}