using FamiliaControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Repository
{
    public class FamilyControlDbContext : DbContext
    {
        public FamilyControlDbContext(DbContextOptions options) : base(options) { }

        #region DBSets
        public virtual DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var propertie in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties())
                                                                         .Where(p => p.ClrType == typeof(string)))
                propertie.SetColumnType("VARCHAR(100)");

            foreach (var propertie in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties())
                                                                           .Where(p => p.ClrType == typeof(decimal)))
                propertie.SetColumnType("DECIMAL(18, 2)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FamilyControlDbContext).Assembly);

            foreach (var relacao in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relacao.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
