using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Media
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public String Titre { get; set; }

        public StatutMedia Statut { get; set; }

        public DateTime Date_Creation { get; set; }

        public int Note { get; set; }

        public String Commentaire { get; set; }

        public String Synopsis{ get; set; }

        public int Age_minimum { get; set; }

        public Langue Langue_vo { get; set; }

        public Langue Langue_Media { get; set; }

        public Langue Sous_titre { get; set; }

        public bool Audio_Description { get; set; }

        public bool Support_physique { get; set; }

        public bool Support_numerique { get; set; }

        public byte[] Image { get; set; }


    }
}
