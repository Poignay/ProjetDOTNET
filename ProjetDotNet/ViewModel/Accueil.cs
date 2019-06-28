using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using static System.Environment;
using LiveCharts.Defaults;


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
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrFilm
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrSerie
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrAVoir
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
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
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int nbrNotes
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        //Radiobuttons:
        public Boolean isChecked1
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); LoadData(); }
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
            get { return GetValue<ObservableCollection<String>>(); }

            set { SetValue(value); }
        }

        public String typeCBoxSelected
        {
            get { return GetValue<String>(); }
            set { SetValue(value); LoadData(); }
        }

        public ChartValues<double> valeurFilm
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
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

        public ChartValues<double> valeurNote0
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurNote1
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurNote2
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurNote3
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurNote4
        {
            get { return GetValue<ChartValues<double>>(); }
            set { SetValue(value); }
        }

        public ChartValues<double> valeurNote5
        {
            get { return GetValue<ChartValues<double>>(); }
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
            ObservableCollection<Class.Media> aVoir = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Statut.ToString() == "A_voir").ToList());

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
            if (isChecked1 == true)
            {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 1).ToList());
                nbrNotes = deLaNote.Count;
            } else if (isChecked2 == true) {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 2).ToList());
                nbrNotes = deLaNote.Count;
            } else if (isChecked3 == true) {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 3).ToList());
                nbrNotes = deLaNote.Count;
            } else if (isChecked4 == true) {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 4).ToList());
                nbrNotes = deLaNote.Count;
            } else if (isChecked5 == true) {
                ObservableCollection<Class.Media> deLaNote = new ObservableCollection<Class.Media>(context.Medias.Where(m => m.Note == 5).ToList());
                nbrNotes = deLaNote.Count;
            } else {
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

            ObservableCollection<Class.Film> listeNote5 = new ObservableCollection<Class.Film>(context.Films.Where(m => m.Note == 5).ToList());
            note5 = listeNote5.Count;

            valeurNote0 = new ChartValues<Double> { note0 };
            valeurNote1 = new ChartValues<Double> { note1 };
            valeurNote2 = new ChartValues<Double> { note2 };
            valeurNote3 = new ChartValues<Double> { note3 };
            valeurNote4 = new ChartValues<Double> { note4 };
            valeurNote5 = new ChartValues<Double> { note5 };



        }

        
        public Commands.BaseCommand CommandePageChange
        {
            get
            {
                return new Commands.BaseCommand(VoirListe);
            }
        }

        private void VoirListe()
        {
            mvParent.PageCourante = new View.Liste(mvParent);

            mvParent.PageCourante.DataContext = new ViewModel.Liste(mvParent);
        }


        public Commands.BaseCommand CommandeAjoutDonnee
        {
            get
            {
                return new Commands.BaseCommand(ajoutFilm);
            }
        }

        private async void ajoutFilm()
        {
            /*String fpath = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "../database.db");
            if (System.IO.File.Exists(fpath)) System.IO.File.Delete(fpath);*/

            var context = await DataAccess.DbContext.GetCurrent();
        
            Class.Genre Comedie = new Class.Genre()
            {
                nom = "Comédie"
            };
            context.Add(Comedie);

            
            Class.Genre Action = new Class.Genre()
            {
                nom = "Action"
            };
            context.Add(Action);

            Class.Genre Aventure = new Class.Genre()
            {
                nom = "Aventure"
            };
            context.Add(Aventure);

            Class.Genre Polar = new Class.Genre()
            {
                nom = "Polar"
            };
            context.Add(Polar);
            Class.Genre Animation = new Class.Genre()
            {
                nom = "Animation"
            };
            context.Add(Animation);
            Class.Genre Thriller = new Class.Genre()
            {
                nom = "Thriller"
            };
            context.Add(Thriller);
            Class.Genre Drame = new Class.Genre()
            {
                nom = "Drame"
            };
            context.Add(Drame);


            System.Drawing.Image image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "\\Image.jpg");
            Class.Media Alad2 = new Class.Film()
            {
                ImgSet = image,
                Titre = "Alad'2",
                Date_Creation = DateTime.Parse("01/04/2019"),
                Synopsis = "Après avoir libéré Bagdad de l’emprise de son terrible Vizir, Aladin s’ennuie au palais et ne s’est toujours pas décidé à demander en mariage la princesse. Mais un terrible dictateur, Shah Zaman, s’invite au Palais et annonce qu’il est venu prendre la ville et épouser la Princesse. Aladin n’a pas d’autre choix que de s’enfuir du Palais… Il va tenter de récupérer son ancien Génie et revenir en force pour libérer la ville et récupérer sa promise.",
                Note = 5,
                Statut = Class.StatutMedia.A_voir,
                Commentaire = "Super film"
            };
            context.Add(Alad2);
            context.Add(new Class.Media_Genre()
            {
                Media = Alad2,
                Genre = Comedie
            });


            System.Drawing.Image image2 = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "\\Image.jpg");
            Class.Media AvengerEndGame = new Class.Film()
            {
                ImgSet = image2,
                Titre = "Avengers : Endgame",
                Date_Creation = DateTime.Parse("24/04/2019"),
                Synopsis = "Thanos ayant anéanti la moitié de l’univers, les Avengers restants resserrent les rangs dans ce vingt-deuxième film des Studios Marvel, grande conclusion d’un des chapitres de l’Univers Cinématographique Marvel.",
                Note = 3,
                Statut = Class.StatutMedia.Vu,
                Commentaire = "Bofouille"
            };
            context.Add(AvengerEndGame);

           
            context.Add(new Class.Media_Genre()
            {
                Media = AvengerEndGame,
                Genre = Action
            });
            context.Add(new Class.Media_Genre()
            {
                Media = AvengerEndGame,
                Genre = Comedie
            });


            System.Drawing.Image aceVenturaPet = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "\\AceVenturaPet.jpg");
            Class.Media AceVentura = new Class.Film()
            {
                ImgSet = aceVenturaPet,
                Titre = "Ace Ventura, détective animaliers",
                Date_Creation = DateTime.Parse("04/02/1994 "),
                Synopsis = "Ace Ventura, un détective pour animaux, enquête sur l'enlevement de Flocon de neige, le dauphin mascotte de l'équipe des Dauphins de Miami. Mais Ace Ventura est un détective aux méthodes un peu particulières et au comportement étrange qui déplaît notamment beaucoup à la police de Miami avec qui il est censé collaborer.",
                Note = 3,
                Statut = Class.StatutMedia.A_voir,
                Commentaire = "Excellent film familiaux à voir! On s'est pété le bide a en rire ahahah"
            };
            context.Add(AceVentura);
          
            context.Add(new Class.Media_Genre()
            {
                Media = AceVentura,
                Genre = Comedie
            });



            System.Drawing.Image yourName = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "\\yourName.jpg");
            Class.Media YourName = new Class.Film()
            {
                ImgSet = yourName,
                Titre = "Your Name ",
                Date_Creation = DateTime.Parse("28/12/2016"),
                Synopsis = "Mitsuha, adolescente coincée dans une famille traditionnelle, rêve de quitter ses montagnes natales pour découvrir la vie trépidante de Tokyo. Elle est loin d'imaginer pouvoir vivre l'aventure urbaine dans la peau de... Taki, un jeune lycéen vivant à Tokyo. À travers ses rêves, Mitsuha se voit littéralement propulsée dans la vie du jeune garçon. Quel mystère se cache derrière ces rêves étranges qui unissent deux destinées que tout oppose et qui ne se sont jamais rencontrées ?",
                Note = 5,
                Statut = Class.StatutMedia.Vu,
                Commentaire = "Absolument touchant, le travail de la DA est fantastique. Le film est A VOIR si vous êtes fans de japanimation"
            };
            context.Add(YourName);

            context.Add(new Class.Media_Genre()
            {
                Media = YourName,
                Genre = Animation

            });

            context.Add(new Class.Media_Genre()
            {
                Media = YourName,
                Genre = Drame

            });

            System.Drawing.Image PeakyBlinders = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "\\PeakyBlinder.jpg");
            Class.Media PeakyBlinder = new Class.Serie()
            {
                ImgSet = PeakyBlinders,
                Titre = "Peaky Blinders ",
                Date_Creation = DateTime.Parse("12/09/2013"),
                Synopsis = "Birmingham, en 1919. Un gang familial règne sur un quartier de la ville : les Peaky Blinders, ainsi nommés pour les lames de rasoir qu'ils cachent dans la visière de leur casquette.",
                Note = 5,
                Statut = Class.StatutMedia.En_cours,
                Commentaire = "Absolument touchant, le travail de la DA est fantastique. Le série est incroyable",
                Nb_Saison = 5,
                Duree = 22
            
            };
            context.Add(PeakyBlinder);

            context.Add(new Class.Media_Genre()
            {
                Media = PeakyBlinder,
                Genre = Drame

            });

            context.Add(new Class.Media_Genre()
            {
                Media = PeakyBlinder,
                Genre = Action

            });

            context.SaveChanges();
            LoadComboBox();


        }

    }
}
