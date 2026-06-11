using lab_9.Serveses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using lab_9.Model;

namespace lab_9.ViewModel
{
    public class ContactsListViewModel : ObservableObject // ViewModel
    {
        // Коллекция контактов
        public ObservableCollection<Contact> Contacts { get; }
        private readonly PhoneBookDbSivokozova2307d1Context _context;

        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        private string _contactName = string.Empty;
        private string _contactPhoneNum = string.Empty;
        public string Name
        {
            get => _contactName;
            set => Set(ref _contactName, value);
        }
        public string Phone
        {
            get => _contactPhoneNum;
            set => Set(ref _contactPhoneNum, value);
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
        public ICommand EditCommand { get; }

        public ContactsListViewModel(INavigationService navigation, IDialogService dialogService, PhoneBookDbSivokozova2307d1Context context)
        {
            _navigationService = navigation;
            _dialogService = dialogService;
            _context = context;

            //Contacts = new ObservableCollection<Contact>();
            Contacts = new ObservableCollection<Contact>(_context.Contacts.ToList());
            AddCommand = new RelayCommand(AddContact, () => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());
            EditCommand = new RelayCommand(EditContact, () => CanEditContact());
        }

        // методы
        private void AddContact()
        {
            // Проверка на дубликат по номеру телефона
            if (Contacts.Any(c => c.Phone == Phone))
            {
                _dialogService.ShowWarning("A contact with this number already exists!");
                return;
            }

            if (ContactModel.Validate(Name, Phone))
            {
                try
                {
                    var newContact = new Contact
                    {
                        Name = Name,
                        Phone = Phone
                    };
                    // 1. Помечаем объект как добавленный
                    _context.Contacts.Add(newContact);
                    // 2. Сохраняем изменения в БД (генерирует INSERT)
                    _context.SaveChanges();

                    Contacts.Add(newContact);

                    Name = string.Empty;
                    Phone = string.Empty;

                    _dialogService.ShowInfo("Contact added");
                }
                catch (Exception ex)
                {
                    _dialogService?.ShowError($"Error when adding: {ex.Message}");
                }
            }
        }
        private bool CanAddContact()
        {
            return ContactModel.Validate(Name, Phone);
        }
        private void DeleteContact()
        {
            if (SelectedContact == null)
                return;

            bool confirmed = _dialogService.ShowConfirmation($"Do you really want to delete the contact\"{SelectedContact.Name}\"?");

            if (confirmed)
            {
                try
                {                    //Contacts.Remove(SelectedContact);
                    if (SelectedContact == null) return;
                    // 1. Помечаем объект как удалённый
                    _context.Contacts.Remove(SelectedContact);
                    // 2. Сохраняем изменения (генерирует DELETE)
                    _context.SaveChanges();
                    // 3. Обновляем UI коллекцию
                    Contacts.Remove(SelectedContact);

                    _dialogService.ShowInfo("Contact successfully deleted");
                }
                catch (Exception ex)
                {
                    _dialogService.ShowError($"Error when deleting{ex.Message}");
                }
            }
        }
        private bool CanDeleteContact()
        {
            return SelectedContact != null;
        }

        private void EditContact()
        {
            if (SelectedContact != null)
            {
                _navigationService.NavigateTo<ContactEditViewModel>(SelectedContact);
            }
        }

        private bool CanEditContact()
        {
            return SelectedContact != null;
        }
    }
}
