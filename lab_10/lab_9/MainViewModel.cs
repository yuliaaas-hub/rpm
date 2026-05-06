using lab_9.Model;
using lab_9.Serveses;
using lab_9.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_9
{
    public class MainViewModel : ObservableObject
    {
        // 1. Поле для хранения сервиса
        private readonly IDialogService _dialogService;
        // Коллекция контактов
        public ObservableCollection<Contact> Contacts { get; }
        private string _name = string.Empty;
        private string _phone = string.Empty;


        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        // TODO: объявите свойство Phone

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }
        // Команды
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        // TODO: объявите DeleteCommand
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            Contacts = new ObservableCollection<Contact>();
            AddCommand = new RelayCommand(
            AddContact,

            () => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());
            
        }
        private void AddContact()
        {
            // 1. Проверка на дубликат номера
            if (Contacts.Any(c => c.Phone == Phone))
            {
                _dialogService.ShowWarning("Контакт с таким номером уже существует!");
                return; 
            }
            try
            {
                var newContact = new Contact(Name, Phone);
                Contacts.Add(newContact);
                Name = string.Empty;
                Phone = string.Empty;
            }
            catch (ArgumentException ex) 
            {
                _dialogService.ShowError(ex.Message);
            }
            
            // TODO: создайте новый Contact с Name и
            // Phone, затем добавьте его в Contacts
            // После добавления очистите поля ввода
        }
        private bool CanAddContact()
        {

            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone))
            {
                return true;
            }
            else
            {
                return false;
            }
            // TODO: верните true, если Name не пуст
            // и Phone не пуст (расширенная проверка)
            //
            // временная заглушка
        }
        private void DeleteContact()
        {
            

            if (SelectedContact == null) return;

            // Показываем диалог и ждем ответа
            bool isConfirmed = _dialogService.ShowConfirmation($"Удалить контакт \"{SelectedContact.Name}\"?");

            if (isConfirmed)
            {
                Contacts.Remove(SelectedContact);
            }

            // TODO: удалите SelectedContact из
            // коллекции Contacts, если он не null
        }
        private bool CanDeleteContact()
        {
            return SelectedContact != null;

            
            // TODO: верните true, если SelectedContact
            // не равен null
            // временная заглушка
        }
    }
}
