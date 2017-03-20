using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class SviZapisi : ContentPage
    {
        SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();
        List<trenutnoVrijemeViewModel> ocitanja;
        public SviZapisi()
        {
            db.CreateTable<trenutnoVrijemeViewModel>();
            ocitanja = db.Query<trenutnoVrijemeViewModel>("Select * from OcitanjaVremena");
            InitializeComponent();
            Tablica.ItemsSource = ocitanja;
        }
    }
}
