using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Pret
    {
        [InverseProperty(nameof(Media.id))]
        public int Id_media { get; set; }
        
        [InverseProperty(nameof(Personne.id))]
        public int Id_personne { get; set; }

        public DateTime date_Pret { get; set; }
        public DateTime date_Retour { get; set; }
    }
}
