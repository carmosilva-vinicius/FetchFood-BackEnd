using FetchFood.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Data.EntityConfiguration
{
    internal class AddressConfiguration :
        IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(id => id.Id)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Street)
                .IsRequired();
            builder.Property(a => a.Complement)
                .HasMaxLength(70);

            builder.HasOne(address => address.User)
                .WithOne(user => user.Address)
                .HasForeignKey<CustomIdentityUser>(user => user.AddressId);
        }
    }
}
