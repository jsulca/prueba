using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Contextos.Common
{
    internal class AppSettings
    {
        public static string pruebaConnection = ConfigurationManager.ConnectionStrings["PRUEBA_DB"]?.ConnectionString;
    }
}
