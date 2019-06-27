using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        [NotMapped]
        public String DateCrea
        {
            get
            {
                return Date_Creation.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            set
            {
                try
                {
                    Date_Creation = DateTime.Parse(value);
                }
                catch (Exception ex)
                {
                    Date_Creation = DateTime.Parse("01/01/2001");
                }
            }
        }

        [NotMapped]
        public BitmapImage Img
        {
            get
            {
                try
                {
                    MemoryStream strmImg = new MemoryStream(Image);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                    return myBitmapImage;
                }catch( Exception ex)
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
                Image = (byte[])converter.ConvertTo(value, typeof(byte[]));
            }
        }
    

    [InverseProperty(nameof(Media_Genre.Media))]
        public List<Media_Genre> Genres { get; set; }

        [NotMapped]
        public string Ge
        {
            get
            {
                String str = "";
                foreach (Media_Genre unGenre in Genres) {
                   if (str=="")
                        str = unGenre.Genre.nom ;
                   else
                        str += ","+unGenre.Genre.nom ;
                }
                return str;
            }
            set
            {
                if (value != null)
                {
                    Ge = value;
                }
            }
        }
        [NotMapped]
        public string Pe
        {
            get
            {
                String str = "";
                foreach (Media_Personne unePersonne in PersonneMedia)
                {
                    if (str == "")
                        str = unePersonne.Personne.nom+" : "+ unePersonne.Fontion;
                    else
                        str += ";" + unePersonne.Personne.nom + " : " + unePersonne.Fontion;
                }
                return str;
            }
        }
        [NotMapped]
        public List<String> GeListe
        {
            get
            {
                List<String> lGe= new List<string>();
                foreach (Media_Genre unGenre in Genres)
                {
                    lGe.Add(unGenre.Genre.nom);
                }
                return lGe;
            }
        }

        [NotMapped]
        public List<String> PersonneListe
        {
            get
            {
                List<String> lPe = new List<string>();
                foreach (Media_Personne unePersonne in PersonneMedia)
                {
                    lPe.Add(unePersonne.Personne.nom);
                }
                return lPe;
            }
        }

        [NotMapped]
        public string AudioDes
        {
            get
            {
                if(Audio_Description) return "Oui";
                else return "Non";

            }
        }

        [NotMapped]
        public string SupportPhy
        {
            get
            {
                if (Support_physique) return "Oui";
                else return "Non";

            }
        }

        [NotMapped]
        public string SupportNum
        {
            get
            {
                if (Support_numerique) return "Oui";
                else return "Non";

            }
        }

        [InverseProperty(nameof(Pret.Media))]
        public List<Pret> PersonnePret { get; set; }

        [InverseProperty(nameof(Media_Personne.Media))]
        public List<Media_Personne> PersonneMedia { get; set; }


    }
}
