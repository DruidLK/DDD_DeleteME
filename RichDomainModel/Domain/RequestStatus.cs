using System;
using RichDomainModel.Domain.Enums;

namespace RichDomainModel.Domain
{
    public sealed class RequestStatus
    {
        public StatusType Status { get; set; }
        public DateTime StatusSetDate { get; set; }
    }
}
