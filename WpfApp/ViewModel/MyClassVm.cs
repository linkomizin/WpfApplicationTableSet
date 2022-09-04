using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp.Messenger;
using WpfApp.Model;
using WpfApp.ViewModel.NewPhone;

namespace WpfApp.ViewModel
{
    public class MyClassVm : ObservableRecipient
    {
        public MyClassVm()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
            NewPhoneOpenWindowCommand = new RelayCommand(NewPhoneOpenWindow);
        }

        #region MyRegion




        #endregion

        #region command
        public ICommand IncrementCounterCommand { get; }
        public ICommand NewPhoneOpenWindowCommand { get; }

        #endregion


        #region model

        private int _counter;

        public int Counter
        {
            get => _counter;
            private set => SetProperty(ref _counter, value);
        }

        private Phone _phone;

        public Phone NewPhoneToAdd
        {
            get => _phone;
            private set => SetProperty(ref _phone, value);
        }
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
        #endregion
        #region messenger
        protected override void OnActivated()
        {
            Messenger.Register<MyClassVm, CurrentPhoneRequestMessage>
                (this, (r, m) 
                    => r.NewPhoneToAdd = m.Response );
            ListPhone.Add(NewPhoneToAdd);
        }
        #endregion

        #region newPhone vm

        public void NewPhoneOpenWindow()
        {
            View.NewPhone.NewPhone vm = new View.NewPhone.NewPhone();
            vm.Show();
        }
        

        #endregion
    }
}
