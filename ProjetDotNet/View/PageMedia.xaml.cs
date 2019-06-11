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
    /// Logique d'interaction pour PageMedia.xaml
    /// </summary>
    public partial class PageMedia : Page
    {
        public PageMedia()
        {
            InitializeComponent();
        }
        public PageMedia(ViewModel.MainViewModel parent)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.PageMedia(parent);
        }

        private void Grid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
