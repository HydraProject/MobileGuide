using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobileGuide
{
    public class Options : INotifyPropertyChanged
    {

        public  event PropertyChangedEventHandler PropertyChanged;


        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(_name, StringComparison.Ordinal))
                {
                    // Nothing to do - the value hasn't changed;
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        public void Namechange(string text)
        {
            Name = text;
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
