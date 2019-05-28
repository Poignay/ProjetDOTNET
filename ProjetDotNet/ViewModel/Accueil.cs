using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.ViewModel
{
    class Accueil
    {
        private String _titre;
        public String Titre {
            get {
                LoadData();
                return _titre;
            }
           set {
                Titre=_titre;
            }
        }

        public int nbrMedia
        {
            get;
            set;
        }


        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            context.Add(new Class.Media()
            {
                Titre = "Film1",
            });

            // Enregistrement
            await context.SaveChangesAsync();

            // Sélection des medias
            ObservableCollection<Class.Media> myOb=new ObservableCollection<Class.Media>(context.Medias.ToList());
            foreach( Class.Media a in myOb)
            {
                _titre = a.Titre;
            }

            int nbrMedia = context.Medias.ToList().Count;
            



        }
    }
}
