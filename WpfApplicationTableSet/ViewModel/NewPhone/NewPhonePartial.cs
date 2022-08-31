using System.ComponentModel;
using System.Windows.Media;
 

namespace WpfApplicationTableSet.ViewModel.NewPhone
{
    public partial class NewPhoneVM : EntityBase, IDataErrorInfo
    {
        private string _error;
        public string Error => _error;

        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
               switch (columnName)
                {
                    case nameof(NameModel):
                         

                        AddErrors(nameof(NameModel), GetErrorsFromAnnotations(nameof(NameModel), NameModel));
                        break;

                    case nameof(Manufacturer):
                        hasError = CheckMakeAndColor();
                        
                        if (!hasError)
                        {
                            //This is not perfect logic, just illustrative of the pattern
                            ClearErrors(nameof(Manufacturer));
                            ClearErrors(nameof(Color));
                        }

                        AddErrors(nameof(Manufacturer), GetErrorsFromAnnotations(nameof(Manufacturer), Manufacturer));
                        break;

                  

                    case nameof(Price):
                        if (Price > 10)
                        {
                            AddError(nameof(Price), "Price > 10");
                            hasError = true;
                        }

                        if (!hasError)
                        {
                            ClearErrors(nameof(Price));
                        }
                        break;
                }

                return string.Empty;
            }
        }


        //internal string CheckMakeAndColor()
        //{
        //    if (Make == "Chevy" && Color == "Pink")
        //    {
        //        return $"{Make}'s don't come in {Color}";
        //    }
        //    return string.Empty;
        //}
        internal bool CheckMakeAndColor()
        {
            if (NameModel.Equals("L") || NameModel == "ModelT")
            {
                AddError(nameof(NameModel), $" Make is L");
                return true;
            };
            if (NameModel != "Chevy" || NameModel != "Pink") return false;
            AddError(nameof(NameModel), $"{NameModel}'s don't come in {NameModel}");
            AddError(nameof(Color), $"{NameModel}'s don't come in {NameModel}");
            return true;
        }
    }
}