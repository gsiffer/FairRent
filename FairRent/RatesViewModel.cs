using FairRent.Business;
using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FairRent
{
    class RatesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Rates displayRates;
        public Rates DisplayRates
        {
            get { return displayRates; }
            set
            {
                displayRates = new Rates
                {
                    Tax = value.Tax,
                    Discount = value.Discount,
                    Wage = value.Wage,
                };
                OnPropertyChanged();
            }
        }

        public RatesViewModel()
        {
            DisplayRates = RatesValidation.GetRates();
        }
    }
}
