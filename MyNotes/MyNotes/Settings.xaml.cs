using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            switcher.IsToggled = App.settings.darkTheme;
            fSizeLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            fValLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            themeLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            fValLabel.Text = AppSettings.Instance.FontSize.ToString();
            stepper.Value = AppSettings.Instance.FontSize;
            BackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.DetailPageColor);
        }
        private void ResetTheme()
        {
            fSizeLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            fValLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            themeLabel.TextColor = Color.FromHex(AppSettings.Instance.AppTheme.TextColor);
            BackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.DetailPageColor);

        }
        public string DetailPageColor
        {
            get { return App.settings.AppTheme.DetailPageColor; }
        }
        public string TextColor
        {
            get { return App.settings.AppTheme.TextColor; }
        }
        public string StrFontSize
        {
            get { return App.settings.FontSize.ToString(); }
        }
        public int FontSize
        {
            get { return App.settings.FontSize; }
        }
        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AppSettings.Instance.FontSize = (int)e.NewValue;
            fValLabel.Text = e.NewValue.ToString();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            switcher.IsToggled = App.settings.darkTheme = e.Value;
            if (switcher.IsToggled)
                App.settings.AppTheme = Theme.DarkTheme;
            else
                App.settings.AppTheme = Theme.LightTheme;

            ResetTheme();
            App.mPage.Master.BackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.MasterPageColor);
            var current = App.mPage.Detail as NavigationPage;
            if(current != null)
                current.BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor);

        }
    }
}