using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Truyum.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("MenuItems")]
        public int MenuItemId { get; set; }
        public int UserId { get; set; }
        
        public virtual ICollection<MenuItem> MenuItems { get; set; }

    }
}