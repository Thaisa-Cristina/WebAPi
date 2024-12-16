using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiCSharp.Models;

namespace WebApiCSharp.Data.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<EstoqueModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).HasMaxLength(5);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.ProdutoId);

            builder.HasOne(x => x.Produto);
        }
    }
}
