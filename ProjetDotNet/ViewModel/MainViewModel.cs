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
    public class MainViewModel: Inotifier
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

        
    }
}
