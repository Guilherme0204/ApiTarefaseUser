using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        
            public void Configure(EntityTypeBuilder<TarefaModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
                builder.Property(x => x.Descricao).HasMaxLength(1280);
                builder.Property(x => x.Status).IsRequired().HasMaxLength(128);

            }
        
    }
}
