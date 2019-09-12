using System.ComponentModel;
using MyNotes.Models;

namespace MyNotes.ViewModels
{
    public class NoteVM : INotifyPropertyChanged
    {
        public Note cur { get; set; }
        public string Text
        {
            get { return cur.text; }
            set
            {
                if (cur.text != value)
                {
                    cur.text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string TextColor
        {
            get { return App.settings.AppTheme.TextColor; }
        }

        public int FontSize
        {
            get { return App.settings.FontSize; }
        }
        public bool IsFavorite
        {
            get { return cur.isFavorite; }
            set
            {
                if (cur.isFavorite != value)
                {
                    cur.isFavorite = value;
                    OnPropertyChanged("IsFavorite");
                    OnPropertyChanged("FavState");
                    OnPropertyChanged("FavTextColor");
                    OnPropertyChanged("FavBackColor");
                }
            }
        }

        public string FavState
        {
            get { return cur.isFavorite ? "Unfavorite" : "Favorite"; }
        }
        public string FavTextColor
        {
            get { return cur.isFavorite ? "#F0FFF0" : "#FFA500"; }
        }
        public string FavBackColor
        {
            get { return cur.isFavorite ? "#FFA500" : "#F0FFF0"; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
