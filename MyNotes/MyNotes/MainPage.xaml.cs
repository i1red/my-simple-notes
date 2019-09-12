using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MyNotes.Views;
using MyNotes.ViewModels;
using MyNotes.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyNotes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public static Color barColor;
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new AllNotes()) {BarBackgroundColor = Color.FromHex(App.settings.AppTheme.BarColor) };
            Master.BackgroundColor = Color.FromHex(MasterPageColor);
        }

        public string TextColor
        {
            get { return App.settings.AppTheme.TextColor; }
        }
        public string MasterPageColor
        {
            get {return App.settings.AppTheme.MasterPageColor; }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = (string)e.SelectedItem;
            switch(menuItem)
            {
                case "ALL NOTES":
                    Detail = new NavigationPage(new AllNotes()) { BarBackgroundColor = Color.FromHex(App.settings.AppTheme.BarColor) };
                    break;
                case "FAVORITES":
                    Detail = new NavigationPage(new Favorites()) { BarBackgroundColor = Color.FromHex(App.settings.AppTheme.BarColor) };
                    break;
                case "SETTINGS":
                    Detail = new NavigationPage(new Settings()) { BarBackgroundColor = Color.FromHex(App.settings.AppTheme.BarColor) };
                    break;
            }
        }

    }
}
