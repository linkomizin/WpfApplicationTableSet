using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationTableSet.Model;
using WpfApplicationTableSet.ViewModel.Command;

namespace WpfApplicationTableSet.ViewModel.NewPhone
{
    public partial class NewPhoneVM
    {
        internal Phone newPhone;


        public bool IsChanged { get; set; }

        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string NameModel { get; set; }

        [Required, StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Required]
        public int Price { get; set; }

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

        private RelayCommand addPhoneCommand;
        public RelayCommand AddPhoneCommand
        {
            get
            {
                return addPhoneCommand ??
                       (addPhoneCommand = new RelayCommand(obj =>
                       {
                           if (HasErrors == false)
                           {
                               newPhone = new Phone{NameModel =NameModel, Manufacturer = Manufacturer, Price = Price};
                                
                           }
                       }));
            }
        }

        #endregion
    }
}
