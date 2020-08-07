using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.Models
{
    public class KindOfParrot
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parrot> Parrots { get; set; }
    }
}
