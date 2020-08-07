using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.Models
{
    public class Parrot
    {
        [Key]
        [Required]
        public int ID { get; set; }
    
        [Required]
        [Range(1,99)]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(9999999)]
        public string TypeDescription { get; set; }
        
        public int KindID { get; set; }
        [ForeignKey("KindID")]
        public virtual KindOfParrot KindOfParrot { get; set; }

    }
}
