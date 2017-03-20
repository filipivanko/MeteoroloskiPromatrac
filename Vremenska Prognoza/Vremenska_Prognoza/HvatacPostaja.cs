using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MeteoroloskiPromatrac
{
    class HvatacPostaja
    {
    public static List<trenutnoVrijemeViewModel> ocitanjaHrvatska { get; set; }  = null;
     public static  List<trenutnoVrijemeViewModel> ocitanjaEuropa { get; set; } = null;

        public static List<trenutnoVrijemeViewModel> dohvatiDomacePostaje() {
            if (ocitanjaHrvatska == null)
            {
                ocitanjaHrvatska = dohvatiPostaje(@"http://vrijeme.hr/hrvatska_n.xml");
                return ocitanjaHrvatska;
            }
            else {
                return ocitanjaHrvatska;
            }

        }

        public static List<trenutnoVrijemeViewModel> dohvatiEuropskePostaje()
        {
            if (ocitanjaEuropa == null)
            {
                ocitanjaEuropa = dohvatiPostaje(@"http://vrijeme.hr/europa_n.xml");
                return ocitanjaEuropa;
            }
            else {
                return ocitanjaEuropa;
            }
        }

        public static List<trenutnoVrijemeViewModel> dohvatiPostaje(string url)
        {
            List<trenutnoVrijemeViewModel> listaPostaja = new List<trenutnoVrijemeViewModel>();
            XDocument xdoc = XDocument.Load(url);
            IEnumerable<XElement> postaje = xdoc.Descendants("Grad");
            DateTime sad = DateTime.Now;
            foreach (XElement e in postaje)
            {
                var podaci = e.Descendants("Podatci");
                listaPostaja.Add(
  
                     new trenutnoVrijemeViewModel(
                         podaci.Descendants("Temp").FirstOrDefault().Value+"*C",
                         podaci.Descendants("Vrijeme").FirstOrDefault().Value,
                         podaci.Descendants("Tlak").FirstOrDefault().Value+" hPa",
                         podaci.Descendants("Vlaga").FirstOrDefault().Value+"%", 
                         podaci.Descendants("VjetarSmjer").FirstOrDefault().Value,  
                         podaci.Descendants("VjetarBrzina").FirstOrDefault().Value,
                          "-",
                         e.Element("GradIme").Value,
                         sad.Day.ToString() + ". " + sad.Month.ToString() + ". " + sad.Year.ToString() + " / " + sad.Hour.ToString() + "h"
                     )  );
            }
            return listaPostaja;
        }
    }
}
