using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Messenger
{
    public sealed class CurrentPhoneRequestMessage : RequestMessage<Phone>
    {
    }
}
