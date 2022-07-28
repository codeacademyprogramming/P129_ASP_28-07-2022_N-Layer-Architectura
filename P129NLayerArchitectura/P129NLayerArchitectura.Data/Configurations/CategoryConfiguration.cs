using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P129NLayerArchitectura.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.Name).IsRequired(true).HasMaxLength(25);
            builder.Property(b => b.Image).IsRequired(false).HasMaxLength(255);
        }
    }
}
