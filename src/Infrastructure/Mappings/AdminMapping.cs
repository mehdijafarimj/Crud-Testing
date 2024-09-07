using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings;
public class AdminMapping : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(i => i.Id);


        builder.Property(i => i.Name)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(i => i.LastName)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(i => i.UserName)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(a => a.Age)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(i => i.Password)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(e => e.Email)
            .HasMaxLength(30)
            .IsRequired();


        builder.Property(a => a.Address)
            .HasMaxLength(50)
            .IsRequired();
    }
}
