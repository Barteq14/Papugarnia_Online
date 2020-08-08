using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.Models
{
    public class KindOfParrot
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Parrot> Parrots { get; set; }
    }
}
