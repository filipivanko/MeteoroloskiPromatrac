using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new PocetnaStranica());
           
        }

        protected override void OnStart()
        {
            HvatacPostaja.dohvatiDomacePostaje();
            HvatacPostaja.dohvatiEuropskePostaje();
            DependencyService.Get<IOdrediPoziciju>().ukljuciGps();
        }

        protected override void OnSleep()
        {
            DependencyService.Get<IOdrediPoziciju>().iskljuciGps();
        }

        protected override void OnResume()
        {
            DependencyService.Get<IOdrediPoziciju>().ukljuciGps();
        }
    }
}
