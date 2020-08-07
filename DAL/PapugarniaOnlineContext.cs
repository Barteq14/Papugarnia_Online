using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.DAL
{
    public class PapugarniaOnlineContext :DbContext
    {
        public PapugarniaOnlineContext(DbContextOptions<PapugarniaOnlineContext> options)
          : base(options)
        {
        }
    }
}
