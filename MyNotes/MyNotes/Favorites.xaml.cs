using System.Collections.ObjectModel;

using MyNotes.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex(App.settings.AppTheme.DetailPageColor);
            FavNoteLV.Notes = new ObservableCollection<NoteVM>();
            foreach (NoteVM item in App.allNotes)
                if(item.IsFavorite)
                    FavNoteLV.Notes.Add(item);

            FavNoteLV.Content.BindingContext = FavNoteLV;
            BindingContext = this;
        }
        
        public string DetailPageColor
        {
            get { return App.settings.AppTheme.DetailPageColor; }
        }
        private async void FavSelected(NoteVM note)
        {
            var notePage = new NotePage() { BindingContext = note };
            await Navigation.PushAsync(notePage);
        }
        private void FavDelete_Clicked(NoteVM note)
        {
            App.allNotes.Remove(note);
            FavNoteLV.Notes.Remove(note);
            App.Database.DeleteItem(note.cur.Id);
        }
        private void FavState_Clicked(NoteVM note)
        {
            note.IsFavorite = !note.IsFavorite;
            FavNoteLV.Notes.Remove(note);
        }
    }
}