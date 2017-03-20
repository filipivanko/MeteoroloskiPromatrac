using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoroloskiPromatrac
{
    [Table("OcitanjaVremena")]
    public class trenutnoVrijemeViewModel: INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("IDVremenskaPostaja")]
        public int IDVrijeme { get; set; }

        private string temperatura;
        private string opisVremena;
        private string tlak;
        private string vlaga;
        private string drzava;
        private string lokacija;
        private string brzinaVjetra;
        private string smjerVjetra;
        private string datumIVrijeme;
        public string DatumIVrijeme
        {
            get
            {
                return datumIVrijeme;
            }

            set
            {
                this.datumIVrijeme = value;
                NotifyPropertyChanged("DatumIVrijeme");
            }
        }
        public string Temperatura
        {
            get
            {
                return temperatura;
            }

            set
            {
                    this.temperatura = value;
                    NotifyPropertyChanged("Temperatura");
            }
        }


        public string BrzinaVjetra
        {
            get
            {
                return brzinaVjetra;
            }

            set
            {

                this.brzinaVjetra = value;
                NotifyPropertyChanged("BrzinaVjetra");
            }
        }


        public string SmjerVjetra
        {
            get
            {
                return smjerVjetra;
            }

            set
            {

                this.smjerVjetra = value;
                NotifyPropertyChanged("SmjerVjetra");
            }
        }

        public string OpisVremena
        {
            get
            {
                return opisVremena;
            }

            set
            {
                opisVremena = value;
                NotifyPropertyChanged("OpisVremena");
            }
        }

        public string Tlak
        {
            get
            {
                return tlak;
            }

            set
            {
                tlak = value;
                NotifyPropertyChanged("Tlak");
            }
        }

        public string Vlaga
        {
            get
            {
                return vlaga;
            }

            set
            {
                vlaga = value;
                NotifyPropertyChanged("Vlaga");
            }
        }

        public string Drzava
        {
            get
            {
                return drzava;
            }

            set
            {
                drzava = value;
                NotifyPropertyChanged("Drzava");
            }
        }

        public string Lokacija
        {
            get
            {
                return lokacija;
            }

            set
            {
                lokacija = value;
                NotifyPropertyChanged("Lokacija");
            }
        }

        public trenutnoVrijemeViewModel(string temperatura, string opis, string tlak, string vlaga,string vjetarSmjer,string vjetarBrzina, string drzava, string lokocija,string datum)
        {
            this.Temperatura = temperatura;
            this.OpisVremena = opis;
            this.Tlak = tlak;
            this.Vlaga = vlaga;
            this.Drzava = drzava;
            this.Lokacija = lokocija;
            this.SmjerVjetra = vjetarSmjer;
            this.BrzinaVjetra = vjetarBrzina;
            this.DatumIVrijeme = datum;
        }
        public trenutnoVrijemeViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

}
