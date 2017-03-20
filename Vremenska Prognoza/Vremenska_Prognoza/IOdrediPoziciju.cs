using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoroloskiPromatrac
{
   public interface IOdrediPoziciju
    {
       void ukljuciGps();
        void iskljuciGps();
        void dogodilaSegreška();
    }
   
}
