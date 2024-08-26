using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HPS_backoffice.Models;

public partial class HPSContext : DbContext
{
    public HPSContext(DbContextOptions<HPSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientServiceAction> ClientServiceActions { get; set; }

    public virtual DbSet<ClientServiceLog> ClientServiceLogs { get; set; }

    public virtual DbSet<ClientServiceOperation> ClientServiceOperations { get; set; }

    public virtual DbSet<ClientSubService> ClientSubServices { get; set; }

    public virtual DbSet<ClientSubServiceDetail> ClientSubServiceDetails { get; set; }

    public virtual DbSet<ClientSubServiceTranslation> ClientSubServiceTranslations { get; set; }

    public virtual DbSet<ClientTranslation> ClientTranslations { get; set; }

    public virtual DbSet<ClientType> ClientTypes { get; set; }

    public virtual DbSet<CustomersLandingPage> CustomersLandingPages { get; set; }

    public virtual DbSet<ExternalUser> ExternalUsers { get; set; }

    public virtual DbSet<GenderCode> GenderCodes { get; set; }

    public virtual DbSet<HpsCustomer> HpsCustomers { get; set; }

    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<NationalityCode> NationalityCodes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceSubService> ServiceSubServices { get; set; }

    public virtual DbSet<SubService> SubServices { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    public virtual DbSet<TransactionStatusCode> TransactionStatusCodes { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<VendorDetail> VendorDetails { get; set; }

    public virtual DbSet<VendorPaymentDetail> VendorPaymentDetails { get; set; }

    public virtual DbSet<VendorResponse> VendorResponses { get; set; }

    public virtual DbSet<VisaServicePostActionLog> VisaServicePostActionLogs { get; set; }

    public virtual DbSet<VisitDurationCode> VisitDurationCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClientServiceAction>(entity =>
        {
            entity.ToTable("client_service_actions");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ActionCode)
                .HasMaxLength(50)
                .HasColumnName("action_code");
            entity.Property(e => e.ActionType)
                .HasMaxLength(150)
                .HasColumnName("action_type");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
        });

        modelBuilder.Entity<ClientServiceLog>(entity =>
        {
            entity.ToTable("client_service_logs");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientServiceId).HasColumnName("client_service_id");
            entity.Property(e => e.ClientServiceOptId).HasColumnName("client_service_opt_id");
            entity.Property(e => e.RequestBody).HasColumnName("request_body");
            entity.Property(e => e.RequestCompleted)
                .HasColumnType("datetime")
                .HasColumnName("request_completed");
            entity.Property(e => e.RequestTime)
                .HasColumnType("datetime")
                .HasColumnName("request_time");
            entity.Property(e => e.ResponseBody).HasColumnName("response_body");

            entity.HasOne(d => d.ClientService).WithMany(p => p.ClientServiceLogs)
                .HasForeignKey(d => d.ClientServiceId)
                .HasConstraintName("FK_client_service_logs_client_sub_service");

            entity.HasOne(d => d.ClientServiceOpt).WithMany(p => p.ClientServiceLogs)
                .HasForeignKey(d => d.ClientServiceOptId)
                .HasConstraintName("FK_client_service_logs_client_service_operations");
        });

        modelBuilder.Entity<ClientServiceOperation>(entity =>
        {
            entity.ToTable("client_service_operations");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.ServiceOperation)
                .HasMaxLength(150)
                .HasColumnName("service_operation");
            entity.Property(e => e.ServiceOperationCode)
                .HasMaxLength(20)
                .HasColumnName("service_operation_code");
        });

