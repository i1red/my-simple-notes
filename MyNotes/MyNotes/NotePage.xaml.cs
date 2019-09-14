using System;

using MyNotes.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        public string DetailPageColor
        {
            get { return AppSettings.Instance.AppTheme.DetailPageColor; }
        }

        public NotePage()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex(AppSettings.Instance.AppTheme.DetailPageColor);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            var note = (NoteVM)BindingContext;
            note.Text = editor.Text;
            App.Database.SaveItem(note.cur);
            bool flag = true;

            foreach (var item in App.allNotes)
            {
                if (item.cur.Id == note.cur.Id)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
                App.allNotes.Insert(0, note);

            Navigation.PopAsync();
        }
    }
}