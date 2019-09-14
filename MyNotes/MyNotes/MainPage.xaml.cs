using System.ComponentModel;
using Xamarin.Forms;

namespace MyNotes
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public class Paragraph : INotifyPropertyChanged
        {
            public string Text { get; set; }

            public string color = null;

            public string Color
            {
                set
                {
                    if (color != value)
                    {
                        color = value;
                        OnPropertyChanged("Color");
                    }
                }
                get { return color; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propName)
            {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Paragraph[] menuItems = {new Paragraph(){Text = "ALL NOTES" }, new Paragraph() { Text = "FAVORITES"},
            new Paragraph() {Text = "SETTINGS" } };

        public Paragraph[] MenuItems
        {
            get { return menuItems; }
        }

        private string textColor = null;

        public string TextColor
        {
            set
            {
                if (textColor != value)
                {
                    textColor = value;
                    for (int i = 0; i < 3; ++i)
                        menuItems[i].Color = value;
                    OnPropertyChanged("TextColor");
                }
            }
            get { return textColor; }
        }

        public string MasterPageColor
        {
            get { return AppSettings.Instance.AppTheme.MasterPageColor; }
        }

        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new AllNotes()) { BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor) };
            Master.BindingContext = this;
            TextColor = AppSettings.Instance.AppTheme.TextColor;
            Master.BackgroundColor = Color.FromHex(MasterPageColor);

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = (Paragraph)e.SelectedItem;
            switch(menuItem.Text)
            {
                case "ALL NOTES":
                    Detail = new NavigationPage(new AllNotes()) { BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor) };
                    break;
                case "FAVORITES":
                    Detail = new NavigationPage(new Favorites()) { BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor) };
                    break;
                case "SETTINGS":
                    Detail = new NavigationPage(new Settings()) { BarBackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.BarColor) };
                    break;
            }
        }
    }
}
