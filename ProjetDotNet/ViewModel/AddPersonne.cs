using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetDotNet.ViewModel
{
    class AddPersonne : Inotifier
    {
        View.AddPersonne windowPersonne;
        public AddPersonne(View.AddPersonne wPersonne)
        {
            windowPersonne = wPersonne;
            List<string> lNationalite = new List<string>();
            foreach (string uneEnum in Enum.GetNames(typeof(Class.Langue)))
            {
                lNationalite.Add(uneEnum);
            }
            ListeNationalite = lNationalite;
            List<string> lCivilite = new List<string>();
            foreach (string uneEnum in Enum.GetNames(typeof(Class.Civilite)))
            {
                lCivilite.Add(uneEnum);
            }
            ListeCivilité = lCivilite;
            unePersonne = new Class.Personne();
            unePersonne.Civilite = Class.Civilite.Aucun;
            unePersonne.Nationalite = Class.Langue.Aucun;
        }
        public List<String> ListeNationalite
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

        public List<String> ListeCivilité
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


        public Class.Personne unePersonne
        {
            get
            {
                return GetValue<Class.Personne>();
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



        public Commands.BaseCommand Ajouter
        {
            get
            {
                return new Commands.BaseCommand(AjoutPersonne);
            }
        }

        private async void AjoutPersonne()
        {
            var context = await DataAccess.DbContext.GetCurrent();
            context.Add(unePersonne);
            context.SaveChanges();
            windowPersonne.Close();

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
            unePersonne.ImgSet = image;
        }
    }
}
