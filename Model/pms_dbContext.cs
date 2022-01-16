using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pms_api.Model
{
    public partial class pms_dbContext : DbContext
    {
        //public pms_dbContext()
        //{
        //}

        public pms_dbContext(DbContextOptions<pms_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblCall> TblCalls { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblLead> TblLeads { get; set; }
        public virtual DbSet<TblLeadStatu> TblLeadStatus { get; set; }
        public virtual DbSet<TblMember> TblMembers { get; set; }
        public virtual DbSet<TblNote> TblNotes { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblSource> TblSources { get; set; }
        public virtual DbSet<TblTeam> TblTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=pms_db;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("tbl_accounts");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblCall>(entity =>
            {
                entity.HasKey(e => e.CallId);

                entity.ToTable("tbl_calls");

                entity.Property(e => e.CallId).HasColumnName("call_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CallDate)
                    .HasColumnName("call_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CallType)
                    .IsRequired()
                    .HasColumnName("call_type")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblCalls)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_calls_tbl_accounts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblCalls)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_calls_tbl_members");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblCalls)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_calls_tbl_leads");
            });

            modelBuilder.Entity<TblContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("tbl_contacts");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasMaxLength(50);

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobile_no")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblContacts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_tbl_contacts_tbl_accounts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblContacts)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_contacts_tbl_members");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblContacts)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK_tbl_contacts_tbl_leads");
            });

            modelBuilder.Entity<TblLead>(entity =>
            {
                entity.HasKey(e => e.LeadId);

                entity.ToTable("tbl_leads");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasMaxLength(50);

                entity.Property(e => e.InterestedIn).HasColumnName("interested_in");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .HasColumnName("pincode")
                    .HasMaxLength(6);

                entity.Property(e => e.SourceId).HasColumnName("source_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblLeads)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_leads_tbl_accounts");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.TblLeadAssignedToNavigations)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_tbl_leads_tbl_members_assigned");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblLeadCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_leads_tbl_members_createdby");

                entity.HasOne(d => d.InterestedInNavigation)
                    .WithMany(p => p.TblLeads)
                    .HasForeignKey(d => d.InterestedIn)
                    .HasConstraintName("FK_tbl_leads_tbl_products");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.TblLeads)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_tbl_leads_tbl_sources");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.TblLeads)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_tbl_leads_tbl_lead_status");
            });

            modelBuilder.Entity<TblLeadStatu>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_tbl_status");

                entity.ToTable("tbl_lead_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblLeadStatus)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_status_tbl_accounts");
            });

            modelBuilder.Entity<TblMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbl_members");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("email_id")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblMembers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_members_tbl_accounts");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TblMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_members_tbl_teams");
            });

            modelBuilder.Entity<TblNote>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.ToTable("tbl_notes");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblNotes)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_tbl_notes_tbl_accounts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblNotes)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_notes_tbl_members");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.TblNotes)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK_tbl_notes_tbl_leads");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_tbl_products_1");

                entity.ToTable("tbl_products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_products_tbl_accounts");
            });

            modelBuilder.Entity<TblSource>(entity =>
            {
                entity.HasKey(e => e.SourceId);

                entity.ToTable("tbl_sources");

                entity.Property(e => e.SourceId).HasColumnName("source_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblSources)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_sources_tbl_accounts");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("tbl_teams");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modified_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblTeams)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_teams_tbl_accounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
