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
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
            builder.Property(item => item.Name).IsRequired().HasMaxLength(150);
            builder.Property(item => item.Description).IsRequired();
            builder.Property(item => item.ImagePath).IsRequired();
            builder.Property(item => item.Price).IsRequired().HasPrecision(2);
        }
    }
}
