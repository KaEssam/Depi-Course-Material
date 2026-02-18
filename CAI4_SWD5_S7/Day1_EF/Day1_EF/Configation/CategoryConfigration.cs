using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_EF.Configation
{
    internal class CategoryConfigration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category");
            entity.HasKey(c => c.CategoryCode);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
        }

    }
}
