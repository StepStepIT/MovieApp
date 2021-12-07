using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLL.Models
{
    public class MainContext : DbContext
    {
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LoginData> LoginDatas { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(EmployeeConfigure);
            builder.Entity<LoginData>(LoginDataConfigure);
            builder.Entity<Movie>(MovieConfigure);
            builder.Entity<Session>(SessionConfigure);
            builder.Entity<Hall>(AuditoriumConfigure);
            builder.Entity<Booking>(BookingConfigure);
            builder.Entity<Chair>(ChairConfiruge);

            builder.Entity<LoginData>().HasData(new LoginData { Id = 1, Login = "Login", Password = "Pass", EmployeeId = 1 });
            builder.Entity<Employee>().HasData(new Employee { Id = 1, Birthday = DateTime.Now, Name = "Stepan", Surname = "Stetsko", Role = "Employee"});     
            builder.Entity<Session>().HasData(new Session { Id = 1, HallId = 1, DateStart = DateTime.Now, MovieId = 1});
            builder.Entity<Hall>().HasData(new Hall { Id = 1, Number = 1,});
            builder.Entity<Chair>().HasData(new Chair { Id = 1, HallId = 1, BookingId = 1, Cost = 100, Number = 1, Row = 1 });

            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Description = "Nice movie",
                Director = "C. Nolan",
                Duration = new TimeSpan(1,30,00),
                Genre = "Nice",
                Tittle = "Movie"
            });
            builder.Entity<Booking>().HasData(new Booking
            {
                Id = 1,
                SessionId = 1,
                CustomerName = "Customer",
                CustomerPhone = "Phone",
                EmployeeId = 1,

            });
        }
   
        public void MovieConfigure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Tittle).IsRequired();
            builder.Property(x => x.Genre).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Director).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Duration).HasDefaultValue(new TimeSpan(0,0,0)).IsRequired();
        }

        public void LoginDataConfigure(EntityTypeBuilder<LoginData> builder)
        {
            builder.Property(x => x.Login).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder.HasOne(x => x.Employee)
                .WithOne(s => s.LoginData)
                .HasForeignKey<LoginData>(x => x.EmployeeId);
             
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

            /*builder.HasOne(x => x.LoginData)
                .WithOne(c => c.Employee)
                .HasForeignKey<Employee>(x => x.LoginDataId)
                .IsRequired()*/;
        }

        public void SessionConfigure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.DateStart).IsRequired();

            builder.HasOne(x => x.Movie)
                .WithMany(s => s.Sessions)
                .HasForeignKey(x => x.MovieId)
                .IsRequired();

            builder.HasOne(x => x.Hall)
                .WithMany(s => s.Sessions)
                .HasForeignKey(x => x.HallId)
                .IsRequired();
        }

        public void AuditoriumConfigure(EntityTypeBuilder<Hall> builder)
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
        public void ChairConfiruge(EntityTypeBuilder<Chair> builder)
        {
            builder.Property(x => x.IsBusy).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.Cost).HasDefaultValue(0).IsRequired();

            builder.HasOne(x => x.Hall)
                .WithMany(s => s.Chairs)
                .HasForeignKey(x => x.HallId)
                .IsRequired();

            builder.HasOne(x => x.Booking)
                .WithOne(x => x.Chair)
                .HasForeignKey<Chair>(x => x.BookingId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}