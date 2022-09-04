using CommunityToolkit.Mvvm.Messaging.Messages;
 
using WpfApp.Model;

namespace WpfApp.Messenger
{
    public sealed class PhoneMessage: ValueChangedMessage<Phone>
    {
        public PhoneMessage(Phone value) : base(value)
        {
        }
    }
    public sealed class CurrentPhoneRequestMessage : RequestMessage<Phone>
    {
    }
}
 