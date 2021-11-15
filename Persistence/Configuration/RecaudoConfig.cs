using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class RecaudoConfig : IEntityTypeConfiguration<Recaudo>
    {
        public void Configure(EntityTypeBuilder<Recaudo> builder)
        {
            builder.ToTable("Recaudos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.estacion)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.sentido)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.categoria)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(p => p.fechaRecaudo)
                .IsRequired();

            builder.Property(p => p.hora)
                .IsRequired();

            builder.Property(p => p.valorTabulado)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(30);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(30);


        }
    }
}
