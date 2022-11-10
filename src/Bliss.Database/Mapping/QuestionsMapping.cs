using Bliss.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bliss.Database.Mapping
{
    public class QuestionsMapping : IEntityTypeConfiguration<QuestionsEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionsEntity> builder)
        {
            builder.ToTable("Questions");

            builder
               .Property(c => c.Id)
               .IsRequired()
               .HasColumnName("Id");

            builder
               .Property(c => c.ImageUrl)
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnName("ImageUrl");

            builder
               .Property(c => c.ThumbUrl)
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnName("ThumbUrl");

            builder
               .Property(c => c.Question)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnName("Question");

            builder
               .Property(c => c.PublishedAt)
               .IsRequired()
               .HasColumnName("PublishedAt");
        }
    }
}
