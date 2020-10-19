using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment.Models
{
    public partial class AssignmentContext : DbContext
    {
        public AssignmentContext()
        {
        }

        public AssignmentContext(DbContextOptions<AssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Mobile> Mobile { get; set; }
        public virtual DbSet<Profit> Profit { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RUPALI\\SQLEXPRESS;Database=Assignment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__7B895117237568CE");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustAddress).HasColumnName("Cust_Address");

                entity.Property(e => e.CustEmailId)
                    .HasColumnName("Cust_EmailId")
                    .HasMaxLength(100);

                entity.Property(e => e.CustMobiile)
                    .HasColumnName("Cust_Mobiile")
                    .HasMaxLength(10);

                entity.Property(e => e.CustName)
                    .HasColumnName("Cust_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.UpatedDate)
                    .HasColumnName("upatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.CraetedDate).HasColumnType("datetime");

                entity.Property(e => e.ImeiNumber)
                    .HasColumnName("IMEI_Number")
                    .HasMaxLength(100);

                entity.Property(e => e.LauchDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Profit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualPrice).HasColumnName("Actual_Price");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Profit1).HasColumnName("Profit");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.SelliingPrice).HasColumnName("Selliing_Price");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.Property(e => e.CraetedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.MobileId).HasColumnName("Mobile_Id");

                entity.Property(e => e.PaymentType).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer_Id");

                entity.HasOne(d => d.Mobile)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.MobileId)
                    .HasConstraintName("FK_Mobile_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
