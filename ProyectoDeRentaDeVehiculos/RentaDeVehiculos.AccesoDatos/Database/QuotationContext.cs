using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.AccesoDatos;

public partial class QuotationContext : DbContext
{
    public QuotationContext()
    {
    }

    public QuotationContext(DbContextOptions<QuotationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<PersonalDatum> PersonalData { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-0D8GGCM\\SQLEXPRESS;Database=RentalRR;User Id=sa;Password=1234;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07DA4C4880");

            entity.HasIndex(e => e.UserId, "UQ__Customer__1788CC4D343F95CA").IsUnique();

            entity.HasIndex(e => e.PersonalDataId, "UQ__Customer__B17C3A25ECC63002").IsUnique();

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.PersonalData).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.PersonalDataId)
                .HasConstraintName("FK__Customers__Perso__60A75C0F");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK__Customers__UserI__5FB337D6");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0726BF5139");

            entity.HasIndex(e => e.UserId, "UQ__Employee__1788CC4D23CA9440").IsUnique();

            entity.HasIndex(e => e.PersonalDataId, "UQ__Employee__B17C3A25F4291F88").IsUnique();

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.PersonalData).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.PersonalDataId)
                .HasConstraintName("FK__Employees__Perso__59FA5E80");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employees__RoleI__59063A47");

            entity.HasOne(d => d.User).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.UserId)
                .HasConstraintName("FK__Employees__UserI__5812160E");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07CC25D6CA");

            entity.ToTable("Inventory");

            entity.HasIndex(e => e.VehicleId, "UQ__Inventor__476B5493DEB98F8C").IsUnique();

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VehicleStatus)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Vehicle).WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(d => d.VehicleId)
                .HasConstraintName("FK__Inventory__Vehic__68487DD7");
        });

        modelBuilder.Entity<PersonalDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC07DE1540C1");

            entity.HasIndex(e => e.Email, "UQ__Personal__A9D105341EEA8B7E").IsUnique();

            entity.HasIndex(e => e.Dui, "UQ__Personal__C0317D911D0F639F").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dui)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rentals__3214EC07708A599F");

            entity.Property(e => e.FinalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RentalDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartMileage).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Rentals__Custome__6C190EBB");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Rentals__Vehicle__6D0D32F4");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07CD32C963");

            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reservati__Custo__70DDC3D8");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Reservati__Vehic__71D1E811");
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Returns__3214EC0759BEA37B");

            entity.HasIndex(e => e.RentalId, "UQ__Returns__97005942DC242829").IsUnique();

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReturnMileage).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Rental).WithOne(p => p.Return)
                .HasForeignKey<Return>(d => d.RentalId)
                .HasConstraintName("FK__Returns__RentalI__76969D2E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC075F8FF129");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F6B1FCE7E8").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E2EED870");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4831332C1").IsUnique();

            entity.HasIndex(e => e.PersonalDataId, "UQ__Users__B17C3A256A9C3AA5").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonalData).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.PersonalDataId)
                .HasConstraintName("FK__Users__PersonalD__4F7CD00D");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicles__3214EC07F3A5DF40");

            entity.HasIndex(e => e.LicensePlate, "UQ__Vehicles__026BC15C0E016531").IsUnique();

            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
