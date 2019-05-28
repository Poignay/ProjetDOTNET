using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjetDotNet.ViewModel
{
    public partial class MainViewModel: Window, INotifyPropertyChanged
    {
        private Page _pageCourante;
        public Page PageCourante {
            get
            {
                return GetValue<Page>();
            }
            set
            {
                SetValue(value);
            }
        }
        public MainViewModel()
        {
            PageCourante = new View.Liste(this);
            PageCourante.DataContext = new ViewModel.Liste(this);
        }

        private Dictionary<string, object> propertyValues = new Dictionary<string, object>();

        private T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyValues.ContainsKey(propertyName))
                return (T)propertyValues[propertyName];
            return default(T);

        }
        private void SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            T currentValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
            {
                propertyValues[propertyName] = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
