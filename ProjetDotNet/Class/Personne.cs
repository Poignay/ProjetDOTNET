using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Personne
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nom { get; set; }
        public Civilite Civilite { get; set; }
        public string Prenom { get; set; }
        public Langue Nationalite { get; set; }
        public byte[] Photo { get; set; }
        public bool Ami { get; set; }


        [InverseProperty(nameof(Media_Personne.Personne))]
        public List<Media_Personne> MediaPersonne { get; set; }

        [InverseProperty(nameof(Pret.Personne))]
        public List<Pret> MediaPret { get; set; }
    }
}
