using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using ITT_sys.Models;


namespace ITT_sys.ViewModels
{
    public class ShellViewModel : ValidationsModel,IDataErrorInfo

    {
       
        public string Error { get { return null;  } }
        private string _username;
        private Dictionary<string, string> ErrorCollection = new Dictionary<string, string>();


        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Username cannot be empty";
                        else if (Username.Length < 5)
                            result = "Username must be a minimum of 5 characters.";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                {
                    ErrorCollection[name] = result;
                    Console.WriteLine(result);
                }

                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");


                return result;
            }
        }
       
        //private void Set(string key, string value)
        //{
        //    if (ErrorCollection.ContainsKey(key))
        //    {
        //        ErrorCollection[key] = value;
        //    }
        //    else
        //    {
        //        ErrorCollection.Add(key, value);
        //    }
        //}

        //public string Get(string key)
        //{
        //    string result = null;

        //    if (ErrorCollection.ContainsKey(key))
        //    {
        //        result = ErrorCollection[key];
        //    }

        //    return result;
        //}

    

        

       
        
    }
}
