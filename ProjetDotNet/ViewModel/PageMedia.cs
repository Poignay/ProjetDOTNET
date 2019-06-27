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

        public PageMedia(MainViewModel parent)
        {
            mvParent = parent;
        }

        public PageMedia(MainViewModel parent,Class.Media media,String Mode)
        {
            mvParent = parent;
            List<string> lLangue = new List<string>();
            foreach(string uneEnum in Enum.GetNames(typeof(Class.Langue)))
            {
                lLangue.Add(uneEnum);
            }
            SourceLangue = lLangue;
            btnActiveModif = "hidden";
            btnAjouter = "hidden";
            btnModifier = "hidden";
            switch (Mode)
            {
                case "Ajout":
                    unMedia = null;
                    unMedia = new Class.Media();
                    unMedia.Langue_vo = Class.Langue.Aucun;
                    unMedia.Sous_titre = Class.Langue.Aucun;
                    unMedia.Langue_Media = Class.Langue.Aucun;
                    unMedia = unMedia;
                    btnAjouter = "visible";
                    ena = true;
                    titreVisi = "visible";
                    break;
                case "Consultation":
                    ena = false;
                    unMedia = media;
                    btnActiveModif = "visible";
                    titreVisi = "hidden";
                    break;
            }
        }

        public List<String> SourceLangue
        {
            get
            {
                return GetValue<List<String>> ();
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
            unMedia.Genres.RemoveRange(0, unMedia.Genres.Count);
            foreach (Class.Genre gen in fenGenre.valRetour)
            {
                if (gen.chk)
                {
                    Class.Media_Genre unMediaGenre = new Class.Media_Genre();
                    unMediaGenre.GenreId = gen.id;
                    unMediaGenre.MediaId = unMedia.id;
                }
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
            context.SaveChanges();
            MessageBox.Show("");
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
    }
}
