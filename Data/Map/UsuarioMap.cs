using Microsoft.EntityFrameworkCore;
using PW45S.Models;

namespace PW45S.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(u => u.id);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(255); 
            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        }
    }
}
