﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheraLang.DLL.Piranha.Entities;

namespace TheraLang.DLL.Piranha.Configuration
{
    public class PiranhaAliasConfiguration : IEntityTypeConfiguration<PiranhaAlias>
    {
        public void Configure(EntityTypeBuilder<PiranhaAlias> builder)
        {
            builder.ToTable("Piranha_Aliases");

            builder.HasIndex(e => new {e.SiteId, e.AliasUrl})
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.AliasUrl)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.RedirectUrl)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(d => d.Site)
                .WithMany(p => p.PiranhaAliases)
                .HasForeignKey(d => d.SiteId);
        }
    }
}