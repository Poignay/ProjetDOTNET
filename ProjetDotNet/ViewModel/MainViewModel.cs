using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetDotNet.ViewModel
{
    public class MainViewModel
    {
        public Page PageCourante { get; set; }
        public MainViewModel()
        {
            PageCourante = new View.Accueil();
            PageCourante.DataContext = new ViewModel.Accueil();
        }
    }
}
