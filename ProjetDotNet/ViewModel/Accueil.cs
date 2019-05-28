using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.ViewModel
{
    class Accueil
    {
        private MainViewModel mvParent;
        public Accueil(MainViewModel parent)
        {
            mvParent = parent;
        }

        private ObservableCollection<Class.Media> _myOb;
        public ObservableCollection<Class.Media> myOb
        {
            get
            {
                LoadData();
                return _myOb;
            }
            set
            {
                myOb = _myOb;
            }
        }
        private String _titre;
        public String Titre
        {
            get
            {
                return _titre;
            }
            set
            {
                Titre = _titre;
            }
        }

        public int nbrMedia
        {
            get;
            set;
        }


        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            context.Add(new Class.Media()
            {
                Titre = "Film1",
            });

            // Enregistrement
            await context.SaveChangesAsync();

            // Sélection des medias
            ObservableCollection<Class.Media> myOb = new ObservableCollection<Class.Media>(context.Medias);

            foreach (Class.Media i in myOb)
            {
                _titre = i.Titre;
            }

        }
    }
}
