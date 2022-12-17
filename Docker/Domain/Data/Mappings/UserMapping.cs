using Domain.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Mappings
{
    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User", "App");

            entity.HasKey(x => x.Id).HasName("PK_USER");

            entity.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            entity.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasMaxLength(120);

            entity.Property(x => x.Surname)
                .IsRequired()
                .HasColumnName("SURNAME")
                .HasMaxLength(120);

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CREATED_AT")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IS_ACTIVE")
                .HasDefaultValue(true);
        }
    }
}
