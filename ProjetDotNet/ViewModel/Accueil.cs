using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;


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
            get{return GetValue<int>();}
            set{SetValue(value);}
        }

        public int nbrFilm
        {
            get{return GetValue<int>();}
            set{SetValue(value);}
        }

        public int nbrSerie
        {
            get{return GetValue<int>();}
            set{SetValue(value);}
        }

        public int nbrAVoir
        {
            get{return GetValue<int>();}
            set{SetValue(value);}
        }

        public int nbrVu
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrEnCours
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrDansGenre
        {
            get{return GetValue<int>();}
            set{SetValue(value);}
        }

        public int nbrNotes
        {
            get{return GetValue<int>();}
            set{SetValue(value);}
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

        public ChartValues<double> valeurFilm
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value);}
        }

        public ChartValues<double> valeurSerie
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurMediaVu
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurMediaAvoir
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurMediaEnCours
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }


        //Note
        public int note0
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int note1
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int note2
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int note3
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int note4
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int note5
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
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

        public Func<ChartPoint, string> PointLabel { get; set; }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        public async Task LoadData()
        {
            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection du nombre de total de média
            ObservableCollection<Class.Media> allMedia = new ObservableCollection<Class.Media>(context.Medias.ToList());

            nbrMedia = allMedia.Count;


            // Sélection du nombre de total de film
            ObservableCollection<Class.Media> allFilm = new ObservableCollection<Class.Media>(context.Films.ToList());

            nbrFilm = allFilm.Count ;


            // Sélection du nombre de total de serie
            ObservableCollection<Class.Media> allSerie = new ObservableCollection<Class.Media>(context.Series.ToList());

            nbrSerie = allSerie.Count;

            //Sélection du nombre de films/Séries à voir
            ObservableCollection<Class.Media> aVoir = new ObservableCollection<Class.Media>(context.Medias.Where(m=> m.Statut.ToString() == "A_voir").ToList());

            nbrAVoir = aVoir.Count;

            //Sélection du nombre de films/Séries vu
            ObservableCollection<Class.Media> Vu = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Statut.ToString() == "Vu").ToList());

            nbrVu = Vu.Count;

            //Sélection du nombre de films/Séries vu
            ObservableCollection<Class.Media> EnCours = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Statut.ToString() == "En_cours").ToList());
            nbrEnCours = EnCours.Count;

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


            
            

            valeurSerie = new ChartValues<Double> { nbrSerie };
            valeurFilm = new ChartValues<Double> { nbrFilm };

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);


            valeurMediaVu = new ChartValues<Double> { nbrVu };
            valeurMediaAvoir = new ChartValues<Double> { nbrAVoir };
            valeurMediaEnCours = new ChartValues<Double> { nbrEnCours };
           



            // Sélection du nombre de média par note
            ObservableCollection<Class.Media> listeNote0 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 0).ToList());
            note0 = listeNote0.Count;

            ObservableCollection<Class.Media> listeNote1 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 1).ToList());
            note1 = listeNote1.Count;

            ObservableCollection<Class.Media> listeNote2 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 2).ToList());
            note2 = listeNote2.Count;

            ObservableCollection<Class.Media> listeNote3 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 3).ToList());
            note3 = listeNote3.Count;

            ObservableCollection<Class.Media> listeNote4 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 4).ToList());
            note4 = listeNote4.Count;

            ObservableCollection<Class.Media> listeNote5 = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 5).ToList());
            note5 = listeNote5.Count;


            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Nombre média",
                    Values = new ChartValues<double> { note0, note1, note2, note3, note4, note5}
                }
            };

            

            Labels = new string[] {"0","1","2","3","4","5"};

            

            Formatter = value => value.ToString("N");

        }
    }
}
