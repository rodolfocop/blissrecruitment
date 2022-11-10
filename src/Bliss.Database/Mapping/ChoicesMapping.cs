using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bliss.Domain.Models;

namespace Bliss.Database.Mapping
{
    public class ChoicesMapping : IEntityTypeConfiguration<ChoicesEntity>
    {
        public void Configure(EntityTypeBuilder<ChoicesEntity> builder)
        {
            builder.ToTable("Choices");

            builder
                .Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.IdQuestion)
                .IsRequired()
                .HasColumnName("IdQuestion");

            builder.Property(c => c.Choice)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Choice");

            builder.Property(c => c.Votes)
                .IsRequired()
                .HasColumnName("Votes");

            builder
                .HasOne(bc => bc.Questions)
                .WithMany(c => c.Choises)
                .HasForeignKey(bc => bc.IdQuestion);
        }
    }
}
