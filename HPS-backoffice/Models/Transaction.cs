using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public int TransactionId { get; set; }

    public Guid? ServiceId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? VendorId { get; set; }

    public Guid? HayyaTransasctionId { get; set; }

    public string? QuoteNo { get; set; }

    public string? PolicyNo { get; set; }

    public decimal? Amount { get; set; }

    public Guid? TransactionStatus { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ResponseTime { get; set; }

    public string? VendorResponseId { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? PromoCode { get; set; }

    public Guid? HpsCustomerId { get; set; }

    public bool? IsPortal { get; set; }

    public virtual HpsCustomer? HpsCustomer { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();

    public virtual TransactionStatusCode? TransactionStatusNavigation { get; set; }

    public virtual VendorDetail? Vendor { get; set; }

    public virtual ICollection<VendorPaymentDetail> VendorPaymentDetails { get; set; } = new List<VendorPaymentDetail>();

    public virtual ICollection<VendorResponse> VendorResponses { get; set; } = new List<VendorResponse>();

    public virtual ICollection<VisaServicePostActionLog> VisaServicePostActionLogs { get; set; } = new List<VisaServicePostActionLog>();
}
