using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class MyClassVm :ObservableObject
    {
        public MyClassVm()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
        }

        private int _counter;

        public int Counter
        {
            get => _counter;
            private set => SetProperty(ref _counter, value);
        }

        public ICommand IncrementCounterCommand { get; }

        private void IncrementCounter() => Counter++;

        private ObservableCollection<Phone> _phones
            = new ObservableCollection<Phone>()
            {
                new Phone() {Id = 1, Manufacturer = "Apple", NameModel = "S5", Price = 22},
                new Phone() {Id = 2, Manufacturer = "Samsung", NameModel = "A3", Price = 22},
            };

        public ObservableCollection<Phone> ListPhone
        {
            get => _phones;
            private set => SetProperty(ref _phones, value);
        }

    }
}
