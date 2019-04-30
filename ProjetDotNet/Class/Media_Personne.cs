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
        public int MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public Media Media { get; set; }

        public int PersonneID{ get; set; }
        [ForeignKey(nameof(PersonneID))]
        public Personne Personne { get; set; }

        public Fonction Fontion { get; set; }
        public string Role { get; set; }

    }
}
