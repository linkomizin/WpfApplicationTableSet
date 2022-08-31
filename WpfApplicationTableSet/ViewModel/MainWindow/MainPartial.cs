using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using WpfApplicationTableSet.ViewModel;

namespace WpfApplicationTableSet.ViewModel.MainWindow
{
    public partial class MainViewModel : EntityBase, IDataErrorInfo
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
                    case nameof(ConnectString):
                        hasError = ChekConnect();

                          if (!hasError)
                        {
                            //This is not perfect logic, just illustrative of the pattern
                            ClearErrors(nameof(ConnectString));
                            ClearErrors(nameof(ConnectString));
                        }
                          AddErrors(nameof(ConnectString), GetErrorsFromAnnotations(nameof(ConnectString), ConnectString));
                        break;

                    //case nameof(Manufacturer):
                    //    hasError = CheckMakeAndColor();
                        
                       

                    //    AddErrors(nameof(Manufacturer), GetErrorsFromAnnotations(nameof(Manufacturer), Manufacturer));
                    //    break;

                  
 
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
        //internal bool CheckMakeAndColor()
        //{
           
        //    if (Manufacturer != "Chevy" || Manufacturer != "Pink") return false;
        //    AddError(nameof(Manufacturer), $"{Manufacturer}'s don't come in {Manufacturer}");
        //    AddError(nameof(Color), $"{Manufacturer}'s don't come in {Manufacturer}");
        //    return true;
            
        //    using (MySqlConnection connection = new MySqlConnection(ConnectString))
        //    {
        //        connection.Open();
        //    }
        //}

        private bool ChekConnect()
        {
            bool isConnectionFailed = false;

            using (MySqlConnection connection = new MySqlConnection(ConnectString))
            {
                try
                {
                    connection.Open();
                    isConnectionFailed = false;
                }
                catch (Exception e)
                {
                    AddError(nameof(ConnectString), e.Message);
                    isConnectionFailed = true;
                }
            }
            return isConnectionFailed;
        }

    }
}