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
        [InverseProperty(nameof(Media.id))]
        public int Id_media { get; set; }
        
        [InverseProperty(nameof(Genre.id))]
        public int Id_genre { get; set; }
    }
}
