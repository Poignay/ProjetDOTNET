using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetDotNet.View
{
    /// <summary>
    /// Logique d'interaction pour Liste.xaml
    /// </summary>
    public partial class Liste : Page
    {
        public Liste()
        {
            InitializeComponent();
        }

        public Liste(ViewModel.MainViewModel parent)
        { 
            InitializeComponent();
            this.DataContext = new ViewModel.Liste(parent);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
