using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using FInalProject1.Models;

namespace FInalProject1.DAL
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext() : base("FinalProjectContext") { }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<ContactInfo> ContactInfoList { get; set; }
        public DbSet<Education> EducationList { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Developer>()
                        .HasMany(d => d.Skills)
                        .WithMany(s => s.Developers)
                        .Map(ds => ds.MapLeftKey("DeveloperID")
                        .MapRightKey("ID")
                        .ToTable("Developers_Skills"));
        }
    }
}