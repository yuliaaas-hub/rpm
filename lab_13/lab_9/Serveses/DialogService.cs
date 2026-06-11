using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_9.Serveses
{
    public class DialogService : IDialogService
    {
        public void ShowInfo(string message, string title = "Информация")
        {
            // ВЫЗЫВАТЬ MESSAGEBOX.SHOW с нужными аргументами
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        // АНАЛОГИЧНО ДРУГИЕ МЕТОДЫ
        public void ShowWarning(string message, string title = "Информация")
        {
            // ВЫЗЫВАТЬ MESSAGEBOX.SHOW с нужными аргументами
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public void ShowError(string message, string title = "Информация")
        {
            // ВЫЗЫВАТЬ MESSAGEBOX.SHOW с нужными аргументами
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool ShowConfirmation(string message, string title = "Информация")
        {
            // ВЫЗЫВАТЬ MESSAGEBOX.SHOW с нужными аргументами
            MessageBoxResult result = MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            // 2. Вернуть true, если нажали "Да"
            return result == MessageBoxResult.Yes;

        }
    }
}
