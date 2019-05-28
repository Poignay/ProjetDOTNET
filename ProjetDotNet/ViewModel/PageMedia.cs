using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace ProjetDotNet.ViewModel
{
    class PageMedia : Inotifier
    {
        private MainViewModel mvParent;
        public PageMedia(MainViewModel parent)
        {
            mvParent = parent;
        }
        private Class.Media media;
        public PageMedia(MainViewModel parent,Class.Media unMedia)
        {
            mvParent = parent;
            media = unMedia;
        }

        public Class.Media unMedia
        {
            get
            {
                return GetValue<Class.Media>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String Dis {
            get
            {
                LoadData();
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection des medias
            ObservableCollection<Class.Media> desMedias=new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres).Include(m => m.PersonneMedia).Where(m => m.id==media.id));
            foreach(Class.Media med in desMedias)
            {
                unMedia = med;
                String disss = "";
                foreach(Class.Media_Personne per in med.PersonneMedia)
                {
                    disss = per.Personne.nom + " " + per.Personne.Prenom + " : " + per.Fontion+"; ";
                }
                Dis = disss;
            }

        }
    }
}
