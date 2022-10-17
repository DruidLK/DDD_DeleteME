using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RichDomainModel.Domain.Enums;
using RichDomainModel.Domain.VOs;

namespace RichDomainModel.Domain
{
    public sealed class PaymentRequest
    {
        private List<RequestStatus> statusHistory = new List<RequestStatus>();

        //for EFCore
        private PaymentRequest()
        { }

        public int Id { get; private set; }
        public string IBAN { get; private set; }
        public RequestStatus CurrentStatus { get; private set; }
        public IReadOnlyCollection<RequestStatus> StatusHistory
        {
            get => this.statusHistory;
            private set => this.statusHistory = (List<RequestStatus>)value;
        }

        //replacment more better
        //private List<Person> _parents = new List<Person>();
        //public IReadOnlyCollection<Person> Parents => _parents.AsReadOnly();
        //public void AddParent(Parent parent) =>
        //    _parents.Add(parent);
        public Money Amount { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        public PaymentRequest(
            string iBAN,
            RequestStatus currentStatus,
            Money amount,
            string createdBy,
            string updatedBy,
            DateTime createdDate,
            DateTime updatedDate)
        {
            this.IBAN = iBAN;
            this.statusHistory.Add(currentStatus);
            this.CurrentStatus = this.StatusHistory.Last();
            this.Amount = amount;
            this.CreatedBy = createdBy;
            this.UpdatedBy = updatedBy;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;
        }

        public void SubmitPaymentRequest(DateTime currentDateTime, string userName)
        {
            this.statusHistory.Add(new RequestStatus
            {
                Status = StatusType.Submitted,
                StatusSetDate = currentDateTime
            });

            this.CurrentStatus = this.StatusHistory.Last();
            this.UpdatedDate = currentDateTime;
            this.UpdatedBy = userName;
        }

        public void WaitingAuth(DateTime currentDateTime, string userName)
        {
            this.statusHistory.Add(new RequestStatus
            {
                Status = StatusType.WaitingAuth,
                StatusSetDate = currentDateTime
            });

            this.CurrentStatus = this.StatusHistory.Last();
            this.UpdatedDate = currentDateTime;
            this.UpdatedBy = userName;
        }

        public void AddStatusHistory(RequestStatus requestStatus)
        {
            // Validate that the status can be added
            this.statusHistory.Add(requestStatus);
        }

        public static Expression<Func<PaymentRequest, ICollection<RequestStatus>>> StatusMapping
        {
            get { return c => c.statusHistory; }
        }
    }
}
