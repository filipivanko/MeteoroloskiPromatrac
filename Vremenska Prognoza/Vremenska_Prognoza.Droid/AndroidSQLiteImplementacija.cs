using System;
using SQLite;
using MeteoroloskiPromatrac.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLiteImplementacija))]
namespace MeteoroloskiPromatrac.Droid
{

    class AndroidSQLiteImplementacija : ISQLite
    {
        public SQLiteConnection getKonekcija()
        {
            var sqliteFilename = "Baza.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            SQLiteConnection konekcija = new SQLite.SQLiteConnection(path);
            return konekcija;

        }
    }
}