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
    /// Logique d'interaction pour Distribution.xaml
    /// </summary>
    public partial class Distribution : Window
    {
        public Distribution(Class.Media unMedia)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Distribution(unMedia, this);
        }
        public List<Class.Media_Personne> valRetour { get; set; }
    
    }
}
