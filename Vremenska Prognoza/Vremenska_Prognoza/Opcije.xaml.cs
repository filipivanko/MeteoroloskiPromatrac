using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class Opcije : ContentPage
    {
        SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();
        public Opcije()
        {
            db.CreateTable<trenutnoVrijemeViewModel>();
            InitializeComponent();
        }

        public async void ObrisiSve(object sender, EventArgs args)
        {
            if (await DisplayAlert("Jeste li sigurni?", "Svi zapisi u bazi biti će obrisani", "da", "ne"))
            {
                db.Query<trenutnoVrijemeViewModel>("Drop table OcitanjaVremena");
              await  DisplayAlert("Podatci obrisani", "Svi zapisi u bazi su obrisani", "Ok");
            }

        }
        public async void PrikaziSveZapise(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SviZapisi());
        }

        public  void Info(object sender, EventArgs args)
        {
            Navigation.PushAsync(new OAplikaciji());
        }
    }
}
