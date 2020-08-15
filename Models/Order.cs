using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateTime { get; set; }
        [Required]
        [MaxLength(55)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string TicketName { get; set; }
        [Required]
        public double Price { get; set; }


    }
}