        modelBuilder.Entity<ClientSubService>(entity =>
        {
            entity.ToTable("client_sub_service");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientTypeCode)
                .HasMaxLength(60)
                .HasColumnName("client_type_code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.ExternalUse).HasColumnName("external_use");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SubServiceId).HasColumnName("sub_service_id");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientSubServices)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_client_sub_service_client");

            entity.HasOne(d => d.SubService).WithMany(p => p.ClientSubServices)
                .HasForeignKey(d => d.SubServiceId)
                .HasConstraintName("FK_client_sub_service_sub_service");
        });

        modelBuilder.Entity<ClientSubServiceDetail>(entity =>
        {
            entity.ToTable("client_sub_service_details");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientServiceActionId).HasColumnName("client_service_action_id");
            entity.Property(e => e.ClientSubServiceId).HasColumnName("client_sub_service_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.GeneratePolicyUrl)
                .HasMaxLength(250)
                .HasColumnName("generate_policy_url");
            entity.Property(e => e.GetPolicyDetailUrl)
                .HasMaxLength(250)
                .HasColumnName("get_policy_detail_url");
            entity.Property(e => e.GetPolicyReportUrl)
                .HasMaxLength(250)
                .HasColumnName("get_policy_report_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.QuotationUrl)
                .HasMaxLength(250)
                .HasColumnName("quotation_url");

            entity.HasOne(d => d.ClientServiceAction).WithMany(p => p.ClientSubServiceDetails)
                .HasForeignKey(d => d.ClientServiceActionId)
                .HasConstraintName("FK_client_sub_service_details_client_service_actions");

            entity.HasOne(d => d.ClientSubService).WithMany(p => p.ClientSubServiceDetails)
                .HasForeignKey(d => d.ClientSubServiceId)
                .HasConstraintName("FK_client_sub_service_details_client_sub_service");
        });

        modelBuilder.Entity<ClientSubServiceTranslation>(entity =>
        {
            entity.ToTable("client_sub_service_translation");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientSubServiceId).HasColumnName("client_sub_service_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.ClientSubService).WithMany(p => p.ClientSubServiceTranslations)
                .HasForeignKey(d => d.ClientSubServiceId)
                .HasConstraintName("FK_client_sub_service_translation_client_sub_service");

            entity.HasOne(d => d.Language).WithMany(p => p.ClientSubServiceTranslations)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_client_sub_service_translation_languages");
        });

        modelBuilder.Entity<ClientTranslation>(entity =>
        {
            entity.ToTable("client_translation");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientTranslations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_client_translation_client");

            entity.HasOne(d => d.Language).WithMany(p => p.ClientTranslations)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_client_translation_languages");
        });

        modelBuilder.Entity<ClientType>(entity =>
        {
            entity.ToTable("client_types");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClientType1)
                .HasMaxLength(250)
                .HasColumnName("client_type");
            entity.Property(e => e.ClientTypeCode)
                .HasMaxLength(50)
                .HasColumnName("client_type_code");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        modelBuilder.Entity<CustomersLandingPage>(entity =>
        {
            entity.ToTable("customers_landing_pages");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CancelUrl)
                .HasMaxLength(250)
                .HasColumnName("cancel_url");
            entity.Property(e => e.FailureUrl)
                .HasMaxLength(250)
                .HasColumnName("failure_url");
            entity.Property(e => e.HpsCustomerId).HasColumnName("hps_customer_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsPortal).HasColumnName("is_portal");
            entity.Property(e => e.SuccessUrl)
                .HasMaxLength(250)
                .HasColumnName("success_url");

            entity.HasOne(d => d.HpsCustomer).WithMany(p => p.CustomersLandingPages)
                .HasForeignKey(d => d.HpsCustomerId)
                .HasConstraintName("FK_customers_landing_pages_hps_customers");
        });

        modelBuilder.Entity<ExternalUser>(entity =>
        {
            entity.ToTable("external_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(150)
                .HasColumnName("category");
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.Country).HasMaxLength(250);
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .HasColumnName("dob");
            entity.Property(e => e.DocSubType)
                .HasMaxLength(20)
                .HasColumnName("docSubType");
            entity.Property(e => e.DocType)
                .HasMaxLength(20)
                .HasColumnName("doc_type");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .HasColumnName("duration");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.ExternalUserId).HasColumnName("external_user_id");
            entity.Property(e => e.FanApplicationNumber)
                .HasMaxLength(250)
                .HasColumnName("fanApplicationNumber");
            entity.Property(e => e.GenderCode)
                .HasMaxLength(20)
                .HasColumnName("gender_code");
            entity.Property(e => e.HayaNo)
                .HasMaxLength(250)
                .HasColumnName("hayaNo");
            entity.Property(e => e.HpsApplicationNo).HasColumnName("hps_application_no");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(250)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MobNo)
                .HasMaxLength(40)
                .HasColumnName("mob_no");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.NationalityCode)
                .HasMaxLength(50)
                .HasColumnName("nationality_code");
            entity.Property(e => e.PassportExpDt)
                .HasMaxLength(70)
                .HasColumnName("passport_exp_dt");
            entity.Property(e => e.PassportNo)
                .HasMaxLength(250)
                .HasColumnName("passport_no");
            entity.Property(e => e.PostalCode).HasMaxLength(250);
            entity.Property(e => e.ResCountry)
                .HasMaxLength(50)
                .HasColumnName("res_country");
            entity.Property(e => e.SrcIndivNum)
                .HasMaxLength(250)
                .HasColumnName("srcIndivNum");
            entity.Property(e => e.State).HasMaxLength(250);
            entity.Property(e => e.Street).HasMaxLength(250);
            entity.Property(e => e.VisitStartDate)
                .HasMaxLength(50)
                .HasColumnName("visit_start_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.ExternalUsers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_external_user_hps_customers");
        });

        modelBuilder.Entity<GenderCode>(entity =>
        {
            entity.ToTable("gender_codes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        modelBuilder.Entity<HpsCustomer>(entity =>
        {
            entity.ToTable("hps_customers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(250)
                .HasColumnName("customer_name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IncomingRoute).HasColumnName("incoming_route");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.OutgoingRoute).HasColumnName("outgoing_route");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasColumnName("registration_date");
            entity.Property(e => e.SecretKey).HasColumnName("secret_key");
        });

        modelBuilder.Entity<InsuranceType>(entity =>
        {
            entity.ToTable("insurance_types");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Value)
                .HasMaxLength(150)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_languages");

            entity.ToTable("language");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.Language1)
                .HasMaxLength(150)
                .HasColumnName("language");
        });

        modelBuilder.Entity<NationalityCode>(entity =>
        {
            entity.ToTable("nationality_codes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AlphaCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("alpha_code");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(150)
                .HasColumnName("country_code");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("service");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Services)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_service_vendor_details");
        });

        modelBuilder.Entity<ServiceSubService>(entity =>
        {
            entity.ToTable("service_sub_service");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.SubServiceId).HasColumnName("sub_service_id");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceSubServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_service_sub_service_service");

            entity.HasOne(d => d.SubService).WithMany(p => p.ServiceSubServices)
                .HasForeignKey(d => d.SubServiceId)
                .HasConstraintName("FK_service_sub_service_sub_service");
        });

        modelBuilder.Entity<SubService>(entity =>
        {
            entity.ToTable("sub_service");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transaction", tb => tb.HasTrigger("trgAfterUpdateTable_Transaction"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.HayyaTransasctionId).HasColumnName("hayya_transasction_id");
            entity.Property(e => e.HpsCustomerId).HasColumnName("hps_customer_id");
            entity.Property(e => e.IsPortal).HasColumnName("is_portal");
            entity.Property(e => e.PolicyNo)
                .HasMaxLength(250)
                .HasColumnName("policy_no");
            entity.Property(e => e.PromoCode)
                .HasMaxLength(250)
                .HasColumnName("promo_code");
            entity.Property(e => e.QuoteNo)
                .HasMaxLength(250)
                .HasColumnName("quote_no");
            entity.Property(e => e.ResponseTime)
                .HasColumnType("datetime")
                .HasColumnName("response_time");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TransactionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionStatus).HasColumnName("transaction_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.VendorResponseId).HasColumnName("vendor_response_id");

            entity.HasOne(d => d.HpsCustomer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.HpsCustomerId)
                .HasConstraintName("FK_transaction_hps_customers");

            entity.HasOne(d => d.Service).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_transaction_service");

            entity.HasOne(d => d.TransactionStatusNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionStatus)
                .HasConstraintName("FK_transaction_transaction_status_codes");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_transaction_vendor_details");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.ToTable("transaction_details");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ClientSubServiceId).HasColumnName("client_sub_service_id");
            entity.Property(e => e.CompletionTime)
                .HasColumnType("datetime")
                .HasColumnName("completion_time");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(250)
                .HasColumnName("order_no");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.ClientSubService).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.ClientSubServiceId)
                .HasConstraintName("FK_transaction_details_client_sub_service");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_transaction_details_transaction");
        });

        modelBuilder.Entity<TransactionStatusCode>(entity =>
        {
            entity.ToTable("transaction_status_codes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(100)
                .HasColumnName("status_code");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.ToTable("user_details");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsViewer).HasColumnName("is_viewer");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<VendorDetail>(entity =>
        {
            entity.ToTable("vendor_details");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<VendorPaymentDetail>(entity =>
        {
            entity.ToTable("vendor_payment_details");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.PromoCode)
                .HasMaxLength(150)
                .HasColumnName("promo_code");
            entity.Property(e => e.TransactionAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.VendorAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("vendor_amount");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.PaymentStatusNavigation).WithMany(p => p.VendorPaymentDetails)
                .HasForeignKey(d => d.PaymentStatus)
                .HasConstraintName("FK_vendor_payment_details_transaction_status_codes");

            entity.HasOne(d => d.Transaction).WithMany(p => p.VendorPaymentDetails)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_vendor_payment_details_transaction");

            entity.HasOne(d => d.Vendor).WithMany(p => p.VendorPaymentDetails)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_vendor_payment_details_vendor_details");
        });

        modelBuilder.Entity<VendorResponse>(entity =>
        {
            entity.ToTable("vendor_response");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.RequestBody).HasColumnName("request_body");
            entity.Property(e => e.RequestOn)
                .HasColumnType("datetime")
                .HasColumnName("request_on");
            entity.Property(e => e.ResponseBody).HasColumnName("response_body");
            entity.Property(e => e.ResponseTime)
                .HasColumnType("datetime")
                .HasColumnName("response_time");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.VendorResponses)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_vendor_response_transaction");
        });

        modelBuilder.Entity<VisaServicePostActionLog>(entity =>
        {
            entity.ToTable("visa_service_post_action_logs", tb => tb.HasTrigger("trgUpdateTransactionStatus"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CompletionTime)
                .HasColumnType("datetime")
                .HasColumnName("completion_time");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.IsLock).HasColumnName("is_lock");
            entity.Property(e => e.PartiallyUpdateMannai).HasColumnName("partially_update_mannai");
            entity.Property(e => e.PdfDownloaded).HasColumnName("pdf_downloaded");
            entity.Property(e => e.PolicyGenerated).HasColumnName("policy_generated");
            entity.Property(e => e.RequestTime)
                .HasColumnType("datetime")
                .HasColumnName("request_time");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.UpdateMannai).HasColumnName("update_mannai");
            entity.Property(e => e.UpdateMoi).HasColumnName("update_moi");

            entity.HasOne(d => d.Transaction).WithMany(p => p.VisaServicePostActionLogs)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_visa_service_post_action_logs_transaction");
        });

        modelBuilder.Entity<VisitDurationCode>(entity =>
        {
            entity.ToTable("visit_duration_codes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
