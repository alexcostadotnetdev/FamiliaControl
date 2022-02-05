using FamiliaControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Repository.ModelsConfiguration
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Password)
                   .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Login)
                   .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Email)
                   .HasColumnType("VARCHAR(200)");

            builder.HasData(new User
            {
                Id = Guid.Parse("296EDA1B-E034-4CA2-A6FA-CF8750333CFD"),
                Create = DateTime.Now,
                Email = "admin@admin.com.br",
                Active = true,
                Login = "admin",                
                Password = "VIC1w0W0KioIAWVdSknoeQ==" //admin123@
            });
        }
    }
}
