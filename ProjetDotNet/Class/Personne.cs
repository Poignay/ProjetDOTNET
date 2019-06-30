using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        [NotMapped]
        public String NomPrenom
        {
            get
            {
                return nom + " " + Prenom;
            }
        }
        [NotMapped]
        public BitmapImage Img
        {
            get
            {
                try
                {
                    MemoryStream strmImg = new MemoryStream(Photo);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                    return myBitmapImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Crash bitmapimage");
                    return null;
                }
            }

        }

        [NotMapped]
        public Image ImgSet
        {
            set
            {
                ImageConverter converter = new ImageConverter();
                Photo = (byte[])converter.ConvertTo(value, typeof(byte[]));
            }
        }
    }
}
