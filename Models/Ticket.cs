using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string TicketName  { get; set; }
        [Required]
        [Range(1,99)]
        public int Price { get; set; }

        public int KindID { get; set; }
        [ForeignKey("KindID")]
        public virtual  KindOfTicket KindOfTicket { get; set; }

    }
}
