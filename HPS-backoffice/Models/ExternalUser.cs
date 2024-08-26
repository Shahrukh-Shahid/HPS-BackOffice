using System;
using System.Collections.Generic;

namespace HPS_backoffice.Models;

public partial class ExternalUser
{
    public Guid Id { get; set; }

    public Guid? ExternalUserId { get; set; }

    public Guid? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? GenderCode { get; set; }

    public string? PassportNo { get; set; }

    public string? PassportExpDt { get; set; }

    public string? NationalityCode { get; set; }

    public string? Dob { get; set; }

    public string? MobNo { get; set; }

    public string? Email { get; set; }

    public string? ResCountry { get; set; }

    public string? Duration { get; set; }

    public string? VisitStartDate { get; set; }

    public string? Category { get; set; }

    public string? DocSubType { get; set; }

    public string? DocType { get; set; }

    public string? FanApplicationNumber { get; set; }

    public Guid? HpsApplicationNo { get; set; }

    public string? SrcIndivNum { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? HayaNo { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual HpsCustomer? Customer { get; set; }
}
