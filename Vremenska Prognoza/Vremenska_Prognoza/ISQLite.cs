using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoroloskiPromatrac
{
  public  interface ISQLite
    {
        SQLiteConnection getKonekcija();
    }
}
