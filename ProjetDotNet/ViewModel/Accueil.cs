using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace ProjetDotNet.ViewModel
{
    class Accueil : Inotifier
    {
        private MainViewModel mvParent;
        public Accueil(MainViewModel parent)
        {
            mvParent = parent;
            LoadData();
        }

        public int nbrMedia
        {
            get
            {

                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }

        public int nbrFilm
        {
            get
            {

                return GetValue<int>();
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
            ObservableCollection<Class.Media> allMedia = new ObservableCollection<Class.Media>(context.Medias.ToList());

            nbrMedia = allMedia.Count;


            ObservableCollection<Class.Media> allFilm = new ObservableCollection<Class.Media>(context.Films.ToList());

            nbrFilm = allFilm.Count;


        }
    }
}
