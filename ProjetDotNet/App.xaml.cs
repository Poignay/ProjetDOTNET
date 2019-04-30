using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetDotNet
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            String fpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (System.IO.File.Exists(fpath)) System.IO.File.Delete(fpath);
            var context = await DataAccess.DbContext.GetCurrent();

            
        }
    }
}
