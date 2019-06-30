using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static System.Environment;

namespace ProjetDotNet
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {



        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           /* String fpath = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "database.db");
            if (System.IO.File.Exists(fpath)) System.IO.File.Delete(fpath);*/
            /*var context = await DataAccess.DbContext.GetCurrent();
            Class.Genre unGenre = new Class.Genre()
            {
                nom="Comédie"
            };
            context.Add(unGenre);
            Class.Genre unGenre2 = new Class.Genre()
            {
                nom = "Action"
            };
            context.Add(unGenre2);
            Class.Genre unGenre3 = new Class.Genre()
            {
                nom = "Aventure"
            };
            context.Add(unGenre3);
            Image image= Image.FromFile(Directory.GetCurrentDirectory()+"\\Image.jpg");
            Class.Media unMedia = new Class.Media()
            {
                ImgSet=image,
                Titre = "Alad'2",
                Date_Creation = DateTime.Parse("01/04/2019"),
                Synopsis = "Après avoir libéré Bagdad de l’emprise de son terrible Vizir, Aladin s’ennuie au palais et ne s’est toujours pas décidé à demander en mariage la princesse. Mais un terrible dictateur, Shah Zaman, s’invite au Palais et annonce qu’il est venu prendre la ville et épouser la Princesse. Aladin n’a pas d’autre choix que de s’enfuir du Palais… Il va tenter de récupérer son ancien Génie et revenir en force pour libérer la ville et récupérer sa promise.",
                Note = 5,
                Statut= Class.StatutMedia.A_voir,
                Commentaire = "Super film"
            };
            Image image2 = Image.FromFile(Directory.GetCurrentDirectory() + "\\Image2.jpg");
            Class.Media unMedia2 = new Class.Media()
            {
                ImgSet = image2,
                Titre = "Avengers : Endgame",
                Date_Creation = DateTime.Parse("24/04/2019"),
                Synopsis = "Thanos ayant anéanti la moitié de l’univers, les Avengers restants resserrent les rangs dans ce vingt-deuxième film des Studios Marvel, grande conclusion d’un des chapitres de l’Univers Cinématographique Marvel.",
                Note = 3,
                Statut = Class.StatutMedia.Vu,
                Commentaire = "Bofouille"
            };
            context.Add(unMedia2);
            context.Add(new Class.Media_Genre()
            {
                Media = unMedia,
                Genre = unGenre
            });
            context.Add(new Class.Media_Genre()
            {
                Media = unMedia2,
                Genre = unGenre
            });
            context.Add(new Class.Media_Genre()
            {
                Media = unMedia2,
                Genre = unGenre2
            });

            context.SaveChanges();*/


        }
        
    }

}
