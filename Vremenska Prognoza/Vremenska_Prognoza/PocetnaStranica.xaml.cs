using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class PocetnaStranica : ContentPage
    {
        public PocetnaStranica()
        {
            InitializeComponent();
            BindingContext = this;


        }
        public void PrikaziStaniceUHrvatskoj(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new OdaberiPostaju(HvatacPostaja.dohvatiDomacePostaje()));
        }
        public void PrikaziStaniceUEuropi(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new OdaberiPostaju(HvatacPostaja.dohvatiEuropskePostaje()));
        }
       async public void PrikaziVrijemeZaTrenutnulokaciju(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StranicaTrenutneLokacije());

        }
        async public void PrikaziOpcije(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Opcije());   

        } 
    }
}