using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;

namespace ProjetDotNet.ViewModel
{
    class PageMedia : Inotifier
    {
        private MainViewModel mvParent;
        private List<Class.Genre> lGenres;
        private List<Class.Media_Personne> lDis;
        public PageMedia(MainViewModel parent)
        {
            mvParent = parent;
        }

        public PageMedia(MainViewModel parent,Class.Media media,String Mode)
        {
            mvParent = parent;
            List<Enum> lLangue = new List<Enum>();
            foreach(Enum uneEnum in Enum.GetValues(typeof(Class.Langue)) )
            {
                lLangue.Add(uneEnum);
            }
            SourceLangue = lLangue;
            List<Enum> lStatut = new List<Enum>();
            foreach (Enum uneEnum in Enum.GetValues(typeof(Class.StatutMedia)))
            {
                lStatut.Add(uneEnum);
            }
            SourceStatut = lStatut;
            film = true;
            FilmCheck();
            btnActiveModif = "hidden";
            btnAjouter = "hidden";
            btnModifier = "hidden";
            switch (Mode)
            {
                case "Ajout":
                    unMedia.Langue_vo = Class.Langue.Aucun;
                    unMedia.Sous_titre = Class.Langue.Aucun;
                    unMedia.Langue_Media = Class.Langue.Aucun;
                    unMedia.Statut = Class.StatutMedia.Vide;
                    btnAjouter = "visible";
                    ena = true;
                    enaFilmSerie = true;
                    titreVisi = "visible";
                    break;
                case "Consultation":
                    ena = false;
                    enaFilmSerie = false;
                    unMedia = media;
                    listeGenre = unMedia.Ge;
                    listeDis = unMedia.Pe;
                    btnActiveModif = "visible";
                    titreVisi = "hidden";
                    if (FilmSerie().Result)
                    {
                        VisiDuree = "Visible";
                        VisiNbSaison = "hidden";
                        serie = false;
                        film = true;
                    }
                    else
                    {
                        serie = true;
                        film = false;
                        VisiDuree = "Visible";
                        VisiNbSaison = "Visible";
                    }
                    break;
            }
        }

