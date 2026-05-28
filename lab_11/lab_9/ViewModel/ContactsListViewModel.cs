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

        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        private string _contactName = string.Empty;
        private string _contactPhoneNum = string.Empty;
        public string ContactName
        {
            get => _contactName;
            set => Set(ref _contactName, value);
        }
        public string ContactPhoneNum
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

        public ContactsListViewModel(INavigationService navigation, IDialogService dialogService)
        {
            Contacts = new ObservableCollection<Contact>();
            AddCommand = new RelayCommand(AddContact, () => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());
            EditCommand = new RelayCommand(EditContact, () => CanEditContact());

            _navigationService = navigation;
            _dialogService = dialogService;
        }

        // методы
        private void AddContact()
        {
            // Проверка на дубликат по номеру телефона
            if (Contacts.Any(c => c.Phone == ContactPhoneNum))
            {
                _dialogService.ShowWarning("A contact with this number already exists!");
                return;
            }

            if (Contact.Validate(ContactName, ContactPhoneNum))
            {
                Contacts.Add(new Contact(ContactName, ContactPhoneNum));
                _dialogService.ShowInfo("Contact added");

                ContactName = string.Empty;
                ContactPhoneNum = string.Empty;
            }
        }
        private bool CanAddContact()
        {
            return Contact.Validate(ContactName, ContactPhoneNum);
        }
        private void DeleteContact()
        {
            if (SelectedContact == null)
                return;

            bool confirmed = _dialogService.ShowConfirmation($"Do you really want to delete the contact\"{SelectedContact.Name}\"?");

            if (confirmed)
            {
                Contacts.Remove(SelectedContact);
                _dialogService.ShowInfo("Contact successfully deleted");
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
