using Microsoft.Extensions.DependencyInjection;

using System;
using System.Windows;
using MVVMTestBM.Repositories;
using MVVMTestBM.Services;
using MVVMTestBM.Services.Interfaces;
using MVVMTestBM.ViewModels;

namespace MVVMTestBM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<MainViewModel>();
            services.AddTransient<IBookService, BookService>();

            services.AddSingleton<BookRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static IServiceProvider ServiceProvider { get; private set; }



       /*public void StartRandomEvent()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 3); // 3s
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) // random action every 3 seconds
        {
        }*/
    }
}
