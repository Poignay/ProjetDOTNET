using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.Class
{
    public class Media_Genre
    {

        public int MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public Media Media { get; set; }

        public int GenreId { get; set; }
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }
    }
}
