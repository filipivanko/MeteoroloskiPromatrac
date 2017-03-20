using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class StranicaTrenutneLokacije : ContentPage
    {
       static trenutnoVrijemeViewModel viewModel = new trenutnoVrijemeViewModel("-", "-", "-", "-", "-", "-","-","-","-");
        public StranicaTrenutneLokacije()
        {
            InitializeComponent();
            BindingContext = viewModel;
            if (viewModel.Lokacija == "-")
            {
                DisplayAlert("Lokacija nije utvrđena", "Kada vaš uređaj utvrdi vašu lokaciju pokazati će se trenutni meteorološki podatci za vašu lokaciju", "OK");
            }
        }
        async public static void dohvati(Pozicija mojaPozicija)
        {

            RootObjectWeatherUnderground vrijeme;
            HttpClient client = new HttpClient();
            DateTime sad = DateTime.Now; 
            try
            {
               
                client.BaseAddress = new Uri(string.Format("http://api.wunderground.com/api/787d290265a86678/conditions/q/{0},{1}.json", mojaPozicija.Latitude.ToString("0.000000", new CultureInfo("en-US")), mojaPozicija.Longtitude.ToString("0.000000", new CultureInfo("en-US")), new CultureInfo("en-US")));                                                     
                client.DefaultRequestHeaders.Add("Get", "application/json");
                var response = await client.GetAsync(client.BaseAddress);
                var jsonRezultat = response.Content.ReadAsStringAsync().Result;

                vrijeme = JsonConvert.DeserializeObject<RootObjectWeatherUnderground>(jsonRezultat);
                viewModel.DatumIVrijeme = sad.Day.ToString() + ". " + sad.Month.ToString() + ". " + sad.Year.ToString()+" / " + sad.Hour.ToString() + "h"; 
                    viewModel.Temperatura = vrijeme.current_observation.temp_c.ToString(new CultureInfo("en-US"))+"*C";
                    viewModel.OpisVremena = vrijeme.current_observation.weather;
                    viewModel.Tlak = vrijeme.current_observation.pressure_mb;
                    viewModel.Vlaga = vrijeme.current_observation.relative_humidity ;
                    viewModel.Drzava = vrijeme.current_observation.observation_location.country;
                    viewModel.Lokacija = vrijeme.current_observation.observation_location.city;
                    viewModel.BrzinaVjetra = vrijeme.current_observation.wind_kph.ToString(new CultureInfo("en-US"));
                    viewModel.SmjerVjetra = vrijeme.current_observation.wind_dir; 
            }
            catch (Exception) {
                 DependencyService.Get<IOdrediPoziciju>().dogodilaSegreška();
            }
        }
        public void PrikaziProsjecneVrijednosti(object sender, EventArgs args)
        {
            if (viewModel.Lokacija != "-" || viewModel.Temperatura != "-" || viewModel.Tlak != "-" || viewModel.Vlaga != "-")
            {
                Navigation.PushAsync(new StranicaStatistike(viewModel));
            }
            else {
                DisplayAlert("Nije moguće dohvatiti podatke", "Nije određena trenutna lokacija", "OK");
            }
           
        }
        public void DodajUBazu (object sender, EventArgs args)
        {
            if (viewModel.Lokacija != "-" ||viewModel.Temperatura!="-" || viewModel.Tlak!="-" || viewModel.Vlaga!="-")
            {
                SQLiteConnection db = DependencyService.Get<ISQLite>().getKonekcija();
                db.CreateTable<trenutnoVrijemeViewModel>();
                db.Insert(viewModel);
                DisplayAlert("Podatci spremljeni", "Podatci su uspješno spremjeni u bazu", "OK");
            }
            else {
                DisplayAlert("Podatci nisu spremljeni", "Nije određena trenutna lokacija", "OK");
            }
                 
        }
    }
}
