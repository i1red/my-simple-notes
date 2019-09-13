using System;

using MyNotes.Models;
using MyNotes.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllNotes : ContentPage
    {
        public AllNotes()
        {
            InitializeComponent();
            NoteLV.Notes = App.allNotes;
            BackgroundColor = Color.FromHex(App.settings.AppTheme.DetailPageColor);
            NoteLV.Content.BindingContext = NoteLV;
            BindingContext = this;
        }

        private async void NewNote_Clicked(object sender, EventArgs e)
        {
            var note = new NoteVM() { cur = new Note() };
            var notePage = new NotePage() { BindingContext = note };
            await Navigation.PushAsync(notePage);
        }

        private async void Selected(NoteVM note)
        {
            var notePage = new NotePage() { BindingContext = note };
            await Navigation.PushAsync(notePage);
        }

        private void Delete_Clicked(NoteVM note)
        {
            NoteLV.Notes.Remove(note);
            App.Database.DeleteItem(note.cur.Id);
        }

        private void FavState_Clicked(NoteVM note)
        {
            note.IsFavorite = !note.IsFavorite;
            App.Database.SaveItem(note.cur);
        }
    }
}