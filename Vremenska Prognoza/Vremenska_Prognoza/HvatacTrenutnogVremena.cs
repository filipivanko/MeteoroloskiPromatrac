using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

using System.IO;

namespace Vremenska_Prognoza
{
    class HvatacTrenutnogVremena
    {
        RootObject OcitanoVrijeme;

        //api.openweathermap.org/data/2.5/weather?lat=35&lon=139
        //959d60910cd9352d28927bf004c20f5b
        /*http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=44db6a862fba0b067b1930da0d769e98 */
        public HvatacTrenutnogVremena()
        {
        }
         async  public Task<string> dohvati()
        {
           // RootObject vrijeme;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=44db6a862fba0b067b1930da0d769e98");
            client.DefaultRequestHeaders.Add("Get", "application/json");
            var response = await client.GetAsync(client.BaseAddress);
            var jsonRezultat =  response.Content.ReadAsStringAsync().Result;
           /* vrijeme = JsonConvert.DeserializeObject<RootObject>(jsonRezultat);

            OcitanoVrijeme = vrijeme;

            trenutnoVrijemeViewModel viewModel =
            new trenutnoVrijemeViewModel(
            OcitanoVrijeme.main.temp.ToString(),
            OcitanoVrijeme.weather[0].description,
            OcitanoVrijeme.main.pressure.ToString(),
            OcitanoVrijeme.main.humidity.ToString(),
            OcitanoVrijeme.sys.country,
            OcitanoVrijeme.name);
            */
            return jsonRezultat;
            

        }
    }
}
