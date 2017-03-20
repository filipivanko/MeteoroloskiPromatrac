using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class OdaberiPostaju : ContentPage
    {
        List<trenutnoVrijemeViewModel> postaje;

        public OdaberiPostaju(List<trenutnoVrijemeViewModel> stanice)
        {
            InitializeComponent();
            postaje = stanice;
            lista.ItemsSource = postaje;
            
        }
        public void IzaberiPostaju(Object sender, ItemTappedEventArgs args)
        {

            Navigation.PushAsync(new PojedinostiOVremenu((trenutnoVrijemeViewModel)args.Item));

        }
        public async void Osvjezi(Object sender, EventArgs args)
        {

            HvatacPostaja.ocitanjaHrvatska = HvatacPostaja.dohvatiPostaje(@"http://vrijeme.hr/hrvatska_n.xml");
            HvatacPostaja.ocitanjaEuropa = HvatacPostaja.dohvatiPostaje(@"http://vrijeme.hr/europa_n.xml");
            lista.ItemsSource = postaje;
            await DisplayAlert("Postaje ažurirane", "Podatci sa svih postaja koje se prate su ažurirani", "Ok");
        }
        public async void DohvatiSve(object sender, EventArgs args)
        {
            SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();

            if (await DisplayAlert("Jeste li sigurni?", "U bazu će te stpremiti podatke svih postaja sa popisa", "da", "ne"))
            {
               
                db.CreateTable<trenutnoVrijemeViewModel>();
                foreach (trenutnoVrijemeViewModel t in postaje)
                {
                    db.Insert(t);
                }
                await DisplayAlert("Podatci spremjeni", "Uspješno ste spremili podatke u bazu", "OK");
            }
        }
    }
}
