using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DLLTests
{
    public class ContextTest
    {
        private MainContext context;
        public ContextTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDbTest;Integrated Security=True;Connect Timeout=30;").Options;
            context = new MainContext(options);
        }

        [Fact]
        public void CreateDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDbTest;Integrated Security=True;Connect Timeout=30;").Options;

            try
            {
                var db = new MainContext(options);
                Assert.NotNull(db);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddMovieTest()
        {
            var sessionTemp = new Session
            {
                DateStart = DateTime.Now,
                Hall = new Hall(),
                Movie = new Movie(),
                Bookings = new List<Booking>()
            };
            var sessionTemp2 = new Session
            {
                DateStart = DateTime.Now,
                Hall = new Hall(),
                Movie = new Movie(),
                Bookings = new List<Booking>()
            };
            var sessionTemp3 = new Session
            {
                DateStart = DateTime.Now,
                Hall = new Hall(),
                Movie = new Movie(),
                Bookings = new List<Booking>()
            };
            var sessionTemp4 = new Session
            {
                DateStart = DateTime.Now,
                Hall = new Hall(),
                Movie = new Movie(),
                Bookings = new List<Booking>()
            };

            context.Movies.Add(new Movie
            {
                Tittle = "Ultimate epic movie",
                Description = "Very nice movie",
                Director = "Talented",
                Duration = new TimeSpan(1, 30, 00),
                Genre = "EpiC",
                Sessions = new List<Session> { sessionTemp, sessionTemp2 }
            });

            context.Movies.Add(new Movie
            {
                Tittle = "Ultimate epic movie 2",
                Description = "Very nice movie2",
                Director = "Talented",
                Duration = new TimeSpan(1, 30, 00),
                Genre = "EpiC2",
                Sessions = new List<Session> { sessionTemp3, sessionTemp4 }
            });

            context.SaveChanges();

            var movie = context.Movies.First(x => x.Tittle == "Ultimate epic movie");
            Assert.NotNull(movie);
        }

        [Fact]
        public void AddEmployeeTest()
        {
            context.Employees.Add(new Employee
            {
                Birthday = DateTime.Now,
                Bookings = new List<Booking>(),
                Name = "Stopka",
                Surname = "Stetsko",
                Role = "Admin",
                LoginData = new LoginData { Login = "Log", Password = "pass" }
            });

            context.SaveChanges();

            var employee = context.Employees.First(x => x.Name == "Stopka");
            Assert.NotNull(employee);
        }

        [Fact]
        public void AddLoginDataTest()
        {
            var emplTemp = new Employee
            {
                Birthday = DateTime.Now,
                Bookings = new List<Booking>(),
                Name = "Stepka",
                Surname = "Stetsko",
                Role = "Admin"
            };

            context.LoginDatas.Add(new LoginData
            {
                Login = "LoginTest",
                Password = "Password",
                Employee = emplTemp
            });

            context.SaveChanges();

            var loginData = context.LoginDatas.First(x => x.Login == "LoginTest");
            Assert.NotNull(loginData);
        }

          [Fact]
          public void AddChairTest()
          {
            var chairTemp = new Chair
            {
                Booking = new Booking
                {
                    //Chair = new Chair() { Hall = new Hall { Number = 554 } },
                    CustomerName = "Customer1",
                    CustomerPhone = "Curtomer phone1",
                    Employee = new Employee
                    {
                        Birthday = DateTime.Now,
                        Bookings = new List<Booking>(),
                        Name = "StopkaBooking",
                        Surname = "Stetsko",
                        Role = "Admin",
                        LoginData = new LoginData { Login = "Log", Password = "pass" }
                    },
                    Session = new Session
                    {
                        Bookings = new List<Booking>(),
                        Movie = new Movie
                        {
                            Tittle = "Ultimate epic movie 3",
                            Description = "Very nice movie3",
                            Director = "Talented",
                            Duration = new TimeSpan(1, 30, 00),
                            Genre = "EpiC2"
                        },
                        Hall = new Hall { Number = 54 },
                        DateStart = DateTime.Now
                    },

                },
                Hall = new Hall(),
                Number = 34,
                Row = 534

            };

              context.Chairs.Add(chairTemp);
              context.SaveChanges();

              var chair = context.Chairs.First(x => x.Number == 34);
              Assert.NotNull(chair);
          }
        [Fact]
        public void AddHallTest()
        {
            context.Halls.Add(new Hall
            {
                Chairs = new List<Chair> { },
                Number = 3,
                Sessions = new List<Session> { new Session { Movie = new Movie
                {
                    Tittle = "Ultimate epic movie",
                    Description = "Very nice movie",
                    Director = "Talented",
                    Duration = new TimeSpan(1, 30, 00),
                    Genre = "EpiC",
                }, Bookings = new List<Booking>() } }
            });
            context.SaveChanges();

            var hall = context.Halls.First(x => x.Number == 3);
            Assert.NotNull(hall);
        }
        [Fact]
        public void AddSessionTest()
        {
            var sessionTemp = new Session
            {
                Bookings = new List<Booking>(),
                Movie = new Movie
                {
                    Tittle = "Ultimate epic movie 2",
                    Description = "Very nice movie2",
                    Director = "Talented",
                    Duration = new TimeSpan(1, 30, 00),
                    Genre = "EpiC2"
                },
                Hall = new Hall(),
                DateStart = DateTime.Now
            };

            context.Add(sessionTemp);
            context.SaveChanges();

            var session = context.Sessions.First(x => x.DateStart == sessionTemp.DateStart);
            Assert.NotNull(session);
        }
        [Fact]
        public void AddBookingTest()
        {
            var bookingTemp = new Booking
            {
                Chair = new Chair() { Hall = new Hall { Number = 554 } },
                CustomerName = "Customer1",
                CustomerPhone = "Curtomer phone1",
                Employee = new Employee
                {
                    Birthday = DateTime.Now,
                    Bookings = new List<Booking>(),
                    Name = "StopkaBooking",
                    Surname = "Stetsko",
                    Role = "Admin",
                    LoginData = new LoginData { Login = "Log", Password = "pass" }
                },
                Session = new Session
                {
                    Bookings = new List<Booking>(),
                    Movie = new Movie
                    {
                        Tittle = "Ultimate epic movie 3",
                        Description = "Very nice movie3",
                        Director = "Talented",
                        Duration = new TimeSpan(1, 30, 00),
                        Genre = "EpiC2"
                    },
                    Hall = new Hall { Number = 54},
                    DateStart = DateTime.Now
                },
            };

            context.Bookings.Add(bookingTemp);
            context.SaveChanges();

            var booking = context.Bookings.First(x => x.CustomerName == "Customer1");
            Assert.NotNull(booking);
        }
    }
}
