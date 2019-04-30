using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.ViewModel
{
    class Liste
    {
        private ObservableCollection<Class.Media> _personnes;
        public ObservableCollection<Class.Media> Personnes
        {
            get
            {
                if (_personnes == null) _personnes = new ObservableCollection<Class.Media>();
                return _personnes;
            }
        }

        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection des medias
            context.Medias.Include(m => m.Genres).ToList();


        }
    }
}
