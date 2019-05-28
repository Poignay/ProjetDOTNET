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
        }

        private ObservableCollection<Class.Media> _media;
        public ObservableCollection<Class.Media> Medias
        {
            get
            {
                return LoadData().Result;
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

        public async Task<ObservableCollection<Class.Media>> LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();

            // Sélection des medias
            return new ObservableCollection<Class.Media>(context.Medias.Include(m => m.Genres));


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
    }
}
