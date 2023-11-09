using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Model;

namespace SalesSystem.Data.Map
{
    public class RequestsFinaledsMap : IEntityTypeConfiguration<RequestsFinaledsModel>
    {
        public void Configure(EntityTypeBuilder<RequestsFinaledsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductPrice).IsRequired();
            builder.Property(x => x.ProductQuantity).IsRequired();
            builder.Property(x => x.TotalValue);
        }
    }
}
