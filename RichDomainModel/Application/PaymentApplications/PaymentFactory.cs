using System;
using RichDomainModel.Domain;
using RichDomainModel.Domain.Enums;
using RichDomainModel.Domain.VOs;

namespace RichDomainModel.Application.PaymentApplications
{
    public static class PaymentFactory
    {
        public static PaymentRequest CreatePayment(string IBAN, decimal amount, string currentUser, DateTime currentDateTime) =>
            new PaymentRequest(
                IBAN,
                new RequestStatus
                {
                    Status = StatusType.New,
                    StatusSetDate = currentDateTime
                },
                new Money(amount),
                currentUser,
                currentUser,
                currentDateTime,
                currentDateTime);
    }
}
