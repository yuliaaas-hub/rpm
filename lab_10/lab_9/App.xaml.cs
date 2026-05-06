using lab_9.Serveses;
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

            // 1. Создаём коллекцию сервисов
            var services = new ServiceCollection();

            // 2. Регистрируем сервисы с указанием времени жизни
            services.AddSingleton<IDialogService, DialogService>();      // один экземпляр на всё приложение
            services.AddTransient<MainViewModel>();                       // новый экземпляр при каждом запросе
            services.AddSingleton<MainWindow>(sp =>                       // окно создаём вручную
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainViewModel>();
                return window;
            });

            // 3. Строим контейнер
            _serviceProvider = services.BuildServiceProvider();

            // 4. Запускаем главное окно
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
