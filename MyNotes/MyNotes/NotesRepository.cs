using System.Collections.Generic;
using System.Linq;
using SQLite;
using MyNotes.Models;
using Xamarin.Forms;

namespace MyNotes
{
    public class NotesRepository
    {
        SQLiteConnection database;
        public NotesRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDataBasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
        }
        public IEnumerable<Note> GetItems()
        {
            return (from i in database.Table<Note>() select i).ToList();

        }
        public Note GetItem(int id)
        {
            return database.Get<Note>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Note>(id);
        }
        public int SaveItem(Note item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
