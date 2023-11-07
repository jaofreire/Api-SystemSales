using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Model;

namespace SalesSystem.Data.Map
{
    public class ClientMap : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.ProductId);
            builder.Property(x => x.ProductQuantity);

            builder.HasOne(x => x.Product);
        }
    }
}
