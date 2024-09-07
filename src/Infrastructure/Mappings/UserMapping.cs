using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings;
public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(a => a.Admin)
            .WithMany(i => i.Users)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        
        builder.HasKey(i => i.Id);


        builder.Property(i => i.Name)
        .HasMaxLength(50)
        .IsRequired();


        builder.Property(i => i.LastName)
        .HasMaxLength(50)
        .IsRequired();


        builder.Property(a => a.Age)
        .HasMaxLength(10)
        .IsRequired();


        builder.Property(a => a.Address)
        .HasMaxLength(50)
        .IsRequired();


        builder.Property(i => i.NationalCode)
        .HasMaxLength(20)
        .IsRequired();
    }
}
