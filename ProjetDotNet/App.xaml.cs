using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            String fpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (System.IO.File.Exists(fpath)) System.IO.File.Delete(fpath);
            var context = await DataAccess.DbContext.GetCurrent();
            Class.Genre unGenre = new Class.Genre()
            {
                nom="Comédie"
            };
            context.Add(unGenre);
            context.Add(new Class.Media()
            {
                Titre = "Alad'2",
                Date_Creation = DateTime.Parse("01/04/2019"),
                Synopsis = "Après avoir libéré Bagdad de l’emprise de son terrible Vizir, Aladin s’ennuie au palais et ne s’est toujours pas décidé à demander en mariage la princesse. Mais un terrible dictateur, Shah Zaman, s’invite au Palais et annonce qu’il est venu prendre la ville et épouser la Princesse. Aladin n’a pas d’autre choix que de s’enfuir du Palais… Il va tenter de récupérer son ancien Génie et revenir en force pour libérer la ville et récupérer sa promise.",
                Note= 5,
                Commentaire="Super film"
            });
            context.SaveChanges();
            
        }
    }
}
