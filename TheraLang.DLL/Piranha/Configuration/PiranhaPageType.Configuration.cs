﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheraLang.DLL.Piranha.Entities;

namespace TheraLang.DLL.Piranha.Configuration
{
    public class PiranhaPageTypeConfiguration : IEntityTypeConfiguration<PiranhaPageType>
    {
        public void Configure(EntityTypeBuilder<PiranhaPageType> builder)
        {
            builder.ToTable("Piranha_PageTypes");

            builder.Property(e => e.Id).HasMaxLength(64);

            builder.Property(e => e.ClrType)
                .HasColumnName("CLRType")
                .HasMaxLength(256);
        }
    }
}