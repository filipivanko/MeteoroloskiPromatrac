using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoroloskiPromatrac
{


    class StatistikaViewModel
    {
        double prosjecnaTemperatura = 0;
        double zbrojTemperatre = 0;

        double prosjecniTlak = 0;
        double zbrojTlaka = 0;

        double prosjecnaVlaga = 0;
        double zbrojVlage = 0;

        public string MedijanTemperature { get; set; }
        public string MedijanTlaka { get; set; }
        public string MedijanVlage { get; set; }
        public string ProsjecniTlak { get; set; }
        public string ProsjecnaVlaga { get; set; }
        public string ProsjecnaTemperatura { get; set; }
        public string Lokacija { get; set; }


        public StatistikaViewModel(List<trenutnoVrijemeViewModel> ocitanjaSLokacije)
        {
            if (ocitanjaSLokacije.Count != 0)
            {
                Lokacija = ocitanjaSLokacije[0].Lokacija;
            }
            int brojOcitanjaTemperature = ocitanjaSLokacije.Count;
            int brojOcitanjaTlaka = ocitanjaSLokacije.Count;
            int brojOcitanjaVlage = ocitanjaSLokacije.Count;
            List<double> temperature = new List<double>();
            List<double> tlakovi = new List<double>();
            List<double> vlage = new List<double>();
            foreach (trenutnoVrijemeViewModel tvvm in ocitanjaSLokacije)
            {
                double temperatura;
                string temp = tvvm.Temperatura.Replace("*C", "");
                temp = temp.Replace("*", "");
                if (double.TryParse(temp, NumberStyles.Number, new CultureInfo("en-US"), out temperatura))
                {
                    zbrojTemperatre += temperatura;
                    temperature.Add(temperatura);
                }
                else {
                    brojOcitanjaTemperature -= 1;
                }


                double tlak;
                string tl = tvvm.Tlak.Replace("hPa", "");
                tl = tl.Replace("*", "");
                if (double.TryParse(tl, NumberStyles.Number, new CultureInfo("en-US"), out tlak))
                {
                    zbrojTlaka += tlak;
                    tlakovi.Add(tlak);
                }
                else {
                    brojOcitanjaTlaka -= 1;
                }

                double vlaga;
                string vla = tvvm.Vlaga.Replace("%", "");
                vla = vla.Replace("*", "");
                if (double.TryParse(vla, NumberStyles.Number, new CultureInfo("en-US"), out vlaga))
                {
                    zbrojVlage += vlaga;
                    vlage.Add(vlaga);
                }
                else {
                    brojOcitanjaVlage -= 1;
                }

            }
            prosjecnaTemperatura = zbrojTemperatre / brojOcitanjaTemperature;
            prosjecniTlak = zbrojTlaka / brojOcitanjaTlaka;
            prosjecnaVlaga = zbrojVlage / brojOcitanjaVlage;

            ProsjecnaTemperatura = prosjecnaTemperatura.ToString("0.00") + "*C";
            ProsjecniTlak = prosjecniTlak.ToString("0.00") + " hPa";
            ProsjecnaVlaga = prosjecnaVlaga.ToString("0.00") + "%";


            temperature.Sort();
            if (temperature.Count % 2 != 0)
            {
                if (temperature.Count != 0)
                {
                    MedijanTemperature = temperature[(temperature.Count / 2)].ToString("0.00") + "*C";
                }
                else {
                    MedijanTemperature = "-";
                }

            }
            else {
                if (temperature.Count != 0)
                {
                    double medTemp = (temperature[(temperature.Count / 2) - 1] + temperature[(temperature.Count / 2)]) / 2;
                    MedijanTemperature = medTemp.ToString("0.00") + "*C";
                }
                else {
                    MedijanTemperature = "-";
                }

            }

            tlakovi.Sort();
            if (tlakovi.Count % 2 != 0)
            {
                if (tlakovi.Count != 0)
                {
                    MedijanTlaka = tlakovi[tlakovi.Count / 2].ToString("0.00")+ " hPa";
                }
                else
                {
                    MedijanTlaka = "-";
                }

            }
            else {
                if (tlakovi.Count != 0)
                {
                    double medTla = (tlakovi[(tlakovi.Count / 2) - 1] + tlakovi[(tlakovi.Count / 2)]) / 2;
                    MedijanTlaka = medTla.ToString("0.00")+ " hPa";
                }
                else
                {
                    MedijanTlaka = "-";
                }

            }

            vlage.Sort();
            if (vlage.Count % 2 != 0)
            {
                if (vlage.Count != 0)
                {
                    MedijanVlage = vlage[(vlage.Count / 2)].ToString("0.00")+ "%";
                }
                else {
                    MedijanVlage = "-";
                }

            }
            else {
                if (vlage.Count != 0)
                {
                    double medVla = (vlage[(vlage.Count / 2) - 1] + vlage[(vlage.Count / 2)]) / 2;
                    MedijanVlage = medVla.ToString("0.00")+ "%";
                }
                else {
                    MedijanVlage = "-";
                }

            }
        }
    }
}
