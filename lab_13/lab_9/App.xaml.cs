using lab_9.Serveses;
using lab_9.ViewModel;
using lab_9.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace lab_9
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            var connection_string = "Data Source=DBSRV\\ROG2025;Initial Catalog=PhoneBookDB_Sivokozova_2307d1;Integrated Security=True;Trust Server Certificate=True";

            services.AddDbContext<PhoneBookDbSivokozova2307d1Context>(options =>options.UseSqlServer(connection_string));

            // (Singleton)
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // ViewModels (Transient)
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();
            services.AddTransient<ContactsListViewModel>();

            // Shell ViewModel (Singleton)
            services.AddSingleton<MainWindowViewModel>();

            // (Singleton)
            services.AddSingleton(sp =>
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

}
