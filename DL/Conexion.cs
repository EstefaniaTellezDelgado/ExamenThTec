using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
            public static string GetConnection()
            {
                return "Server=tcp:estefaniatellez.database.windows.net,1433;Initial Catalog=PruebaThTec;Persist Security Info=False;User ID=etellez;Password=pass@word1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
        }
}
