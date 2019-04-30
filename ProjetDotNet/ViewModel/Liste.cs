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
        private ObservableCollection<Class.Media> _media;
        public ObservableCollection<Class.Media> Medias
        {
            get
            {
                return LoadData().Result;
            }
        }

        public async Task<ObservableCollection<Class.Media>> LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection des medias
            return new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres));


        }
    }
}
