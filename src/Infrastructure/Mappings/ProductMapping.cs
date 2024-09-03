using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings;
public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(a => a.Admin)
            .WithMany(i => i.Products)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        
        builder.HasKey(i => i.Id);


        builder.Property(i => i.Name)
            .HasMaxLength(20)
            .IsRequired();


        builder.Property(i => i.Price)
            .HasMaxLength(20)
            .IsRequired();  


        builder.Property(i => i.Description)
            .HasMaxLength(200)
            .IsRequired();

    }
}
