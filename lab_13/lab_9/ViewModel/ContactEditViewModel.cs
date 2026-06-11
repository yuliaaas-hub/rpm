using lab_9.Model;
using lab_9.Serveses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_9.ViewModel
{
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly PhoneBookDbSivokozova2307d1Context _context;

       // private Contact _contact = null!;

        private string _editContactName = string.Empty;
        private string _editContactPhone = string.Empty;
        private Contact? _editingContact;
        public string EditContactName
        {
            get => _editContactName;
            //set { _contact.ContactName = value; OnPropertyChanged(); }
            set => Set(ref _editContactName, value);
        }
        public string EditContactPhone
        {
            get => _editContactPhone;
            //set { _contact.ContactPhoneNum = value; OnPropertyChanged(); }
            set => Set(ref _editContactPhone, value);
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ContactEditViewModel(IDialogService dialogService, INavigationService navigation, PhoneBookDbSivokozova2307d1Context context)
        {
            _context = context;
            _dialogService = dialogService;
            _navigationService = navigation;

            //SaveCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            //CancelCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }
        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact c)
            {
                _editingContact = c;
                EditContactName = c.Name;
                EditContactPhone = c.Phone;
            }
        }
        private void Save()
        {
            if (_editingContact == null)
            {
                _dialogService.ShowError("Error: the contact was not found");
                Cancel();
                return;
            }

            if (!CanSave())
            {
                _dialogService.ShowWarning("Fill in all fields correctly");
                return;
            }

            try
            {
                _editingContact.Name = EditContactName;
                _editingContact.Phone = EditContactPhone;

                _context.SaveChanges();

                _dialogService.ShowInfo("Contact has been updated");

                _navigationService.NavigateTo<ContactsListViewModel>();
            }
            catch (Exception ex)
            {
                _dialogService.ShowError($"Error when saving: {ex.Message}");
            }
        }
        private bool CanSave()
        {
            return ContactModel.Validate(EditContactName, EditContactPhone);
        }
        private void Cancel()
        {
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
    }
}
