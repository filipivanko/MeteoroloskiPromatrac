using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class StranicaStatistike : ContentPage
    {
        List<trenutnoVrijemeViewModel> ocitanjaSLokacije;
        StatistikaViewModel podaciZaPrikazati;
        SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();

        public StranicaStatistike(trenutnoVrijemeViewModel lokacija)
        {
            db.CreateTable<trenutnoVrijemeViewModel>();
            InitializeComponent();
            ocitanjaSLokacije = db.Query<trenutnoVrijemeViewModel>("Select * from OcitanjaVremena where lokacija='"+lokacija.Lokacija+"'");
            podaciZaPrikazati = new StatistikaViewModel(ocitanjaSLokacije);
           BindingContext = podaciZaPrikazati;
            Tablica.ItemsSource = ocitanjaSLokacije;

        }
    }
}
