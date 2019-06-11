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
            LoadComboBox();
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

        public int nbrDansGenre
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


        public int nbrNotes
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

        //Radiobuttons:
        public Boolean isChecked1
        {
            get{return GetValue<Boolean>();}
            set{SetValue(value); LoadData(); }
        }

        public Boolean isChecked2
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); LoadData(); }
        }

        public Boolean isChecked3
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); LoadData(); }
        }

        public Boolean isChecked4
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); LoadData(); }
        }

        public Boolean isChecked5
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); LoadData(); }
        }


        public ObservableCollection<String> typeCBox
        {
            get{return GetValue<ObservableCollection<String>>();}

            set{SetValue(value);}
        }

        public String typeCBoxSelected
        {
            get { return GetValue<String>(); }
            set { SetValue(value); LoadData(); }
        }

        public async Task LoadComboBox()
        {
            var context = await DataAccess.DbContext.GetCurrent();

            ObservableCollection<Class.Genre> list = new ObservableCollection<Class.Genre>(context.Genres.ToList());
            ObservableCollection<String> listString = new ObservableCollection<String>();

            foreach (Class.Genre el in list)
            {
                listString.Add(el.nom);
            }

            typeCBox = listString;

            LoadData();
           
        }
        
        public async Task LoadData()
        {
            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection du nombre de total de média
            ObservableCollection<Class.Media> allMedia = new ObservableCollection<Class.Media>(context.Medias.ToList());

            nbrMedia = allMedia.Count;


            // Sélection du nombre de total de film
            ObservableCollection<Class.Media> allFilm = new ObservableCollection<Class.Media>(context.Films.ToList());

            nbrFilm = allFilm.Count;


            // Sélection du nombre de total de serie
            ObservableCollection<Class.Media> allSerie = new ObservableCollection<Class.Media>(context.Series.ToList());

            nbrSerie = allSerie.Count;

            //Sélection du nombre de films/Séries à voir
            ObservableCollection<Class.Media> aVoir = new ObservableCollection<Class.Media>(context.Medias.Where(m=> m.Statut.ToString() == "A_voir").ToList());

            nbrAVoir = aVoir.Count;

            // Sélection du nombre de total de média suivant le Genre sélectionné
            ObservableCollection<Class.Media> dansGenre = new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres).Where(m => m.Genres.Any(g => g.Genre.nom == typeCBoxSelected)).ToList());

            nbrDansGenre = dansGenre.Count;



            //Sélections des films suivant la notes:
            if(isChecked1 == true)
            {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 1).ToList());
                nbrNotes = deLaNote.Count;
            }else if(isChecked2 == true){
                    ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 2).ToList());
                    nbrNotes = deLaNote.Count;
            }else if (isChecked3 == true){
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 3).ToList());
                nbrNotes = deLaNote.Count;
            }else if (isChecked4 == true){
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 4).ToList());
                nbrNotes = deLaNote.Count;
            }else if (isChecked5 == true){
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 5).ToList());
                nbrNotes = deLaNote.Count;
            }else{
                nbrNotes = 0;
            }



        }
    }
}
