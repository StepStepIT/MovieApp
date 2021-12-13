using DLL.Context;
using DLL.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MovieApp
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);
            serviceProvider = service.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MainContext>(x => x.UseSqlServer(ConfigurationManager.ConnectionStrings["MovieAppDb"].ConnectionString));

            services.AddTransient<BookingRepository>();
            services.AddTransient<ChairRepository>();
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<HallRepository>();
            services.AddTransient<LoginRepository>();
            services.AddTransient<MovieRepository>();
            services.AddTransient<SessionRepository>();
    
            services.AddSingleton<MainWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var window = serviceProvider.GetService<MainWindow>();
            window.Show();
        }
    }
}
