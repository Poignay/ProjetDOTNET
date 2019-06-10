using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;


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

        public int nbrSerie
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


        public int nbrAVoir
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


        public ObservableCollection<String> typeCBox
        {
            get{return GetValue<ObservableCollection<String>>();}

            set{SetValue(value);}
        }

        public String typeCBoxSelected
        {
            get { return GetValue<String>(); }
            set { SetValue(value); }
        }

        public void LoadComboBox(ObservableCollection<String> list)
        {
            typeCBox = list;
        }

        public async Task LoadData()
        {
            var context = await DataAccess.DbContext.GetCurrent();

            ObservableCollection<Class.Genre> list = new ObservableCollection<Class.Genre>(context.Genres.ToList());
            ObservableCollection<String> listString = new ObservableCollection<String>();

            foreach (Class.Genre el in list)
            {
                listString.Add(el.nom);
            }

            LoadComboBox(listString);

            // Sélection du nombre de total de média
            ObservableCollection<Class.Media> allMedia = new ObservableCollection<Class.Media>(context.Medias.ToList());

            nbrMedia = allMedia.Count;


            // Sélection du nombre de total de film
            ObservableCollection<Class.Media> allFilm = new ObservableCollection<Class.Media>(context.Films.ToList());

            nbrFilm = allFilm.Count;


            // Sélection du nombre de total de serie
            ObservableCollection<Class.Media> allSerie = new ObservableCollection<Class.Media>(context.Series.ToList());

            nbrSerie = allSerie.Count;

            ObservableCollection<Class.Media> aVoir = new ObservableCollection<Class.Media>(context.Series.ToList());

            nbrAVoir = aVoir.Count;

            // Sélection du nombre de total de média suivant le Genre sélectionné
            //ObservableCollection<Class.Media> dansGenre = new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres.Where(nom => nom.nom =typeCBoxSelected)).ToList());


        }
    }
}
