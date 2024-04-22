using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteAPI.Data.Map
{
    public class LogradouroMap : IEntityTypeConfiguration<LogradouroModel>
    {
        public void Configure(EntityTypeBuilder<LogradouroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
        }
    }
}
