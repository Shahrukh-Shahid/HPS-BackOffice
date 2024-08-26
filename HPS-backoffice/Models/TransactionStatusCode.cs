using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class TransactionStatusCode
{
    public Guid Id { get; set; }

    public string? StatusCode { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<VendorPaymentDetail> VendorPaymentDetails { get; set; } = new List<VendorPaymentDetail>();
}
