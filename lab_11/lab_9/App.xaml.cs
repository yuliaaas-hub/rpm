using lab_9.Serveses;
using lab_9.ViewModel;
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
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Ñåðâèñû (Singleton)
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ContactsListViewModel>();

            // ViewModels (Transient)
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();

            // Shell ViewModel (Singleton)
            services.AddSingleton<MainWindowViewModel>();

            // Ãëàâíîå îêíî (Singleton)
            services.AddSingleton<MainWindow>(sp =>
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
