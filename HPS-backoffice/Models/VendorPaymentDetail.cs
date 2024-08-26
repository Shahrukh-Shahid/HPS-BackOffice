using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class VendorPaymentDetail
{
    public Guid Id { get; set; }

    public Guid? VendorId { get; set; }

    public Guid? TransactionId { get; set; }

    public decimal? TransactionAmount { get; set; }

    public decimal? VendorAmount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public DateTime? DueDate { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? PromoCode { get; set; }

    public Guid? PaymentStatus { get; set; }

    public virtual TransactionStatusCode? PaymentStatusNavigation { get; set; }

    public virtual Transaction? Transaction { get; set; }

    public virtual VendorDetail? Vendor { get; set; }
}
