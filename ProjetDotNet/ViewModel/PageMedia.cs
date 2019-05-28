using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace ProjetDotNet.ViewModel
{
    class PageMedia
    {
        private MainViewModel mvParent;
        public PageMedia(MainViewModel parent)
        {
            mvParent = parent;
        }

        public Class.Media unMedia { get; set; }

        private String _dis;
        public String Dis {
            get {
                LoadData();
                return _dis;
            }
            set {
                Dis = _dis;
            }
        }

        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection des medias
            ObservableCollection<Class.Media> desMedias=new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres).Include(m => m.PersonneMedia));
            foreach(Class.Media med in desMedias)
            {
                unMedia = med;
                String disss = "";
                foreach(Class.Media_Personne per in med.PersonneMedia)
                {
                    disss = per.Personne.nom + " " + per.Personne.Prenom + " : " + per.Fontion+"; ";
                }
                _dis = disss;
            }

        }
    }
}
