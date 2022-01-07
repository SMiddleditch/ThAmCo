using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class EventContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<GuestBooking> GuestBooking { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Staffing> Staffing { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite Key GuestBooking
            builder.Entity<GuestBooking>()
                .HasKey(g => new { g.CustomerId, g.EventId });

            // Composite Key Staffing
            builder.Entity<Staffing>()
                .HasKey(s => new { s.EventId, s.StaffId });

            // Handle the many to many GuestBooking
            builder.Entity<GuestBooking>()
                .HasOne(gb => gb.Customer)
                .WithMany(gb => gb.GuestBooking)
                .HasForeignKey(gb => gb.CustomerId);

            builder.Entity<GuestBooking>()
                .HasOne(gb => gb.Event)
                .WithMany(gb => gb.GuestBooking)
                .HasForeignKey(gb => gb.EventId);

            // Handle the many to many Staffing
            builder.Entity<Staffing>()
                .HasOne(st => st.Event)
                .WithMany(st => st.Staffing)
                .HasForeignKey(st => st.EventId);

            builder.Entity<Staffing>()
                .HasOne(st => st.Staff)
                .WithMany(st => st.Staffing)
                .HasForeignKey(st => st.StaffId);

            builder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Email = "steHawk@gmail.com", FirstName = "Stephen", LastName = "Hawking", Attendance = true },
                new Customer { CustomerId = 2, Email = "alEinstein@gmail.com", FirstName = "Albert", LastName = "Einstein", Attendance = false },
                new Customer { CustomerId = 3, Email = "carlSa@gmail.com", FirstName = "Carl", LastName = "Sagan", Attendance = true }
                );

            builder.Entity<GuestBooking>().HasData(
                new GuestBooking { CustomerId = 1, EventId = 1},
                new GuestBooking { CustomerId = 2, EventId = 2 },
                new GuestBooking { CustomerId = 3, EventId = 3 }
                );

            builder.Entity<Event>().HasData(
                new Event { EventId = 1, EventTitle = "Wedding", EventType = "Party", DateTime = new DateTime (2021, 04, 20) },
                new Event { EventId = 2, EventTitle = "Birthday", EventType = "Party", DateTime = new DateTime(2019, 10, 06) },
                new Event { EventId = 3, EventTitle = "Funeral", EventType = "Party", DateTime = new DateTime(2018, 01, 09) }
                );

            builder.Entity<Staffing>().HasData(
                new Staffing { EventId = 1, StaffId = 1},
                new Staffing { EventId = 2, StaffId = 2},
                new Staffing { EventId = 3, StaffId = 3}
                );

            builder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, Email = "JJ@gmail.com", FirstName = "Jack", LastName = "Johnson", JobType = "Chef", FirstAid = true },
                new Staff { StaffId = 2, Email = "SH@gmail.com", FirstName = "Sarah", LastName = "Hawking", JobType = "Server", FirstAid = false },
                new Staff { StaffId = 3, Email = "PW@gmail.com", FirstName = "Paul", LastName = "Walker", JobType = "Cleaner", FirstAid = false }
                );
        }


    }
}