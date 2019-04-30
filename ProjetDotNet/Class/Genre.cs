using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nom { get; set; }

        [InverseProperty(nameof(Media_Genre.Genre))]
        public List<Media_Genre> Media { get; set; }
    }
}
