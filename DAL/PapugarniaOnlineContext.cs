using Microsoft.EntityFrameworkCore;
using PapugarniaOnline.Models;
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

        public DbSet<Parrot> Parrots { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<KindOfParrot> KindOfParrots { get; set; }
        public DbSet<KindOfTicket> KindOfTickets { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parrot>().ToTable("Parrots");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Profile>().ToTable("Profiles");
            modelBuilder.Entity<KindOfParrot>().ToTable("KindOfParrots");
            modelBuilder.Entity<KindOfTicket>().ToTable("KindOfTickets");
            modelBuilder.Entity<Order>().ToTable("Orders");
        }
    }
}
