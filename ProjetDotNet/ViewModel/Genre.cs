using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.ViewModel
{
    class Genre : Inotifier
    {
        private Class.Media unMedia;
        public struct StructGenre
        {
            public String nom;
            public bool chk;
        }
        private View.Genre vGenre;
        public Genre(Class.Media med, View.Genre gen)
        {
            unMedia = med;
            LoadData();
            vGenre = gen;
        }


        public ObservableCollection<Class.Genre> lesGenres
        {
            get
            {
                return GetValue<ObservableCollection<Class.Genre>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public String tbGenre 
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

        public async Task LoadData(String value = "")
        {

            var context = await DataAccess.DbContext.GetCurrent();
            ObservableCollection<Class.Genre> lgenres = new ObservableCollection<Class.Genre>(context.Genres.ToList());
            if (unMedia != null)
            {
                ObservableCollection<Class.Genre> lgenresMedia = new ObservableCollection<Class.Genre>(context.Genres.Include(g => g.Media).Where(g => g.Media.Where(m => m.Media.id == unMedia.id).Count() > 0));
                foreach (Class.Genre unGenre in lgenres)
                {
                    Boolean val = false;
                    foreach (Class.Genre genreMedia in lgenresMedia)
                    {
                        if (unGenre.id == genreMedia.id)
                        {
                            val = true;
                        }
                    }
                    if (val)
                    {
                        unGenre.chk = true;
                    }
                    else
                    {
                        unGenre.chk = false;
                    }
                }
            }
            else
            {
                foreach (Class.Genre unGenre in lgenres)
                {
                    unGenre.chk = false;
                }

            }
            lesGenres = lgenres;
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
            AjouterGenreDbb();
            LoadData();
            tbGenre = "";
        }
        private async Task AjouterGenreDbb()
        {
            var context = await DataAccess.DbContext.GetCurrent();


            Class.Genre unGenre = new Class.Genre()
            {
                nom = tbGenre
            };
            context.Add(unGenre);
            context.SaveChanges();
        }

        public Commands.BaseCommand ValiderGenre
        {
            get
            {
                return new Commands.BaseCommand(ValGenre);
            }
        }
        private void ValGenre()
        {
            
            vGenre.valRetour = lesGenres.ToList();
            vGenre.DialogResult = true;
            vGenre.Close();
        }
    }
}