        public bool enaFilmSerie
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<Enum> SourceStatut
        {
            get
            {
                return GetValue<List<Enum>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<Enum> SourceLangue
        {
            get
            {
                return GetValue<List<Enum>> ();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool serie
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool film
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String listeGenre
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String listeDis
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String btnActiveModif
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String btnAjouter
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String btnModifier
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String titreVisi
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String tbParcourir
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String VisiDuree
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String VisiNbSaison
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool ena
        {

            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
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
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }
        
        public Commands.BaseCommand AddPersonne
        {
            get
            {
                return new Commands.BaseCommand(AjouterPersonne);
            }
        }

        private void AjouterPersonne()
        {
            View.Distribution dis = new View.Distribution(unMedia);
            dis.ShowDialog();
            if (dis.valRetour != null)
            {
                String str = "";
                foreach (Class.Media_Personne gen in dis.valRetour)
                {

                    if (str == "")
                    {
                        str += gen.Personne.nom + " " + gen.Personne.Prenom + "=" + gen.Fontion;
                    }
                    else
                    {
                        str += ";" + gen.Personne.nom + " " + gen.Personne.Prenom + "=" + gen.Fontion;
                    }

                }
                lDis = dis.valRetour;
                listeDis = str;
            }
        }

        public Commands.BaseCommand AddGenre
        {
            get
            {
                return new Commands.BaseCommand(AjouterGenre);
            }
        }

        private void AjouterGenre()
        {
            View.Genre fenGenre = new View.Genre(unMedia);
            fenGenre.ShowDialog();
            if (fenGenre.valRetour != null)
            {
                String str = "";
                foreach (Class.Genre gen in fenGenre.valRetour)
                {
                    if (gen.chk)
                    {
                        if (str == "")
                        {
                            str += gen.nom;
                        }
                        else
                        {
                            str += ";" + gen.nom;
                        }
                    }
                }
                lGenres = fenGenre.valRetour;
                listeGenre = str;
            }
        }


        public Commands.BaseCommand ModifActif
        {
            get
            {
                return new Commands.BaseCommand(EnableChamps);
            }
        }

        private void EnableChamps()
        {
            ena = true;
            btnActiveModif = "hidden";
            titreVisi = "visible";
            btnModifier = "visible";
        }

        public Commands.BaseCommand ModifierMedia
        {
            get
            {
                return new Commands.BaseCommand(ModifMedia);
            }
        }

        private async void ModifMedia()
        {
            var context = await DataAccess.DbContext.GetCurrent();
            context.Update(unMedia);
            if(unMedia.GeListe.Count>0)
            context.RemoveRange(unMedia.Genres);
            if (lGenres != null)
            {
                foreach (Class.Genre gen in lGenres)
                {
                    if (gen.chk)
                    {
                        Class.Media_Genre mg = new Class.Media_Genre();
                        mg.Media = unMedia;
                        mg.Genre = gen;
                        context.Add(mg);
                    }
                }
            }
            if(unMedia.PersonneListe.Count>0)
            context.RemoveRange(unMedia.PersonneMedia);
            if (lDis != null)
            {
                foreach (Class.Media_Personne mp in lDis)
                {
                    mp.Media = unMedia;
                    context.Add(mp);
                }
            }
            context.SaveChanges();
            mvParent.PageCourante = new View.Liste();
            mvParent.PageCourante.DataContext = new ViewModel.Liste(mvParent);
            
        }

        public Commands.BaseCommand AjouterMedia
        {
            get
            {
                return new Commands.BaseCommand(AjoutMedia);
            }
        }

        private async void AjoutMedia()
        {
            var context = await DataAccess.DbContext.GetCurrent();
      
            context.Add(unMedia);
            if (lGenres != null) { 
                foreach (Class.Genre gen in lGenres)
                {
                    Class.Media_Genre mg = new Class.Media_Genre();
                    mg.Media = unMedia;
                    mg.Genre = gen;
                    context.Add(mg);
                }
            }else
            {
                Console.WriteLine("Pas de genre séléctionné");
            }
            
            if(lDis!=null)
            {
                foreach (Class.Media_Personne mp in lDis)
                {
                    mp.Media = unMedia;
                    context.Add(mp);
                }
            }else
            {
                Console.WriteLine("Pas de distribution séléctionné");
            }
            context.SaveChanges();
            mvParent.PageCourante = new View.Liste();
            mvParent.PageCourante.DataContext = new ViewModel.Liste(mvParent);
            
        }

        public Commands.BaseCommand Parcourir
        {
            get
            {
                return new Commands.BaseCommand(ParcourirImage);
            }
        }

        private void ParcourirImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG files (*.jpg)|*.jpg|JEPG files (*.JEPG)|*.JEPG|PNG files (*.png)|*.png";
            ofd.ShowDialog();
            tbParcourir = ofd.FileName;
            Image image = Image.FromFile(tbParcourir);
            unMedia.ImgSet = image;
        }

        public Commands.BaseCommand FilmChk
        {
            get
            {
                return new Commands.BaseCommand(FilmCheck);
            }
        }

        private void FilmCheck()
        {
            VisiDuree = "Visible";
            VisiNbSaison = "hidden";
            unMedia = new Class.Film();
        }

        public Commands.BaseCommand SerieChk
        {
            get
            {
                return new Commands.BaseCommand(SerieChek);
            }
        }

        private void SerieChek()
        {
            VisiDuree = "Visible";
            VisiNbSaison = "Visible";
            unMedia = new Class.Serie();
        }

        public async Task<bool> FilmSerie()
        {
            bool valRetour=false;

            var context = await DataAccess.DbContext.GetCurrent();

            ObservableCollection<Class.Film> lesFilms = new ObservableCollection<Class.Film>(context.Films.Where(f => f.id == unMedia.id).ToList());
            if (lesFilms.Count > 0) {
                unMedia = lesFilms[0];
                valRetour = true;
            }
            ObservableCollection<Class.Serie> lesSerie = new ObservableCollection<Class.Serie>(context.Series.Where(f => f.id == unMedia.id).ToList());
            if (lesSerie.Count > 0)
            {
                unMedia = lesSerie[0];
                valRetour = false;
            }
            return valRetour;
        }
    }
}
