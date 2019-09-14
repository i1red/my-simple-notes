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
            switcher.IsToggled = AppSettings.Instance.darkTheme;
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
            get { return AppSettings.Instance.AppTheme.DetailPageColor; }
        }

        public string TextColor
        {
            get { return AppSettings.Instance.AppTheme.TextColor; }
        }

        public string StrFontSize
        {
            get { return AppSettings.Instance.FontSize.ToString(); }
        }

        public int FontSize
        {
            get { return AppSettings.Instance.FontSize; }
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AppSettings.Instance.FontSize = (int)e.NewValue;
            fValLabel.Text = e.NewValue.ToString();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            switcher.IsToggled = AppSettings.Instance.darkTheme = e.Value;

            if (switcher.IsToggled)
                AppSettings.Instance.AppTheme = Theme.DarkTheme;
            else
                AppSettings.Instance.AppTheme = Theme.LightTheme;

            ResetTheme();

            App.mPage.Master.BackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.MasterPageColor);
            App.mPage.TextColor = AppSettings.Instance.AppTheme.TextColor;
            var current = App.mPage.Detail as NavigationPage;

            if(current != null)
                current.BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor);

        }
    }
}