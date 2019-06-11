using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjetDotNet.ViewModel
{
    class Liste : Inotifier
    {
        private MainViewModel mvParent;
        public Liste(MainViewModel parent) {
            mvParent = parent;
            LoadDataTrie();
            Genres = LoadDataGenre().Result;
            Medias = LoadData().Result;
        }

        public ObservableCollection<Class.Genre> Genres {

            get
            {
                return GetValue<ObservableCollection<Class.Genre>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public ObservableCollection<Class.Media> Medias
        {
            get
            {
                return GetValue<ObservableCollection<Class.Media>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public string tbTitre
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

        public string tbNote
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        public Class.Media MediaSelectionne
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

        public String TrieSelectionne
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                Medias = LoadData(value).Result;
                SetValue(value);
            }
        }

        public List<String> ListeTrie
        {
            get
            {

                return GetValue<List<String>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public void LoadDataTrie() {
            List<String> lTrie = new List<String> { "Aucun","Nom a -> z", "Nom z -> a", "Note 0 -> 5", "Note 5 -> 0" };
            ListeTrie = lTrie;
        }

        public async Task<ObservableCollection<Class.Media>> LoadData(String value="")
        {

            var context = await DataAccess.DbContext.GetCurrent();
            ObservableCollection<Class.Media> med;
            var req = context.Medias.Include(m => m.Genres).Where(m => 1==1);
            if (tbTitre!=null && tbTitre.Trim() != "")
            {
                req = req.Where(m => m.Titre.Contains(tbTitre.Trim()));
            }
            if (tbNote != null && tbNote.Trim() != "")
            {
                req = req.Where(m => m.Note == Int32.Parse(tbNote.Trim()));
            }

            var genresCoches = Genres.Where(gv => gv.chk == true);
            req = req.Where(m => m.Genres.Where(g => genresCoches.Where(gc => gc.id == g.GenreId).Count() > 0).Count() > 0);

            switch (value)
            {
                case "Nom a -> z":
                    med = new ObservableCollection<Class.Media>(req.OrderBy(m=> m.Titre));
                    break;
                case "Nom z -> a":
                    med = new ObservableCollection<Class.Media>(req.OrderByDescending(m => m.Titre));
                    break;
                case "Note 0 -> 5":
                    med = new ObservableCollection<Class.Media>(req.OrderBy(m => m.Note));
                    break;
                case "Note 5 -> 0":
                    med = new ObservableCollection<Class.Media>(req.OrderByDescending(m => m.Note));
                    break;
                default:
                    med = new ObservableCollection<Class.Media>(req);
                    break;

            }

            return med;
        }
        
        public async Task<ObservableCollection<Class.Genre>> LoadDataGenre()
        {
            var context = await DataAccess.DbContext.GetCurrent();
            return new ObservableCollection<Class.Genre>(context.Genres.ToList());
        }

        public Commands.BaseCommand CommandeVoirMedia
        {
            get
            {
                return new Commands.BaseCommand(VoirMedia);
            }
        }

        private void VoirMedia()
        {
            mvParent.PageCourante= new View.PageMedia(mvParent);
            
            mvParent.PageCourante.DataContext = new ViewModel.PageMedia(mvParent, MediaSelectionne);
        }

        public Commands.BaseCommand btnFiltrer
        {
            get
            {
                return new Commands.BaseCommand(Filtrer);
            }
        }

        private void Filtrer()
        {
            Medias = LoadData(TrieSelectionne).Result;
        }
    }
}
