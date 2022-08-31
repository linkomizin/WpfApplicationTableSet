using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFLibrary.EF
{
    public partial class ModelEntityes : DbContext
    {
        public ModelEntityes()
            : base("name=ModelEntityes")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasOptional(e => e.Clients)
                .WithRequired(e => e.People);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Rooms)
                .HasForeignKey(e => e.Room_RoomId);
        }
    }
}
