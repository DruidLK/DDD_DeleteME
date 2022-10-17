using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomainModel.Domain;

namespace RichDomainModel.Brokers
{
    public sealed class PaymentRequestConfiguration : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> builder)
        {
            builder.ToTable(name: nameof(PaymentRequest), schema: nameof(PaymentRequest));
            builder.HasKey(paymentRequest => paymentRequest.Id);
            builder.Property(paymentRequest => paymentRequest.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(paymentRequest => paymentRequest.IBAN).HasMaxLength(30).IsRequired();

            builder.OwnsOne(paymentRequest => paymentRequest.CurrentStatus, currentStatus =>
            {
                currentStatus.Property(status => status.Status).HasColumnName(nameof(PaymentRequest.CurrentStatus.Status));
                currentStatus.Property(status => status.StatusSetDate).HasColumnName(nameof(PaymentRequest.CurrentStatus.StatusSetDate));
            });

            builder.OwnsOne(paymentRequest => paymentRequest.Amount, Amount =>
            {
                Amount.Property(amount => amount.value).HasColumnName(nameof(PaymentRequest.Amount));
            });

            builder.Property(paymentRequest => paymentRequest.CreatedBy).HasMaxLength(150).IsRequired();
            builder.Property(paymentRequest => paymentRequest.UpdatedBy).HasMaxLength(150).IsRequired();
            builder.Property(paymentRequest => paymentRequest.CreatedDate).IsRequired();
            builder.Property(paymentRequest => paymentRequest.UpdatedDate).IsRequired();
        }
    }
}
