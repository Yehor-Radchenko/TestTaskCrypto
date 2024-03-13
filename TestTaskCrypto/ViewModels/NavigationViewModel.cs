using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestTaskCrypto.Common;

namespace TestTaskCrypto.ViewModels
{
    public class NavigationViewModel : BaseViewModel 
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ConvertCommand { get; set; }

        private void Home (object obj) =>CurrentView = new HomeViewModel();
        private void Convert(object obj) => CurrentView = new ConvertViewModel();

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            ConvertCommand = new RelayCommand(Convert); 

            CurrentView = new HomeViewModel();
        }
    }
}
