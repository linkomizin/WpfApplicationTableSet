using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using WpfApp.Messenger;
using WpfApp.Model;

namespace WpfApp.ViewModel.NewPhone
{
    public class NewPhoneVm : ObservableRecipient
    {

        public NewPhoneVm()
        {
            ReturnPhoneCommand = new RelayCommand(ReturnPhone);
            SendUserMessageCommand = new RelayCommand(SendUserMessage);
        }



        private Phone _phone;
        public Phone GetPhone
        {
            get => _phone;
            private set => SetProperty(ref _phone, value);
        }

        public ICommand ReturnPhoneCommand { get; }
        public ICommand SendUserMessageCommand { get; }


        private void ReturnPhone() => GetPhone = new Phone()
        { Id = 3, Manufacturer = "Sasung", NameModel = "OLOLO!!!1", Price = 22 };

        public void RequestCurrentNewPhone()
        {
            Phone phone = GetPhone;
            GetPhone = WeakReferenceMessenger.Default.Send<CurrentPhoneRequestMessage>();
        }



        public void SendUserMessage()
        {
            Phone phone = GetPhone;

            Messenger.Send(new PhoneMessage(phone));
             
            //phone = WeakReferenceMessenger.Default.Send<CurrentPhoneRequestMessage>();
        }

        protected override void OnActivated()
        {
            Messenger.Register<NewPhoneVm, CurrentPhoneRequestMessage>
            (this, (r, m) => m.Reply(r.GetPhone));
        }


    }
}
