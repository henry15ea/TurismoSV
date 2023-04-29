using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel
{
    internal class targetaModel : INotifyPropertyChanged
    {
            private string _creditCardNumber;
            public string CreditCardNumber
            {
                get { return _creditCardNumber; }
                set
                {
                    if (_creditCardNumber != value)
                    {
                        _creditCardNumber = value;
                        OnPropertyChanged("CreditCardNumber");
                    }
                }
            }

            private string _expirationDate;
            public string ExpirationDate
            {
                get { return _expirationDate; }
                set
                {
                    if (_expirationDate != value)
                    {
                        _expirationDate = value;
                        OnPropertyChanged("ExpirationDate");
                    }
                }
            }

            private string _securityCode;
            public string SecurityCode
            {
                get { return _securityCode; }
                set
                {
                    if (_securityCode != value)
                    {
                        _securityCode = value;
                        OnPropertyChanged("SecurityCode");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyname)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
}
