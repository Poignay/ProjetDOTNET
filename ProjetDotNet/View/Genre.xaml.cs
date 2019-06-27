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
using System.Windows.Shapes;

namespace ProjetDotNet.View
{
    /// <summary>
    /// Logique d'interaction pour Genre.xaml
    /// </summary>
    public partial class Genre : Window
    {
        public Genre(Class.Media unMedia)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Genre(unMedia,this);
        }
        public List<Class.Genre> valRetour { get; set; }
    }
}
