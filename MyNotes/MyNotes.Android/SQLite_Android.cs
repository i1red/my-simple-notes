using System;
using MyNotes.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MyNotes.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDataBasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}