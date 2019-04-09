using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Episode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }


        [InverseProperty(nameof(Media.id))]
        public int id_Media { get; set; }

        public string nom { get; set; }
        public TimeSpan duree { get; set; }
        public int numero { get; set; }
        public DateTime date_sortie { get; set; }
        public int saison { get; set; }
        public string synopsis { get; set; }
        public int age_minimun { get; set; }
        public StatutMedia Statut { get; set; }
        public int note { get; set; }
        public string commentaire { get; set; }
    }
}
