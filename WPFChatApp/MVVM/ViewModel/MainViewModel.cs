using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.Core;
using WPFChatApp.MVVM.Model;

namespace WPFChatApp.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        //Commands:
        public RelayCommand SendCommand { get; set; }
        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();
            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    IsFirstMessage = false,

                });
                Message = "";
            });
            Messages.Add(new MessageModel
            {
                Username = "TestUser",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/wXhO64b",
                Message = "Hi there",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                IsFirstMessage = true
            });
            for (int i = 0;i<3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "TestUser",
                    UsernameColor = "#409aff",
                    ImageSource = "https://imgur.com/wXhO64b",
                    Message = "Hi there",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    IsFirstMessage = false
                });
            }
            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Le Frog",
                    UsernameColor = "#409aff",
                    ImageSource = "https://imgur.com/wXhO64b",
                    Message = "Hi there",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                    IsFirstMessage = false
                });
            }
            Messages.Add(new MessageModel
            {
                Username = "Le Frog",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/wXhO64b",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                IsFirstMessage = true
            });
            for(int i = 0; i<5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"TestUser {i}",
                    ImageSource = "https://imgur.com/34NeeMh",
                    Messages = Messages
                });
            }
        }

    }
}
