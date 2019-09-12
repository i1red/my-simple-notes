using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MyNotes
{
    public class AppSettings : INotifyPropertyChanged
    {
        const string CONFIG_NAME = "config.json";

        public bool darkTheme;
        private AppSettings()
        {
            string configPath = DependencyService.Get<ISQLite>().GetDataBasePath(CONFIG_NAME);
            if(!File.Exists(configPath))
            {
                using (var writer = File.CreateText(configPath))
                {
                    writer.Write(@"['18', 'true']");
                }
                fontSize = 18;
                darkTheme = true;
                appTheme = Theme.DarkTheme;

            }
            else
            {
                string data = File.ReadAllText(configPath);
                string[] conf = JsonConvert.DeserializeObject<string[]>(data);
                fontSize = int.Parse(conf[0]);
                darkTheme = bool.Parse(conf[1]);
                AppTheme = darkTheme ? Theme.DarkTheme : Theme.LightTheme;
            }
            
        }

        public void SaveConfig()
        {
            string configPath = DependencyService.Get<ISQLite>().GetDataBasePath(CONFIG_NAME);
            using (var writer = File.CreateText(configPath))
            {
                writer.Write($@"['{fontSize}', '{darkTheme}']");
            }
        }

        private static AppSettings instance = null;
        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppSettings();
                return instance;
            }
        }
        private int fontSize;
        public int FontSize
        {
            get { return fontSize; }
            set
            {
                if (fontSize != value)
                {
                    fontSize = value;
                    OnPropertyChanged("FontSize");
                    OnPropertyChanged("StrFontSize");
                }
            }
        }
        public string StrFontSize
        {
            get { return fontSize.ToString(); }
        }

        private Theme appTheme;
        public Theme AppTheme
        {
            get { return appTheme; }
            set
            {
                if(appTheme != value)
                {
                    appTheme = value;
                    OnPropertyChanged("AppTheme");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
