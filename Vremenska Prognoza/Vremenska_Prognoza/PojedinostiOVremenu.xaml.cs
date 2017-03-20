using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class PojedinostiOVremenu : ContentPage
    {
        trenutnoVrijemeViewModel vrijeme;
        public PojedinostiOVremenu(trenutnoVrijemeViewModel tv )
        {
            this.vrijeme = tv;
            InitializeComponent();
            BindingContext = vrijeme;

        }
        public void PrikaziProsjecneVrijednosti(object sender, EventArgs args) {

            Navigation.PushAsync(new StranicaStatistike(vrijeme));
        }
        public void DodajUBazu(object sender, EventArgs args)
        {
            SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();
            db.CreateTable<trenutnoVrijemeViewModel>();
            db.Insert(vrijeme);
            DisplayAlert("Podatci spremljeni", "Podatci su uspješno spremjeni u bazu", "OK");
        }
    }
}
