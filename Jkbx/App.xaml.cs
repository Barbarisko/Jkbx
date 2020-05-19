using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;


namespace Jkbx
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceCollection.BuildServiceProvider();

            var viewModel = new MainViewModel(ServiceProvider.GetService<IMachineService>());

            var mainWindow = new MainWindow() { DataContext = viewModel };

            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<JukeBoxDBContext>(opt =>
                opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JukeboxDB;Trusted_Connection=True;"));

            services.AddTransient(typeof(MainWindow));

            services.AddScoped<IAlbumRepo, AlbumRepository>();
            services.AddScoped<IMachineRepo, MachineRepository>();
            services.AddScoped<ISongRepo, SongRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(new MapperConfiguration(c => c.AddProfile(new Business.Mapper())).CreateMapper());
            services.AddTransient<IMachineService, MachineService>();

        }
    }
}
