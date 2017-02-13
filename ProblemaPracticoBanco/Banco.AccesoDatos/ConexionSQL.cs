using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.AccesoDatos
{
    public static class ConexionSQL
    {

        public static string ConnectionString()
        {

            return ConfigurationManager.ConnectionStrings["BancoBD"].ConnectionString;
        }
    
    }
}
