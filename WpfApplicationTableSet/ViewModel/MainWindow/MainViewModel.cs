using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApplicationTableSet.Model;
using WpfApplicationTableSet.ViewModel.Command;

namespace WpfApplicationTableSet.ViewModel.MainWindow

{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public bool IsChanged { get; set; }

        public string ConnectString { get; set; } = "server=localhost;user=root;password=1234;database=telegramDB;";

        public ObservableCollection<Phone> ListPhone { get; set; } = new ObservableCollection<Phone>();
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
             
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }


        #region Command

        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand ??
                       (loadCommand = new RelayCommand(obj =>
                       {
                         ChekConnect();
                       }));
            }
        }

        private RelayCommand addNewPhoneCommand;
        public RelayCommand AddNewPhoneCommand
        {
            get
            {
                return addNewPhoneCommand ??
                       (addNewPhoneCommand = new RelayCommand(obj =>
                       {
                           View.NewPhone.NewPhone newPhone = new View.NewPhone.NewPhone();
                           newPhone.Show();
                           newPhone.Close();
                           MessageBox.Show("Lalalala");

                       }));
            }
        }

        #endregion



    }
}