using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.StockManagement.Domain.Entities;

namespace Senac.StockManagement.Infrastructure.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .HasColumnType("serial4")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("nome")
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasColumnName("email")
            .HasMaxLength(150);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasColumnName("senha_hash")
            .HasMaxLength(255);

        builder.Property(u => u.Active)
            .HasColumnType("boolean")
            .HasColumnName("ativo")
            .HasDefaultValue(true);

        builder.Property(u => u.CreatedAt)
            .HasColumnType("timestamp")
            .HasColumnName("criado_em")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.UpdatedAt)
            .HasColumnType("timestamp")
            .HasColumnName("atualizado_em")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Índice único para email
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_usuarios_email");

        builder.ToTable("usuarios", schema: "public");
    }
}