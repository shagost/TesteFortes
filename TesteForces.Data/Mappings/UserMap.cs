﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Domain.Entities;

namespace TesteFortes.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar");
        }
    }
}
