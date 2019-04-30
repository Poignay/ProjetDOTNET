using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetDotNet.ViewModel
{
    class MainViewModel
    {
        public Page PageCourante { get; set; }
        public MainViewModel()
        {
            PageCourante = new View.Liste();
            PageCourante.DataContext = new ViewModel.Liste();
        }
    }
}
