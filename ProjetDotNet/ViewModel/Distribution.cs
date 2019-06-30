using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.ViewModel
{
    class Distribution : Inotifier
    {
        public View.Distribution vDis;
        public Distribution(Class.Media med, View.Distribution dis)
        {
            unMedia = med;
            LoadData();
            vDis = dis;
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
        
         public List<Class.Personne> ListePersonne
        {
            get
            {
                return GetValue<List<Class.Personne>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<Class.Media_Personne> ListeDistribution
        {
            get
            {
                return GetValue<List<Class.Media_Personne>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<String> ListeFonction
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

        public async Task LoadData()
        {

            var context = await DataAccess.DbContext.GetCurrent();
            ObservableCollection<Class.Personne> lPersonnes = new ObservableCollection<Class.Personne>(context.Personnes.ToList());
            ListePersonne = lPersonnes.ToList();
            ListePersonne.Add(new Class.Personne { nom = "Aucun", Prenom = "" });
            List<string> lFonction = new List<string>();
            foreach (string uneEnum in Enum.GetNames(typeof(Class.Fonction)))
            {
                lFonction.Add(uneEnum);
            }
            ListeFonction = lFonction;
            if (unMedia != null)
            {
                ObservableCollection<Class.Media_Personne> lPersonneMedia = new ObservableCollection<Class.Media_Personne>(context.Media_Personnes.Where(mp => mp.Media.id == unMedia.id));
                
                ListeDistribution = lPersonneMedia.ToList(); ;
                
            
            }
        }


        public Commands.BaseCommand CreerPersonne
        {
            get
            {
                return new Commands.BaseCommand(CPersonne);
            }
        }

        private void CPersonne()
        {
            View.AddPersonne fen = new View.AddPersonne();
            fen.ShowDialog();
            LoadData();
        }

        public Commands.BaseCommand AjoutLigne
        {
            get
            {
                return new Commands.BaseCommand(AjouterLigne);
            }
        }

        private void AjouterLigne()
        {
            ListeDistribution.Add(
                new Class.Media_Personne()
                    { Fontion = Class.Fonction.Aucun }
                
            );
            ListeDistribution = ListeDistribution;
        }

        public Commands.BaseCommand ValiderDistribution
        {
            get
            {
                return new Commands.BaseCommand(Valider);
            }
        }

        private void Valider()
        {

            vDis.valRetour = ListeDistribution;
            vDis.DialogResult = true;
            vDis.Close();

        }
    }
}
