using lab_9.Serveses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_9.ViewModel
{
    public class MainWindowViewModel
    {

        public INavigationService _navigationService;

        public INavigationService NavigationService => _navigationService;

        public MainWindowViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            ShowContactsCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            ShowAboutCommand = new RelayCommand(() => _navigationService.NavigateTo<AboutViewModel>());
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
        public ICommand ShowContactsCommand { get; }
        public ICommand ShowAboutCommand { get; }
    }
}
