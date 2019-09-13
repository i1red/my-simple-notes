using Xamarin.Forms;
using System.Collections.ObjectModel;
using MyNotes.ViewModels;
using MyNotes.Models;

namespace MyNotes
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "notes.db";
        public static NotesRepository database;
        public static ObservableCollection<NoteVM> allNotes;
        public static AppSettings settings;
        public static MainPage mPage;

        public App()
        {
            InitializeComponent();
            allNotes = new ObservableCollection<NoteVM>();
            settings = AppSettings.Instance;

            foreach (Note item in Database.GetItems())
                allNotes.Insert(0, new NoteVM() { cur = item });

            MainPage = mPage = new MainPage();
        }

        public static NotesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new NotesRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            settings.SaveConfig();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
