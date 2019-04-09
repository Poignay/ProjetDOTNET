using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Media_Personne
    {
        [InverseProperty(nameof(Media.id))]
        public int id_Media { get; set; }
        
        [InverseProperty(nameof(Personne.id))]
        public int id_Personne { get; set; }

        public Fonction Fontion { get; set; }
        public string Role { get; set; }

    }
}
