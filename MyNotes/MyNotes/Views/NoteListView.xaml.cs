using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyNotes.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes.Views
{
    public delegate void ItemSelectedEventHandler(NoteVM note);
    public delegate void ItemDeleteEventHandler(NoteVM note);
    public delegate void ItemFavStateEventHandler(NoteVM note);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListView : ContentView
    {
        public event ItemSelectedEventHandler Select;
        public event ItemDeleteEventHandler Delete;
        public event ItemFavStateEventHandler FavState;

        /*public static readonly BindableProperty NotesProperty =
            BindableProperty.Create("Notes", typeof(ObservableCollection<NoteVM>), typeof(ListView));*/
        public ObservableCollection<NoteVM> Notes { get; set; }
        public NoteListView()
        {
            InitializeComponent();
            //LV.BindingContext = Notes;
            //Content.BindingContext = this;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNote = (NoteVM)e.SelectedItem;
            Select?.Invoke(selectedNote);
        }
        private void ItemDelete_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button?.BindingContext as NoteVM;
            Delete?.Invoke(note);
        }
        private void ItemFavState_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button?.BindingContext as NoteVM;
            FavState?.Invoke(note);
        }
    }
}