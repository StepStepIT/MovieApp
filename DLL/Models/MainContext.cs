using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    internal class MainContext : DbContext
    {
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LoginData> LoginDatas { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }

        public MainContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(EmployeeConfigure);
            builder.Entity<LoginData>(LoginDataConfigure);
            builder.Entity<Chair>(ChairConfiruge);
            builder.Entity<Movie>(MovieConfigure);
            builder.Entity<Session>(SessionConfigure);
            builder.Entity<Auditorium>(AuditoriumConfigure);
            builder.Entity<Booking>(BookingConfigure);
        }

        public void ChairConfiruge(EntityTypeBuilder<Chair> builder)
        {
            builder.Property(x => x.Row).IsRequired();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.IsBusy).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.Cost).HasDefaultValue(0).IsRequired();

            builder.HasOne(x => x.Auditorium)
                .WithMany(s => s.Chairs)
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();

            builder.HasOne(x => x.Booking)
                .WithMany(x =>x.Chairs)
                .HasForeignKey(x => x.BookingId)
                .IsRequired();
        }

        public void MovieConfigure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Tittle).IsRequired();
            builder.Property(x => x.Genre).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Director).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Duration).HasDefaultValue(new TimeOnly(00,00)).IsRequired();
        }

        public void LoginDataConfigure(EntityTypeBuilder<LoginData> builder)
        {
            builder.Property(x => x.Login).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Password).IsRequired();
        }

        public void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Salary).HasDefaultValue(500).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();

            builder.Property(x => x.WorksFrom)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasOne(x => x.LoginData)
                .WithMany(c => c.Employee)
                .HasForeignKey(x => x.LoginDataId)
                .IsRequired();
        }

        public void SessionConfigure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.DateStart).IsRequired();
            
            builder.HasOne(x => x.Movie)
                .WithMany(s => s.Sessions)
                .HasForeignKey(x => x.MovieId)
                .IsRequired();

            builder.HasOne(x => x.Auditorium)
                .WithMany(s => s.Sessions)
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();
        }

        public void AuditoriumConfigure(EntityTypeBuilder<Auditorium> builder)
        {
            builder.Property(x => x.Number).HasDefaultValue(0).IsRequired();
        }

        public void BookingConfigure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.Date).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.CustomerName).IsRequired();
            builder.Property(x => x.CustomerPhone).IsRequired();
            builder.Property(x => x.isPaid).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.isCanceled).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.TotalPrice).HasDefaultValue(0.0).IsRequired();

            builder.HasOne(x => x.Session)
                .WithMany(s => s.Bookings)
                .HasForeignKey(x => x.SessionId)
                .IsRequired();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.EmployeeId)
                .IsRequired();
        }
    }
}