using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Runtime;
using CrossPlatformLibrary.Geolocation;
using Android.Locations;
using Xamarin.Forms;
using MeteoroloskiPromatrac.Droid;
using System;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(AndoroidGPSImplementacija))]
namespace MeteoroloskiPromatrac.Droid
{
    public class AndoroidGPSImplementacija : Java.Lang.Object, ILocationListener, IOdrediPoziciju
    {
        LocationManager locMgr;
        LocationManager netMgr;
        Context con;




        public void OnLocationChanged(Location location)
        {
                Pozicija poz = new Pozicija();
                poz.Latitude = location.Latitude;
                poz.Longtitude = location.Longitude;
                StranicaTrenutneLokacije.dohvati(poz);
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras) { }


       
        public void ukljuciGps()
        {
         con = Forms.Context;
            netMgr = con.GetSystemService(Context.LocationService) as LocationManager;
            netMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 100000, 500, this);
            locMgr = con.GetSystemService(Context.LocationService) as LocationManager;
         locMgr.RequestLocationUpdates(LocationManager.GpsProvider, 100000, 500, this);


        }

        public void iskljuciGps()
        {
            con = Forms.Context;
            locMgr.RemoveUpdates(this);
            netMgr.RemoveUpdates(this);
        }

        public void dogodilaSegreška()
        {
            var alert = new AlertDialog.Builder(Forms.Context);
            alert.SetTitle("Greška");
            alert.SetMessage("Dogodila se u ažuriranju vremena za trenutnu lokaciju");
            alert.SetNeutralButton("Cancel", (senderAlert, args) => {});
            alert.Show();
        }
    }
}
